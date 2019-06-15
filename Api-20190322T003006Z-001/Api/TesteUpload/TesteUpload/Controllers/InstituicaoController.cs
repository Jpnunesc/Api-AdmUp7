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
    public class InstituicaoController : ControllerBase
    {

        private readonly UP7WebApiContext _context;
        private IHostingEnvironment _env;

        public InstituicaoController(UP7WebApiContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/Instituicao
        [HttpGet]
        [EnableCors("MyPolicy")]
        public ReturnModel GetAll()
        {
            ReturnModel result = new ReturnModel();
            try
            {

                result.Object = _context.instituicao.ToList();
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Success = false;
                throw ex;
            }
            return result;
        }

        // GET: api/Instituicao/5
        [HttpGet]
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
            InstituicaoModel instituicao = new InstituicaoModel();
            try
            {
                 instituicao = JsonConvert.DeserializeObject<InstituicaoModel>(Request.Form["instituicao"]);
                var webRoot = _env.WebRootPath;
                var filePath = System.IO.Path.Combine(webRoot, "conteudo\\");

                if(instituicao.Id != null) 
                {
                    foreach (var arquivo in Request.Form.Files)
                    {
                        if (arquivo.Length > 0)
                        {
                            instituicao.Imagem = ($"conteudo/{arquivo.Name}");
                            var imagem = $"{ filePath}{ arquivo.Name}";
                            using (var stream = new FileStream(imagem, System.IO.FileMode.Create))
                            {
                                await arquivo.CopyToAsync(stream);
                            }
                        }
                    }
                    _context.instituicao.Update(instituicao);
                } else
                {
                    foreach (var arquivo in Request.Form.Files)
                    {
                        if (arquivo.Length > 0)
                        {
                            instituicao.Imagem = ($"conteudo/{arquivo.Name}");
                            var imagem = $"{ filePath}{ arquivo.Name}";
                            using (var stream = new FileStream(imagem, System.IO.FileMode.Create))
                            {
                                await arquivo.CopyToAsync(stream);
                            }
                        }
                    }
                    _context.instituicao.Add(instituicao);
                }            
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

        // POST: api/Instituicao
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Instituicao/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [EnableCors("MyPolicy")]
        public ReturnModel DeleteCarroModel([FromRoute] int id)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                var instituicao = _context.instituicao.Where(e => e.Id == id).First();
                //var carroModel = await _context.carro.FindAsync(id);
                _context.instituicao.Remove(instituicao);
                _context.SaveChanges();
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Success = false;
            }

            return result;
        }
    }
}
