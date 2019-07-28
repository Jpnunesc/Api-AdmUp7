using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteUpload.Model
{
    [Table("Adicional")]
    public class AdicionalModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCarro { get; set; }
        [ForeignKey("IdCarro")]
        public virtual CarroModel Carro { get; set; }
    }
}
