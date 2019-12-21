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

                using (SqlConnection sqlConnection = GetSqlConnection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
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

        protected  static SqlConnection GetSqlConnection()
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
                    var compile = Expression.Lambda(binary.Right).Compile();

                    value = compile.DynamicInvoke().ToString();
                }
            }

            return (name, value);
        }
    }
}

