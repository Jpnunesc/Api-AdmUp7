using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteUpload.Model
{
    [Table("Codigo")]
    public class CodigoModel
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public bool? Ativo { get; set; }   
        public int IdRifa { get; set; }
        [ForeignKey("IdRifa")]
        public virtual RifaModel Rifa { get; set; }
    }
}
