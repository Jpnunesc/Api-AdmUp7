
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TesteUpload.Model
{
  
    [Table("Evento")]
    public class EventoModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Mes { get; set; }
        [Required]
        public string Imagem { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
    }
}