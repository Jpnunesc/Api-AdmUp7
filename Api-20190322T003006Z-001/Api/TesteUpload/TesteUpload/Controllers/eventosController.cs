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
    [Route("api/[controller]/")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class EventosController : ControllerBase
    {
        private readonly UP7WebApiContext _context;
        private readonly IHostingEnvironment _env;

        public EventosController(UP7WebApiContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/eventos
        [HttpGet]
        [EnableCors("MyPolicy")]
        public ReturnModel GetAll()
        {
            ReturnModel result = new ReturnModel();
            try
            {

                result.Object = _context.Eventos.OrderBy(x => x.DataCriacao).ToList();
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Success = false;
                throw ex;
            }
            return result;
        }

        // GET: api/eventos/5
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("{id}")]
        public ReturnModel GetAplicativo(int id)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                if(id != 0)
                {
                    result.Object = _context.Eventos.Where(x => x.Mes == id).ToList();

                } else
                {
                    result.Object = _context.Eventos.ToList();

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
        // GET: api/eventos/5
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("eventos/{id}")]
        public ReturnModel Get(int id)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                if (id != 0)
                {
                    result.Object = _context.Eventos.Where(x => x.Id == id).First();

                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                throw ex;
            }
            return result;
        }
        [HttpPost]
        [Route("mes")]
        [EnableCors("MyPolicy")]
        public ReturnModel BuscarPorMes([FromBody]int id)
        {
            ReturnModel result = new ReturnModel();
            try
            {
              
                result.Object =  _context.Eventos.Where(x => x.Mes == id).ToList();
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
        public async Task<IActionResult> UploadFile()
        {
            ReturnModel result = new ReturnModel();
            
            try
            {
                EventoModel evento = new EventoModel();
                evento = JsonConvert.DeserializeObject<EventoModel>(Request.Form["evento"]);
                var webRoot = _env.WebRootPath;
                var filePath = System.IO.Path.Combine(webRoot, "conteudo\\");

                if(evento.Id != 0)
                {
                    foreach (var arquivo in Request.Form.Files)
                    {
                        if (arquivo.Length > 0)
                        {
                            evento.Imagem = ($"conteudo/{arquivo.Name}");
                            var imagem = $"{ filePath}{ arquivo.Name}";
                            using (var stream = new FileStream(imagem, FileMode.Create))
                            {
                                await arquivo.CopyToAsync(stream);
                            }
                        }
                    }
                    _context.Eventos.Update(evento);
                } else
                {
                    foreach (var arquivo in Request.Form.Files)
                    {
                        if (arquivo.Length > 0)
                        {
                            evento.Imagem = ($"conteudo/{arquivo.Name}");
                            var imagem = $"{ filePath}{ arquivo.Name}";
                            using (var stream = new FileStream(imagem, FileMode.Create))
                            {
                                await arquivo.CopyToAsync(stream);
                            }
                        }
                    }
                    evento.DataCriacao = new DateTime();
                    _context.Eventos.Add(evento);
                }


                _context.SaveChanges();
                result.Message = "Dados salvos com sucesso!";

            }
            catch (Exception)
            {
                result.Message = "Erro, verifique se os dados estão corretos!";
                return Ok(result);
               
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [EnableCors("MyPolicy")]
        public ReturnModel DeleteCarroModel([FromRoute] int id)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                var evento = _context.Eventos.Where(e => e.Id == id).First();
                //var carroModel = await _context.carro.FindAsync(id);
                _context.Eventos.Remove(evento);
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
