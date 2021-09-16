using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
            => _connection = connection;
        public IEnumerable<T> Get()
            => DataBase.Connection.GetAll<T>();

        public T Get(int id)
           => DataBase.Connection.Get<T>(id);

        public void Create(T model)
            => DataBase.Connection.Insert<T>(model);

        public void Update(T model)
        {
            DataBase.Connection.Update<T>(model);
        }
        public void Delete(T model)
        {
            DataBase.Connection.Delete<T>(model);
        }
        public void Delete(int id)
        {
            var model = DataBase.Connection.Get<T>(id);
            DataBase.Connection.Delete<T>(model);
        }
    }
}