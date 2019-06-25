using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICATU.Costumer.Domain.Models
{
    public class EnderecoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(40)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(40)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(40)]
        public string Estado { get; set; }
    }
}
