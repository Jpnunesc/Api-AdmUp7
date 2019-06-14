using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteUpload.Model
{
    public class ReturnModel
    {
        public bool Success { get; set; }
        public object Object { get; set; }
        public string Message { get; set; }
    }
}
