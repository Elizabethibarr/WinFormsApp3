using System.Collections.Generic;
using System.Data;

namespace WinFormsApp3.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(IDbConnection connection = null);
        T Get(object id, IDbConnection connection = null);
        object Insert(T entity, IDbConnection connection = null);
        int Update(T entity, IDbConnection connection = null);
        int Delete(object id, IDbConnection connection = null);
    }
}