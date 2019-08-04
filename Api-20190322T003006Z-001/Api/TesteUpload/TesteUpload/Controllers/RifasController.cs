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
    public class RifasController : ControllerBase
    {
        private readonly UP7WebApiContext _context;
        private readonly IHostingEnvironment _env;

        public RifasController(UP7WebApiContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET: api/Rifas
        [HttpGet]
        [EnableCors("MyPolicy")]
        public  async Task<ReturnModel> Get()
        {
            ReturnModel result = new ReturnModel();
            try
            {
                result.Object = _context.Rifas.Where(x => x.QuantidadaRestante > 1).ToList();
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Success = false;
                throw ex;
            }

            return await Task.Run(() => result);
        }

      // GET: api/Rifas/5
        [EnableCors("MyPolicy")]
        [HttpGet("{id}")]
        public async Task<ReturnModel> Get([FromRoute] int id)
        {
            ReturnModel result = new ReturnModel
            {
                Object = _context.Rifas.Where(x => x.Id == id).FirstOrDefault()
            };

            if (result.Object != null)
            {
                result.Success = true;
                result.Message = "sucesso!!";

            }
            else
            {
                result.Success = false;
                result.Message = "erro!!";
            }

            return await Task.Run(() => result);
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
                RifaModel rifa = new RifaModel();
                rifa = JsonConvert.DeserializeObject<RifaModel>(Request.Form["rifa"]);
                var webRoot = _env.WebRootPath;
                var filePath = System.IO.Path.Combine(webRoot, "conteudo\\");
                if (rifa.Id != 0)
                {
                    foreach (var arquivo in Request.Form.Files)
                    {
                        if (arquivo.Length > 0)
                        {
                            rifa.Imagem = ($"conteudo/{arquivo.FileName}");
                            var imagem = $"{ filePath}{ arquivo.FileName}";
                            using (var stream = new FileStream(imagem, FileMode.Create))
                            {
                                await arquivo.CopyToAsync(stream);
                            }
                        }
                    }
                    _context.Rifas.Update(rifa);
                } else
                {
                    rifa.QuantidadaRestante = rifa.Quantidade;
                    rifa.QuantidadePendente = rifa.Quantidade;
                    foreach (var arquivo in Request.Form.Files)
                    {
                        if (arquivo.Length > 0)
                        {
                            rifa.Imagem = ($"conteudo/{arquivo.FileName}");
                            var imagem = $"{ filePath}{ arquivo.FileName}";
                            using (var stream = new FileStream(imagem, FileMode.Create))
                            {
                                await arquivo.CopyToAsync(stream);
                            }
                        }
                    }
                    _context.Rifas.Add(rifa);
                    _context.SaveChanges();
                    CadastraCodigo(rifa);
                }
                result.Message = "Dados salvos com sucesso!";

            }
            catch (Exception)
            {
                result.Message = "Erro, verifique se os dados estão corretos!";
                return Ok(result);

            }

            return Ok(result);
        }
        public void CadastraCodigo(RifaModel rifa)
        {
            int num = 1;
            List<CodigoModel> codigos = new List<CodigoModel>();
            for (int i = 0; i < rifa.Quantidade; i ++)
            {
                CodigoModel codigo = new CodigoModel
                {
                    Ativo = false,
                    IdRifa = rifa.Id,
                    Numero = i + num
                };
                codigos.Add(codigo);
            }
            _context.Codigos.AddRange(codigos);
            _context.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [EnableCors("MyPolicy")]
        public ReturnModel DeleteCarroModel([FromRoute] int id)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                var rifa = _context.Rifas.Where(e => e.Id == id).First();
                var usuarios = _context.Usuarios.Where(x => x.IdRifa == rifa.Id).ToList();
                var codigo = _context.Codigos.Where(x => x.IdRifa == rifa.Id).ToList();
                if(usuarios != null)
                {
                    _context.Usuarios.RemoveRange(usuarios);
                }
                _context.Codigos.RemoveRange(codigo);
                _context.Rifas.Remove(rifa);
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
