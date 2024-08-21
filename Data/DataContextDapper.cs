using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ToDoAPI.Data
{
    public class DataContextDapper
    {
        private readonly IConfiguration _config;
        private readonly IDbConnection _dbConnection;

        public DataContextDapper(IConfiguration config) 
        { 
            _config = config;
            _dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }

        public IEnumerable<T> GetData<T>(string sql)
        {
            return _dbConnection.Query<T>(sql);
        }

        public T GetDataSingle<T>(string sql)
        {
            return _dbConnection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            return _dbConnection.Execute(sql) > 0;
        }

        public int ExecuteSqlRowCount(string sql)
        {
            return _dbConnection.Execute(sql);
        }

        public bool ExecuteSqlParams(string sql, DynamicParameters parameters)
        {
            return _dbConnection.Execute(sql, parameters) > 0;
        }

        public IEnumerable<T> GetDataWithParams<T>(string sql, DynamicParameters parameters)
        {
            return _dbConnection.Query<T>(sql, parameters);
        }

        public T GetDataSingleWithParams<T>(string sql, DynamicParameters parameters)
        {
            return _dbConnection.QuerySingle<T>(sql, parameters);
        }

    }
}
