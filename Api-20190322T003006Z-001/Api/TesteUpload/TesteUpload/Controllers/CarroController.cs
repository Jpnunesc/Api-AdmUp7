using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TesteUpload.Model;

namespace TesteUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        // GET: api/Carro
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Carro/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [Produces("application/json")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile()
        {
            try
            {
                var carro = JsonConvert.DeserializeObject<Carro>(Request.Form["carro"]);
                var filePath = Path.GetTempPath();
               

                foreach (var arquivo in Request.Form.Files)
                {
                    if (arquivo.Length > 0)
                    {
                        string imagem = $"{Path.GetTempPath()}{carro.Id + arquivo.FileName}";
                        using (var stream = new FileStream(imagem, FileMode.Create))
                        {
                            await arquivo.CopyToAsync(stream);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("sucess");
        }

        // PUT: api/Carro/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("teste")]
        [HttpGet]
        public string Teste()
        {
            return "teste";
        }
    }
}
