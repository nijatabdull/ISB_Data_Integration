using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.Linq.Expressions;
using System.Threading;
using ISB_Service.Infrastructure.DatabaseRelate;
using ISB_Infra.Attribute;

namespace ISB_Service.Infrastructure
{
    class DatabaseProvider : AncestorDatabaseProvider
    {
        public static async Task<IEnumerable<T>> GetDataListAsync<T>()
            where T:class,new()
        {
            return await GetDataListAsync<T>("select * from " + (new T()).GetType().Name);
        }

        public static async Task<IEnumerable<T>> GetDataListAsync<T>(Expression<Func<T, bool>> func)
            where T : class, new()
        {
            (string name, string value) = GetLambdaExpressionNameAndValue(func);

            string query = "select * from " + (new T()).GetType().Name + " where " + name + "='" + value + "'";

            return await GetDataListAsync<T>(query);
        }

        public static async Task<T> GetFirstDataAsync<T>(Expression<Func<T, bool>> changableProperty)
           where T : class, new() 
        {
            try
            {
                (string name, string value) = GetLambdaExpressionNameAndValue(changableProperty);

                if (name != null && value != null)
                {
                    T @class = new T();

                    using (
                        SqlConnection sqlConnection = GetSqlConnection())
                    {
                        string query = @"select * from " + @class.GetType().Name + " where " + name + "='" + value + "'";

                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        foreach (PropertyInfo property in @class.GetType().GetProperties())
                                        {
                                            if (!(property.GetCustomAttribute<DbPropertyIgnoreAttribute>() is DbPropertyIgnoreAttribute))
                                            {
                                                object proValue = reader[property.Name];

                                                if (await reader.IsDBNullAsync(reader.GetOrdinal(property.Name)))
                                                    proValue = null;

                                                if (proValue?.GetType() == typeof(bool) && property
                                                                .GetCustomAttribute<DbPropertyChangeTypeAttribute>() is DbPropertyChangeTypeAttribute)
                                                {
                                                    if (proValue.ToString().ToUpper() == "TRUE")
                                                        proValue = (byte)1;

                                                    if (proValue.ToString().ToUpper() == "FALSE")
                                                        proValue = (byte)0;
                                                }

                                                @class.GetType().GetRuntimeProperty(property.Name)
                                                                .SetValue(@class, proValue);
                                            }
                                        }
                                    }
                                }
                                else
                                    @class = null;
                            }
                        }
                    }
                    return @class;
                }
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

        public static void AddData<T>(T item)
          where T : class, new()
        {
            try
            {
                using (
                    SqlConnection sqlConnection = GetSqlConnection())
                {
                    StringBuilder stringBuilder = new StringBuilder();

                    stringBuilder.Append(@"insert into "+ item.GetType().Name+"(");

                    foreach (PropertyInfo property in item.GetType().GetProperties())
                    {
                        if (!(property.GetCustomAttribute<DbPropertyIgnoreAttribute>() is DbPropertyIgnoreAttribute))
                        {
                            stringBuilder.Append(property.Name + ",");
                        }
                    }

                    stringBuilder.Remove(stringBuilder.Length - 1, 1);

                    stringBuilder.Append(") values(");

                    foreach (PropertyInfo property in item.GetType().GetProperties())
                    {
                        if (!(property.GetCustomAttribute<DbPropertyIgnoreAttribute>() is DbPropertyIgnoreAttribute))
                        {
                            object value = property.GetValue(item);

                            if (property.GetCustomAttribute<DbProperyForeignKeyAttribute>() is DbProperyForeignKeyAttribute)
                            {
                                if (!(value?.ToString() == string.Empty || value == null))
                                    stringBuilder.Append("'" + value + "',");
                            }
                            else
                                stringBuilder.Append("'" + value + "',");
                        }
                    }

                    stringBuilder.Remove(stringBuilder.Length - 1, 1);

                    stringBuilder.Append(")");

                    using (SqlCommand sqlCommand = new SqlCommand(stringBuilder.ToString(), sqlConnection))
                    {
                         sqlCommand.ExecuteNonQuery();
                    }
                }
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
        }

        public static void UpdateData<T>(T obj, Expression<Func<T, bool>> func)
          where T : class, new()
        {
            try
            {
                (string name, string value) = GetLambdaExpressionNameAndValue(func);

                if(name!=string.Empty&&value!=string.Empty)
                {
                    using (
                    SqlConnection sqlConnection = GetSqlConnection())
                    {
                        StringBuilder stringBuilder = new StringBuilder();

                        stringBuilder.Append(@"UPDATE " + obj.GetType().Name + " SET ");

                        foreach (PropertyInfo property in obj.GetType().GetProperties())
                        {
                            object objValue = property?.GetValue(obj);

                            if (!(property.GetCustomAttribute<DbPropertyIgnoreAttribute>() is DbPropertyIgnoreAttribute))
                            {
                                if (property.GetCustomAttribute<DbProperyForeignKeyAttribute>() is DbProperyForeignKeyAttribute)
                                {
                                    if (!(objValue?.ToString() == string.Empty || objValue == null))
                                    {
                                        stringBuilder.Append(property.Name + " =");

                                        stringBuilder.Append("'" + objValue + "',");
                                    }
                                }
                                else
                                {
                                    stringBuilder.Append(property.Name + " =");

                                    stringBuilder.Append("'" + objValue + "',");
                                }
                            }
                        }

                        stringBuilder.Remove(stringBuilder.Length - 1, 1);

                        stringBuilder.Append(" WHERE " + name + "='" + value + "'");

                        using (SqlCommand sqlCommand = new SqlCommand(stringBuilder.ToString(), sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
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
        }

        public static void UpdateData<T>(Expression<Func<T, bool>> condition, Expression<Func<T,object>> changableProperty, object value)
            where T : class, new()
        {
            try
            {
                if (value != null)
                {
                    (string conditionName, string conditionValue) = GetLambdaExpressionNameAndValue(condition);

                    string signName = GetLambdaExpressionName(changableProperty);

                    using (SqlConnection sqlConnection = GetSqlConnection())
                    {
                        StringBuilder stringBuilder = new StringBuilder();

                        stringBuilder.Append(@"UPDATE " + new T().GetType().Name + " SET ");

                        stringBuilder.Append(signName + "='" + value);

                        stringBuilder.Append("' WHERE " + conditionName + "='" + conditionValue + "'");

                        using (SqlCommand sqlCommand = new SqlCommand(stringBuilder.ToString(), sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
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
        }

        public static void DeleteData<T>(Expression<Func<T, bool>> func)
          where T : class, new()
        {
            try
            {
                (string name, string value) = GetLambdaExpressionNameAndValue(func);

                if(name!=string.Empty&&value!=string.Empty)
                {
                    using (
                    SqlConnection sqlConnection = GetSqlConnection())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(
                            "DELETE FROM " + new T().GetType().Name + " WHERE " + name + "='" + value + "'",
                                                                                            sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
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
        }
    }
}
