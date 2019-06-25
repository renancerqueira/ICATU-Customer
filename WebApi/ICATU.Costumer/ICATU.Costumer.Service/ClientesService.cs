using AutoMapper;
using ICATU.Costumer.Domain.Models;
using ICATU.Infra.Data;
using ICATU.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICATU.Costumer.Service
{
    public class ClientesService
    {
        private ClientesRepository repository;

        public ClientesService()
        {
            repository = new ClientesRepository();
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            var all = repository.GetAll();
            return Mapper.Map<IEnumerable<ClienteModel>>(all);
        }

        public ClienteModel Get(int id)
        {
            var entry = repository.Get(id);
            return Mapper.Map<ClienteModel>(entry);
        }

        public int Insert(ClienteModel model)
        {
            return repository.Insert(Mapper.Map<Cliente>(model));
        }

        public int Update(ClienteModel model)
        {
            return repository.Update(Mapper.Map<Cliente>(model));
        }

        public int Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
