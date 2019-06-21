using System;
using System.Collections.Generic;
using ICATUCostumer.Domain.Model;

namespace ICATUCostumer.Service
{
    public class ClientesService
    {
        public ClientesService()
        {
        }

        public List<ClienteModel> Search(string search, int? page = null, int? length = null)
        {
            return new List<ClienteModel>();
        }

        public ClienteModel Get(Guid id)
        {
            return new ClienteModel();
        }

        public bool Any(Guid id)
        {
            return true;
        }

        public Guid Insert(ClienteModel cliente)
        {
            return new Guid();
        }

        public void Update(ClienteModel cliente)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
