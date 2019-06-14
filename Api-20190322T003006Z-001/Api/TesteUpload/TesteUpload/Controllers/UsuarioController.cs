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
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UP7WebApiContext _context;

        public UsuarioController(UP7WebApiContext context)
        {
            _context = context;
        }
        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        [HttpPost]
        [EnableCors("MyPolicy")]
        public ReturnModel Post([FromBody] UsuarioModel usuario)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                _context.usuarios.Add(usuario);
                _context.SaveChanges();
                result.Success = true;
                result.Message = "Cadastro realizado com sucesso";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Serviço indisponível tente mais tarde.";
                throw ex;
            }
            return result;
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
