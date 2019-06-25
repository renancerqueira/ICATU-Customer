using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICATU.Costumer.Domain.Models
{
    public class CpfModel
    {
        public CpfModel(string numero)
        {
            this.Numero = numero;
        }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string Numero { get; set; }

        public override string ToString()
        {
            return Numero;
        }
    }
}
