using System;
using System.Collections.Generic;
using ICATUCostumer.Infra.Data.Mapping;

namespace ICATUCostumer.Infra.Data.Repository
{
    public interface IRepository<T>
        where T : IEntity
    {
        int? Insert(T entry);
        void Update(T entry);
        void Delete(Guid id);
        T Get(Guid id);
        IEnumerable<T> Get(int page, int length);
        IEnumerable<T> Get(int page, int length, string conditions);
    }
}
