using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TesteUpload.Model;

namespace TesteUpload.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly UP7WebApiContext _context;
        private readonly IHostingEnvironment _env;

        public IHostingEnvironment Env => _env;

        public CarrosController(UP7WebApiContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET: api/Carros
        [HttpGet]
        [EnableCors("MyPolicy")]
        public async Task<ReturnModel> GetcarroAntigos()
        {
            ReturnModel result = new ReturnModel();
            var carro = _context.Carro.Include(a => a.Adicional).AsQueryable();

            result.Object = await carro.Select(p => new
            {
                p.Id,
                p.Marca,
                p.Modelo,
                p.Ano,
                p.Descricao,
                p.Preco,
                p.Cor,
                p.Quilometragem,
                p.Potencia,
                p.CarroAntigo,
                p.CarroSeminovo,
                p.Combustivel,
                p.Velocidade,
                p.Adicional,
                p.Portas,
                p.ImgBase64

            }).ToListAsync();


            result.Success = true;
            result.Message = "sucesso!!";
            return result;

        }

        // GET: api/Carros
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("antigos")]
        public async Task<ReturnModel> Getcarro()
        {
            ReturnModel result = new ReturnModel();
            var carro = _context.Carro.Where(x => x.CarroAntigo == true).Include(a => a.Adicional).AsQueryable();

            result.Object = await carro.Select(p => new
            {
                p.Id,
                p.Marca,
                p.Modelo,
                p.Ano,
                p.Descricao,
                p.Preco,
                p.Cor,
                p.Quilometragem,
                p.Potencia,
                p.CarroAntigo,
                p.CarroSeminovo,
                p.Combustivel,
                p.Velocidade,
                p.Portas,
                p.Adicional,
                p.ImgBase64

            }).ToListAsync();


            result.Success = true;
            result.Message = "sucesso!!";
            return result;

        }
        // GET: api/Carros
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("recentes")]
        public async Task<ReturnModel> GetNewcarro()
        {
            ReturnModel result = new ReturnModel();
            var carro = _context.Carro.OrderBy(d => d.DataCadastro).Include(a => a.Adicional).Take(10).AsQueryable();

            result.Object = await carro.Select(p => new
            {
                p.Id,
                p.Marca,
                p.Modelo,
                p.Ano,
                p.Descricao,
                p.Preco,
                p.Cor,
                p.Quilometragem,
                p.Potencia,
                p.CarroAntigo,
                p.CarroSeminovo,
                p.Combustivel,
                p.Velocidade,
                p.Portas,
                p.Adicional,
                p.ImgBase64

            }).ToListAsync();


            result.Success = true;
            result.Message = "sucesso!!";
            return result;

        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("buscarPorId/{id}")]
        public async Task<ReturnModel> Getcarro(int id)
        {
            ReturnModel result = new ReturnModel();
            var carro = _context.Carro.Where(x => x.Id == id).AsQueryable();

            result.Object = await carro.Include(x => x.Imagem).Include(a => a.Adicional).Select(p => new
            {
                p.Id,
                p.Marca,
                p.Modelo,
                p.Ano,
                p.Descricao,
                p.Preco,
                p.Cor,
                p.Quilometragem,
                p.Potencia,
                p.Portas,
                p.CarroAntigo,
                p.CarroSeminovo,
                p.Imagem,
                p.Combustivel,
                p.Velocidade,
                p.Adicional,
                p.ImgBase64

            }).FirstOrDefaultAsync();


            result.Success = true;
            result.Message = "sucesso!!";
            return result;

        }
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("seminovo")]
        public async Task<ReturnModel> GetcarroSeminovo()
        {
            ReturnModel result = new ReturnModel();
            var carro = _context.Carro.Where(x => x.CarroSeminovo == true).Include(a => a.Adicional).AsQueryable();

            result.Object = await carro.Select(p => new
            {
                p.Id,
                p.Marca,
                p.Modelo,
                p.Ano,
                p.Descricao,
                p.Preco,
                p.Cor,
                p.Quilometragem,
                p.Potencia,
                p.CarroAntigo,
                p.CarroSeminovo,
                p.Portas,
                p.Combustivel,
                p.Velocidade,
                p.Adicional,
                p.ImgBase64

            }).ToListAsync();


            result.Success = true;
            result.Message = "sucesso!!";
            return result;

        }


        // GET: api/Carros/5
        [HttpGet]
        [Route("{id}")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> GetCarroModel([FromRoute] int id)
        {
            ReturnModel result = new ReturnModel();
            var carro = _context.Carro.Include(x => x.Imagem).Include(a => a.Adicional).AsQueryable();
            result.Object = await carro.Select(p => new
            {
                p.Id,
                p.Marca,
                p.Modelo,
                p.Ano,
                p.Descricao,
                p.Preco,
                p.Cor,
                p.Quilometragem,
                p.Potencia,
                p.CarroAntigo,
                p.Portas,
                p.CarroSeminovo,
                p.Imagem,
                p.Combustivel,
                p.Velocidade,
                p.Cambio,
                p.Adicional,
                p.ImgBase64
            }).Where(p => p.Id == id).FirstOrDefaultAsync();

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


            return Ok(result);
        }



        [Produces("application/json")]
        [HttpPost, DisableRequestSizeLimit]
        [EnableCors("MyPolicy")]
        public IActionResult UploadFile()
        {
            try
            {
                CarroModel carro = new CarroModel();
                var carroImagem = new List<ImagemModel>();
                carro = JsonConvert.DeserializeObject<CarroModel>(Request.Form["carro"]);
                if (carro.Id == 0)
                {
                    foreach (var arquivo in Request.Form.Files)
                    {
                        if (arquivo.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                arquivo.CopyTo(ms);
                                var fileBytes = ms.ToArray();
                                carro.ImgBase64 = Convert.ToBase64String(fileBytes);

                                carro.Imagem = new List<ImagemModel>
                            {
                                new ImagemModel { ImgBase64 = Convert.ToBase64String(fileBytes) }
                            };
                            }
                        }
                        carro.DataCadastro = DateTime.Now;
                        _context.Carro.Add(carro);
                        _context.SaveChanges();
                    }
                }

                else
                {
                    foreach (var arquivo in Request.Form.Files)
                    {
                        if (arquivo.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                arquivo.CopyTo(ms);
                                var fileBytes = ms.ToArray();
                                carro.ImgBase64 = Convert.ToBase64String(fileBytes);

                                carro.Imagem = new List<ImagemModel>
                            {
                                new ImagemModel { ImgBase64 = Convert.ToBase64String(fileBytes) }
                            };
                            }
                        }
                    }
                    _context.Carro.Update(carro);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("sucess");
        }
        // DELETE: api/Carros/5
        [HttpDelete("{id}")]
        [EnableCors("MyPolicy")]
        public ReturnModel DeleteCarroModel([FromRoute] int id)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                var carro = _context.Carro.Where(e => e.Id == id).Include(x => x.Imagem).First();
                //var carroModel = await _context.carro.FindAsync(id);
                _context.Carro.Remove(carro);
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
