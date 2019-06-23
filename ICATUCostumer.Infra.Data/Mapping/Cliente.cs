using System;
using Dapper;

namespace ICATUCostumer.Infra.Data.Mapping
{
    public class Cliente : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime CadastradoEm { get; set; }
        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }
    }
}
