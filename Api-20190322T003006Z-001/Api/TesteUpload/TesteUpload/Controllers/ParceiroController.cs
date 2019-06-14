using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TesteUpload.Model;

namespace TesteUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParceiroController : ControllerBase
    {
        private readonly UP7WebApiContext _context;
        private IHostingEnvironment _env;

        public ParceiroController(UP7WebApiContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET: api/Parceiro
        [HttpGet]
        [EnableCors("MyPolicy")]
        public ReturnModel GetAll()
        {
            ReturnModel result = new ReturnModel();
            try
            {

                result.Object = _context.parceiros.ToList();
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Success = false;
                throw ex;
            }
            return result;
        }

        // GET: api/Parceiro/5
        [HttpGet("{id}")]
        [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [Produces("application/json")]
        [HttpPost, DisableRequestSizeLimit]
        [EnableCors("MyPolicy")]
        [Route("cadastro")]
        public async Task<IActionResult> UploadFile()
        {
            ReturnModel result = new ReturnModel();
            try
            {
                var parceiro = JsonConvert.DeserializeObject<ParceiroModel>(Request.Form["parceiro"]);
                var webRoot = _env.WebRootPath;
                var filePath = System.IO.Path.Combine(webRoot, "conteudo\\");


                foreach (var arquivo in Request.Form.Files)
                {
                    if (arquivo.Length > 0)
                    {
                        parceiro.Imagem = ($"conteudo/{arquivo.Name}");
                        var imagem = $"{ filePath}{ arquivo.Name}";
                        using (var stream = new FileStream(imagem, FileMode.Create))
                        {
                            await arquivo.CopyToAsync(stream);
                        }
                    }
                }
                _context.parceiros.Add(parceiro);
                _context.SaveChanges();
                result.Message = "Dados salvos com sucesso!";

            }
            catch (Exception ex)
            {
                var e = ex;
                result.Message = "Erro, verifique se os dados estão corretos!";
                return Ok(result);

            }

            return Ok(result);
        }

        // POST: api/Parceiro
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/Parceiro/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
        }
    }
}
