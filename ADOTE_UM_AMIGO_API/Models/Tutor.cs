using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ADOTE_UM_AMIGO_API.Models
{
    public class Tutor
    {
        //Construtor
        public Tutor() => CriadoEm = DateTime.Now;
        //Atributos ou propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Senha { get; set; }
        public int Cpf { get; set; }
        public int Telefone { get; set; }
        public string Endereco { get; set; }
        public DateTime CriadoEm { get; set; }
        

        [JsonIgnore]
        public List<Dog> Dogs { get; set; }
        public override string ToString() =>
            $"Nome: {Nome} | CPF: {Cpf} | Entrou em: {CriadoEm} | Telefone: {Telefone} | Endereço: {Endereco}";
    }
}