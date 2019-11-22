using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TesteUpload.Model
{
    public class ImagemModel
    {


        public int Id { get; set; }
        public string ImgBase64 { get; set; }
        public virtual CarroModel Carro { get; set; }
    }
}
