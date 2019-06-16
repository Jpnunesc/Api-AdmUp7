using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TesteUpload.Model
{
    [Table("Rifa")]
    public class RifaModel
    {
        public RifaModel()
        {
            Usuario = new List<UsuarioModel>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Imagem { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Preco { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public int QuantidadaRestante { get; set; }
        public string Status { get; set; }

        public virtual ICollection<UsuarioModel> Usuario { get; set; }


    }
}