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
        private readonly IHostingEnvironment _env;

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

                result.Object = _context.Parceiros.ToList();
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
        public ReturnModel GetAplicativo(int id)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                if (id != 0)
                {
                    result.Object = _context.Parceiros.Where(x => x.Id == id).First();

                }
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Success = false;
                throw ex;
            }
            return result;
        }


        [Produces("application/json")]
        [HttpPost, DisableRequestSizeLimit]
        [EnableCors("MyPolicy")]
        [Route("cadastro")]
        public ReturnModel UploadFile()
        {
            ReturnModel result = new ReturnModel();
            
            try
            {
                ParceiroModel parceiro = new ParceiroModel();
                parceiro = JsonConvert.DeserializeObject<ParceiroModel>(Request.Form["parceiro"]);
                var webRoot = _env.WebRootPath;
                var filePath = System.IO.Path.Combine(webRoot, "conteudo\\");

                if (parceiro.Id != 0)
                {
                    foreach (var arquivo in Request.Form.Files)
                    {
                        if (arquivo.Length > 0)
                        {
                            parceiro.Imagem = ($"conteudo/{arquivo.Name}");
                            var imagem = $"{ filePath}{ arquivo.Name}";
                            using (var stream = new FileStream(imagem, FileMode.Create))
                            {
                                arquivo.CopyToAsync(stream);
                            }
                        }
                    }
                    _context.Parceiros.Update(parceiro);
                } else
                {
                    foreach (var arquivo in Request.Form.Files)
                    {
                        if (arquivo.Length > 0)
                        {
                            parceiro.Imagem = ($"conteudo/{arquivo.Name}");
                            var imagem = $"{ filePath}{ arquivo.Name}";
                            using (var stream = new FileStream(imagem, FileMode.Create))
                            {
                                arquivo.CopyToAsync(stream);
                            }
                        }
                    }
                    _context.Parceiros.Add(parceiro);
                }
 
                _context.SaveChanges();
                result.Message = "Dados salvos com sucesso!";
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Erro, verifique se os dados estão corretos!";
                return result;

            }

            return result;
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [EnableCors("MyPolicy")]
        public ReturnModel DeleteCarroModel([FromRoute] int id)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                var parceiro = _context.Parceiros.Where(e => e.Id == id).First();
                //var carroModel = await _context.carro.FindAsync(id);
                _context.Parceiros.Remove(parceiro);
                _context.SaveChanges();
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }
    }
}
