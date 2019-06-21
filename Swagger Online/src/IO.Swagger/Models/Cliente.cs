/*
 * ICATU - API Clientes
 *
 * API desenvolvida como um desafio para avançar no processo de seleção da ICATU. Esta API tem o objetivo de disponibilizar o CRUD de clientes e o CRUD de Endereços.
 *
 * OpenAPI spec version: 1.0.0
 * Contact: renancerqueira@gmail.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Cliente : IEquatable<Cliente>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [DataMember(Name="id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Nome
        /// </summary>
        [Required]
        [DataMember(Name="nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Gets or Sets Idade
        /// </summary>
        [Required]
        [DataMember(Name="idade")]
        public int? Idade { get; set; }

        /// <summary>
        /// Gets or Sets CadastradoEm
        /// </summary>
        [DataMember(Name="cadastradoEm")]
        public DateTime? CadastradoEm { get; set; }

        /// <summary>
        /// Gets or Sets Cpf
        /// </summary>
        [Required]
        [DataMember(Name="cpf")]
        public CPF Cpf { get; set; }

        /// <summary>
        /// Gets or Sets Endereco
        /// </summary>
        [Required]
        [DataMember(Name="endereco")]
        public Endereco Endereco { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Cliente {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Nome: ").Append(Nome).Append("\n");
            sb.Append("  Idade: ").Append(Idade).Append("\n");
            sb.Append("  CadastradoEm: ").Append(CadastradoEm).Append("\n");
            sb.Append("  Cpf: ").Append(Cpf).Append("\n");
            sb.Append("  Endereco: ").Append(Endereco).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Cliente)obj);
        }

        /// <summary>
        /// Returns true if Cliente instances are equal
        /// </summary>
        /// <param name="other">Instance of Cliente to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Cliente other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    Nome == other.Nome ||
                    Nome != null &&
                    Nome.Equals(other.Nome)
                ) && 
                (
                    Idade == other.Idade ||
                    Idade != null &&
                    Idade.Equals(other.Idade)
                ) && 
                (
                    CadastradoEm == other.CadastradoEm ||
                    CadastradoEm != null &&
                    CadastradoEm.Equals(other.CadastradoEm)
                ) && 
                (
                    Cpf == other.Cpf ||
                    Cpf != null &&
                    Cpf.Equals(other.Cpf)
                ) && 
                (
                    Endereco == other.Endereco ||
                    Endereco != null &&
                    Endereco.Equals(other.Endereco)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Nome != null)
                    hashCode = hashCode * 59 + Nome.GetHashCode();
                    if (Idade != null)
                    hashCode = hashCode * 59 + Idade.GetHashCode();
                    if (CadastradoEm != null)
                    hashCode = hashCode * 59 + CadastradoEm.GetHashCode();
                    if (Cpf != null)
                    hashCode = hashCode * 59 + Cpf.GetHashCode();
                    if (Endereco != null)
                    hashCode = hashCode * 59 + Endereco.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Cliente left, Cliente right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Cliente left, Cliente right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}