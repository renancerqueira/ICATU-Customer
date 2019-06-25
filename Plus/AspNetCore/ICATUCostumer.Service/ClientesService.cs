using System;
using System.Collections.Generic;
using AutoMapper;
using ICATUCostumer.Domain.Model;
using ICATUCostumer.Infra.Data.Mapping;
using ICATUCostumer.Infra.Data.Repository;

namespace ICATUCostumer.Service
{
    public class ClientesService : BaseService<ClientesRepository>
    {
        public IList<ClienteModel> Get(int page = 1, int length = 10, string containsName = "")
        {
            var list = repository.Get(page, length, $"Nome like '%{containsName}%'");
            return Mapper.Map<IList<ClienteModel>>(list);
        }

        public Guid Insert(ClienteModel model)
        {
            var entry = Mapper.Map<Cliente>(model);
            entry.Id = new Guid();

            repository.Insert(entry);

            return entry.Id;
        }
    }
}
