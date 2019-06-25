using ICATU.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace ICATU.Infra.Data
{
    public class ClientesRepository
    {
        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Cliente, Endereco, Cliente>(@"
                                SELECT  *
                                  FROM  Cliente  C
                            INNER JOIN  Endereco E
                                    ON  C.EnderecoId = E.Id
                                ", (c, e) => { c.Endereco = e; return c; })
                         .ToList();
            }
        }

        public Cliente Get(int id)
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Cliente, Endereco, Cliente>($@"
                                SELECT  *
                                  FROM  Cliente  C
                            INNER JOIN  Endereco E
                                    ON  C.EnderecoId = E.Id
                                 WHERE  C.Id = {id}
                                ", (c, e) => { c.Endereco = e; return c; })
                         .SingleOrDefault();
            }
        }

        public int Insert(Cliente entry)
        {
            using (IDbConnection db = Connection)
            {
                entry.EnderecoId = db.ExecuteScalar<int>("INSERT INTO Endereco (Logradouro, Bairro, Cidade, Estado) VALUES (@Logradouro, @Bairro, @Cidade, @Estado); SELECT @@IDENTITY;", entry.Endereco);
                var x = db.Execute(@"INSERT INTO Cliente (Nome, Idade, Cpf, EnderecoId) VALUES (@Nome, @Idade, @Cpf, @EnderecoId)", entry);
                return x;
            }
        }

        public int Update(Cliente entry)
        {
            using (IDbConnection db = Connection)
            {
                return db.Execute(@"UPDATE Cliente SET Nome = @Nome, Idade = @Idade, Cpf = @Cpf WHERE Id = @Id", entry); ;
            }
        }

        public int Delete(int id)
        {
            using (IDbConnection db = Connection)
            {
                return db.Execute(@"DELETE FROM Cliente WHERE Id = " + id);
            }
        }
    }
}
