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
        private readonly IHostingEnvironment _env;

        public IHostingEnvironment Env => _env;

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

                result.Object = _context.Instituicao.ToList();
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
        public IActionResult UploadFile()
        {
            ReturnModel result = new ReturnModel();

            try
            {
                InstituicaoModel instituicao = new InstituicaoModel();
                instituicao = JsonConvert.DeserializeObject<InstituicaoModel>(Request.Form["instituicao"]);

                if (instituicao.Id != 0)
                {
                    foreach (var arquivo in Request.Form.Files)
                    {
                        if (arquivo.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                arquivo.CopyTo(ms);
                                var fileBytes = ms.ToArray();
                                instituicao.ImgBase64 = Convert.ToBase64String(fileBytes);
                            }
                        }
                    }
                    _context.Instituicao.Update(instituicao);
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
                                instituicao.ImgBase64 = Convert.ToBase64String(fileBytes);
                            }
                        }
                    }
                    _context.Instituicao.Add(instituicao);
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [EnableCors("MyPolicy")]
        public ReturnModel DeleteCarroModel([FromRoute] int id)
        {
            ReturnModel result = new ReturnModel();
            try
            {
                var instituicao = _context.Instituicao.Where(e => e.Id == id).First();
                //var carroModel = await _context.carro.FindAsync(id);
                _context.Instituicao.Remove(instituicao);
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
