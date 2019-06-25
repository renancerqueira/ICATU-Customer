using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Collections.Generic;
using ICATUCostumer.Infra.Data.Mapping;

namespace ICATUCostumer.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T>
        where T : IEntity
    {
        public IConfiguration Configuration { get; private set; }
        public SqlConnection Connection => new SqlConnection(ConfigurationExtensions.GetConnectionString(Configuration, "DefaultConnection"));

        public int? Insert(T entry)
        {
            using (var ctx = Connection)
            {
                return ctx.Insert(entry);
            }
        }
        public void Update(T entry)
        {
            using (var ctx = Connection)
            {
                ctx.Update(entry);
            }
        }
        public void Delete(Guid id)
        {
            using (var ctx = Connection)
            {
                ctx.Delete(id);
            }
        }
        public T Get(Guid id)
        {
            using (var ctx = Connection)
            {
                return ctx.Get<T>(id);
            }
        }
        public IEnumerable<T> Get(int page, int length)
        {
            using (var ctx = Connection)
            {
                return ctx.GetListPaged<T>(page, length, "", "");
            }
        }
        public IEnumerable<T> Get(int page, int length, string conditions)
        {
            using (var ctx = Connection)
            {
                return ctx.GetListPaged<T>(page, length, conditions, "");
            }
        }
    }
}
