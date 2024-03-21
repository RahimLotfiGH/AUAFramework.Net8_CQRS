using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;

namespace AUA.ProjectName.DataLayer.DbExtensions
{
    public static class DbCommandExtensions
    {

        public static DbCommand LoadStoredProc(string storedProcName)
        {
            var cmd = new SqlCommand
            {
                CommandText = storedProcName,
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = CreateSqlConnection()
            };
            cmd.Connection.Open();

            return cmd;
        }

        private static SqlConnection CreateSqlConnection()
        {
            return new SqlConnection(AppConfiguration.EfConnectionString);
        }

        public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, object paramValue)
        {
            if (string.IsNullOrEmpty(cmd.CommandText))
                throw new InvalidOperationException(
                    "Call LoadStoredProc before using this method");
            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            cmd.Parameters.Add(param);
            return cmd;
        }

        public static async Task<List<T>> ExecuteStoredProcAsync<T>(this DbCommand command)
        {
            await using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    await command.Connection.OpenAsync();
                try
                {
                    await using var reader = await command.ExecuteReaderAsync();

                    return reader.MapToList<T>();
                }
                finally
                {
                    await command.Connection.CloseAsync();
                }
            }
        }


        public static IQueryable<T> ExecuteStoredProc<T>(this DbCommand command)
        {
            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.MapToList<T>().AsQueryable();
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        private static List<T> MapToList<T>(this DbDataReader dr)
        {
            var objList = new List<T>();
            var props = typeof(T).GetRuntimeProperties();

            var colMapping = dr.GetColumnSchema()
                .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                .ToDictionary(key => key.ColumnName.ToLower());

            if (!dr.HasRows) return objList;

            var propertyInfos = props as PropertyInfo[] ?? props.ToArray();

            while (dr.Read())
            {
                var obj = Activator.CreateInstance<T>();
                foreach (var prop in propertyInfos)
                {
                    var val =
                        dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                    prop.SetValue(obj, val == DBNull.Value ? null : val);
                }
                objList.Add(obj);
            }
            return objList;
        }


    }
}
