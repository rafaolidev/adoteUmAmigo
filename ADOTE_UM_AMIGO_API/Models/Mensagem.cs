using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADOTE_UM_AMIGO_API.Models
{
    public class Mensagem
    {
        public Mensagem() => CriadoEm = DateTime.Now;
        //Atributos ou propriedades
        
        public int Id { get; set; }
        public int Id_Sender { get; set; }
        public int Id_Receiver { get; set; }
        public string Corpo { get; set; }
        public DateTime CriadoEm { get; set; }
        public override string ToString() =>
            $"Enviada por: {Id_Sender} | Para: {Id_Receiver} | Enviado em: {CriadoEm} | Mensagem:{Corpo}";
    }
}