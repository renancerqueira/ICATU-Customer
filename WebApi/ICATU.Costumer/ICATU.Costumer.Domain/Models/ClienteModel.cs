using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICATU.Costumer.Domain.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required]
        public int Idade { get; set; }
        
        [Required]
        public CpfModel Cpf { get; set; }

        public int EnderecoId { get; set; }

        [Required]
        public EnderecoModel Endereco { get; set; }
    }
}
