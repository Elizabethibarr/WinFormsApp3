using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using RepoDb;

namespace WinFormsApp3.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly string _connectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public virtual IEnumerable<T> GetAll(IDbConnection connection = null)
        {
            using (var conn = connection ?? CreateConnection())
            {
                return conn.QueryAll<T>();
            }
        }

        public virtual T Get(object id, IDbConnection connection = null)
        {
            using (var conn = connection ?? CreateConnection())
            {
                return conn.Query<T>(id).FirstOrDefault();
            }
        }

        public virtual object Insert(T entity, IDbConnection connection = null)
        {
            using (var conn = connection ?? CreateConnection())
            {
                return conn.Insert(entity);
            }
        }

        public virtual int Update(T entity, IDbConnection connection = null)
        {
            using (var conn = connection ?? CreateConnection())
            {
                return (int)conn.Update(entity);
            }
        }

        public virtual int Delete(object id, IDbConnection connection = null)
        {
            using (var conn = connection ?? CreateConnection())
            {
                return (int)conn.Delete<T>(id);
            }
        }
    }
}