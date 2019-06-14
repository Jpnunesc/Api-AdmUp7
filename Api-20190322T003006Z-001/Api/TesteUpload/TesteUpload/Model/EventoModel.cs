
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
        public string Descricao { get; set; }
    }
}