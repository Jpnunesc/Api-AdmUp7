using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteUpload.Model
{
    [Table("RifasUsuario")]
    public class RifasUsuarioModel
    {
        [Key]
        public int IdUsuario { get; set; }
        public int IdRifa { get; set; }
        public bool Status { get; set; }

        //[ForeignKey("IdUsuario")]
        //public virtual UsuarioModel usuario { get; set; }
        //[ForeignKey("IdRifa")]
        //public virtual RifaModel Rifa { get; set; }
    }
}
