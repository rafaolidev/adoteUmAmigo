
using System;

namespace ADOTE_UM_AMIGO_API.Models
{
    public class Dog
    {
        //Construtor
        public Dog() => CriadoEm = DateTime.Now;

        //Atributos ou propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Idade { get; set; }
        public string Raca { get; set; }
        public int Dono_Id { get; set; }
        public int Status { get; set; }
        public DateTime CriadoEm { get; set; }

        public override string ToString() =>
            $"Nome: {Nome} | Raça: {Raca} | Criado em: {CriadoEm}";

    }
}