using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using ICATUCostumer.Infra.Data.Mapping;
using Microsoft.Extensions.Configuration;

namespace ICATUCostumer.Infra.Data.Repository
{
    public class ClientesRepository : BaseRepository<Cliente>
    {

    }
}
