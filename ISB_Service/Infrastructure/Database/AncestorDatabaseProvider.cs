using ISB_Infra.Attribute;
using ISB_Model.Model;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ISB_Service.Infrastructure.DatabaseRelate
{
    abstract class AncestorDatabaseProvider
    {
        protected static readonly Logger FileLogger = LogManager.GetLogger("logFile");
        protected static readonly Logger DbLogger = LogManager.GetLogger("databaseLogger");

        protected static async Task<IEnumerable<T>> GetDataListAsync<T>(string query)
           where T : class, new()
        {
            try
            {
                IList<T> _data = new List<T>();

                using (SqlConnection sqlConnection = await GetSqlConnectionAsync())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader reader = await sqlCommand.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (reader.HasRows)
                            {
                                while (await reader.ReadAsync())
                                {
                                    T @class = new T();

                                    foreach (PropertyInfo property in @class.GetType().GetProperties())
                                    {
                                        if(!(property.GetCustomAttribute<DbPropertyIgnoreAttribute>() is DbPropertyIgnoreAttribute))
                                        {
                                            object proValue = reader[property.Name];

                                            if (await reader.IsDBNullAsync(reader.GetOrdinal(property.Name)))
                                                proValue = null;

                                            if (proValue?.GetType() == typeof(bool) && property
                                                            .GetCustomAttribute<DbPropertyChangeTypeAttribute>() is DbPropertyChangeTypeAttribute)
                                            {
                                                if (proValue?.ToString().ToUpper() == "TRUE")
                                                    proValue = (byte)1;

                                                if (proValue?.ToString().ToUpper() == "FALSE")
                                                    proValue = (byte)0;
                                            }

                                            @class.GetType().GetRuntimeProperty(property.Name)
                                                            .SetValue(@class, proValue);
                                        }
                                    }

                                    _data.Add(@class);
                                }
                            }
                        }
                    }
                }
                return _data;
            }
            catch (SqlException exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            catch (Exception exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            return null;
        }

        protected static async Task<SqlConnection> GetSqlConnectionAsync()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager
                                        .ConnectionStrings["IcbariSigortaBurosu"].ConnectionString);

                await sqlConnection.OpenAsync().ConfigureAwait(false);

                return sqlConnection;  
            }
            catch (SqlException exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            catch (Exception exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            return null;
        }

        protected static SqlConnection GetSqlConnection()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager
                                        .ConnectionStrings["IcbariSigortaBurosu"].ConnectionString);

                sqlConnection.Open();

                return sqlConnection;
            }
            catch (SqlException exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            catch (Exception exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            return null;
        }

        protected static string GetLambdaExpressionName<T>(Expression<Func<T, object>> exp)
            where T : class, new()
        {
            string name = string.Empty;

            string expression = exp.Body.ToString();

            if(expression.Contains(")"))
                name = expression.Substring(expression.IndexOf('.') + 1,
                              expression.Length - expression.IndexOf('.') - 2);
            else
                name = expression.Substring(expression.IndexOf('.') + 1,
                              expression.Length - expression.IndexOf('.') - 1);

            return name;
        }

        protected static (string name, string value) GetLambdaExpressionNameAndValue<T>(Expression<Func<T, bool>> func)
           where T : class, new()
        {
            string name = string.Empty; string value = string.Empty;

            if (func.Body is BinaryExpression binary)
            {
                string left = binary.Left.ToString();

                if (!(binary.Left is MemberExpression memberLeft))
                {
                    name = left.Substring(left.IndexOf(".") + 1, left.Length - left.IndexOf(".") - 2);
                }
                else
                    name = memberLeft.Member.Name;

                if (binary.Left is MemberExpression memberLeftValue && memberLeftValue.Expression is ParameterExpression)
                {
                    Delegate compile = Expression.Lambda(binary?.Right)?.Compile();

                    if(compile!=null)
                    {
                        object obj = (compile)?.DynamicInvoke();

                        if (obj != null)
                        {
                            value = obj.ToString();
                        }
                    }
                }
            }

            return (name, value);
        }

        protected static (string nameFirst, string valueFirst, string nameSecond, string valueSecond) GetLambdaExpressionNameAndValue<T>(Expression<Func<T,T, bool>> func)
           where T : class, new()
        {
            string nameFirst = string.Empty; string valueFirst = string.Empty;

            string nameSecond = string.Empty; string valueSecond = string.Empty;

            if (func.Body is BinaryExpression binary)
            {
                if (binary.Left is BinaryExpression binaryLeft)
                {
                    string leftConStr = binaryLeft.Left.ToString();

                    if (!(binary.Left is MemberExpression memberLeft))
                    {
                        nameFirst = leftConStr.Substring(leftConStr.IndexOf(".") + 1, leftConStr.Length - leftConStr.IndexOf(".") - 1);
                    }
                    else
                        nameFirst = memberLeft.Member.Name;

                    if (binaryLeft.Left is MemberExpression memberLeftValue && memberLeftValue.Expression is ParameterExpression)
                    {
                        var compile = Expression.Lambda(binaryLeft?.Right)?.Compile();

                        valueFirst = compile?.DynamicInvoke()?.ToString();
                    }
                }

                if (binary.Right is BinaryExpression binaryRight)
                {
                    string leftConStr = binaryRight.Left.ToString();

                    if (!(binary.Left is MemberExpression memberLeft))
                    {
                        nameSecond = leftConStr.Substring(leftConStr.IndexOf(".") + 1, leftConStr.Length - leftConStr.IndexOf(".") - 1);
                    }
                    else
                        nameSecond = memberLeft.Member.Name;

                    if (binaryRight.Left is MemberExpression memberLeftValue && memberLeftValue.Expression is ParameterExpression)
                    {
                        var compile = Expression.Lambda(binaryRight?.Right)?.Compile();

                        valueSecond = compile?.DynamicInvoke()?.ToString();
                    }
                }
            }

            return (nameFirst,valueFirst, nameSecond, valueSecond);
        }
    }
}

