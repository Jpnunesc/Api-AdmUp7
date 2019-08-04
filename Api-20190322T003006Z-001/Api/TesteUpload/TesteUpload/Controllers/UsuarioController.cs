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
    public class UsuarioController : ControllerBase
    {
        private readonly UP7WebApiContext _context;

        public UsuarioController(UP7WebApiContext context)
        {
            _context = context;
        }
        // GET: api/Usuario/pendente
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("pendente")]
        public async Task<ReturnModel> GetPendente()
        {
            ReturnModel result = new ReturnModel();
            var usuario = _context.Usuarios.Where(x => x.Ativo == false).AsQueryable();

            result.Object = await usuario.Include(x => x.Rifa).Select(p => new
            {
                p.Id,
                p.Nome,
                p.Telefone,
                p.Rifa,
                p.CodigoRifa

            }).ToListAsync();


            result.Success = true;
            result.Message = "sucesso!!";
            return result;

        }
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("aprovado")]
        public async Task<ReturnModel> GetAprovados()
        {
            ReturnModel result = new ReturnModel();
            var usuario = _context.Usuarios.Where(x => x.Ativo == true).AsQueryable();

            result.Object = await usuario.Include(x => x.Rifa).Select(p => new
            {
                p.Id,
                p.Nome,
                p.Telefone,
                p.Rifa,
                p.CodigoRifa

            }).ToListAsync();


            result.Success = true;
            result.Message = "sucesso!!";
            return result;

        }
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("aprovado/{id}")]
        public async Task<ReturnModel> GetUsuarioAprovadosPorRifa(int id)
        {
            ReturnModel result = new ReturnModel();
            var usuario = _context.Usuarios.Where(x => x.Ativo == true && x.IdRifa == id).AsQueryable();

            result.Object = await usuario.Include(x => x.Rifa).Select(p => new
            {
                p.Id,
                p.Nome,
                p.Telefone,
                p.Estado,
                p.CodigoRifa

            }).ToListAsync();


            result.Success = true;
            result.Message = "sucesso!!";
            return result;

        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("ganhador")]
        public async Task<ReturnModel> GetGanhador()
        {
            ReturnModel result = new ReturnModel();
            var usuario = _context.Usuarios.Where(x => x.Ganhador == true).AsQueryable();

            result.Object = await usuario.Include(x => x.Rifa).Select(p => new
            {
                p.Id,
                p.Nome,
                p.Telefone,
                p.Rifa,
                p.CodigoRifa

            }).ToListAsync();


            result.Success = true;
            result.Message = "sucesso!!";
            return result;

        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("rifas/{id}")]
       public async Task<ReturnModel> GetUsuarioPorRifa(int id)
        {
            ReturnModel result = new ReturnModel();
            var usuario = _context.Usuarios.Where(x => x.IdRifa == id).AsQueryable();

            result.Object = await usuario.Include(x => x.Rifa).Select(p => new
            {
                p.Id,
                p.Nome,
                p.Telefone,
                p.Rifa,
                p.CodigoRifa

            }).ToListAsync();


            result.Success = true;
            result.Message = "sucesso!!";
            return result;

        }
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("atualizar")]
        public ReturnModel AtualizarRifas()
        {
            ReturnModel result = new ReturnModel();
            try
            {
                DateTime data =  DateTime.Now.AddDays(-3);

                var usuarios = _context.Usuarios.Where(e => e.Ativo == false).ToList();
                foreach (var item in usuarios)
                {
                    var rifa = _context.Rifas.Where(x => x.Id == item.IdRifa).FirstOrDefault();
                    if (item.dataOperacao < data)
                    {
                        rifa.QuantidadePendente += 1;
                        _context.Rifas.Update(rifa);
                        _context.Usuarios.Remove(item);
                    }
                }
                _context.SaveChanges();
                result.Success = true;
                result.Message = "Operação realizada com Sucesso!";

            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Error na operação!";
            }

            return result;
        }
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("aprovar/{id}")]
        public ReturnModel Aprovar(int id)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                var usuario = _context.Usuarios.Where(x => x.Id == id).Include(i => i.Rifa).FirstOrDefault();
                if (usuario.Rifa.QuantidadePendente > 0)
                {
                    usuario.Ativo = true;
                    usuario.Rifa.QuantidadaRestante = usuario.Rifa.QuantidadaRestante - 1;
                }
                _context.Update(usuario);
                _context.SaveChanges();
                result.Success = true;
                result.Message = "Operação realizada com sucesso!";
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Erro na operação!";
            }

            return result;
        }

        // POST: api/Usuario
        [HttpPost]
        [EnableCors("MyPolicy")]
        public ReturnModel Post([FromBody] UsuarioModel usuario)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                RifaModel rifa = new RifaModel();
                CodigoModel codigo = new CodigoModel();
                 rifa = _context.Rifas.Where(x => x.Id == usuario.IdRifa).FirstOrDefault();
                 codigo = _context.Codigos.Where(x => x.IdRifa == usuario.IdRifa && x.Ativo == false).FirstOrDefault();
                if(rifa.QuantidadePendente > 0 && codigo != null)
                {
                    usuario.dataOperacao = new DateTime();
                    usuario.Ativo = false;
                    usuario.Ganhador = false;
                    rifa.QuantidadePendente -= 1;
                    rifa.QuantidadaRestante -= 1;
                    usuario.CodigoRifa = codigo.Numero;
                    _context.Update(rifa);
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();
                    result.Success = true;
                    result.Message = "Cadastro realizado com sucesso";
                } else
                {
                    result.Message = "Operação não pode ser realizada nesse momento, favor tente mais tarde.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Serviço indisponível tente mais tarde.";
                throw ex;
            }
            return result;
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [EnableCors("MyPolicy")]
        public ReturnModel Delete([FromRoute] int id)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                var usuario = _context.Usuarios.Where(e => e.Id == id).First();
                var rifa = _context.Rifas.Where(x => x.Id == usuario.IdRifa).FirstOrDefault();
                if(usuario.Ativo == true)
                {
                    rifa.QuantidadaRestante += 1;
                    rifa.QuantidadePendente += 1;
                } else
                {
                    rifa.QuantidadePendente += 1;
                }
                _context.Rifas.Update(rifa);
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                result.Success = true;
                result.Message = "Operação realizada com Sucesso!";

            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Error na operação!";
            }

            return result;
        }
    }
}
