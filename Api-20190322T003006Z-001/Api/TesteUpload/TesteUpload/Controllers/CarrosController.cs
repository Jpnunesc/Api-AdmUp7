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
    private IHostingEnvironment _env;

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
      var carro = _context.carro.AsQueryable();

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
        p.PaisOrigem,
        p.Bancos,
        p.ArCondicionado,
        p.Vidros,
        p.Freios,
        p.Tracao,
        p.Rodas,
        p.StatusCarro,
        p.CarroAntigo,
        p.CarroSeminovo,
        p.CaminhoImagem

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
      var carro = _context.carro.Where(x => x.CarroAntigo == true).AsQueryable();

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
        p.PaisOrigem,
        p.Bancos,
        p.ArCondicionado,
        p.Vidros,
        p.Freios,
        p.Tracao,
        p.Rodas,
        p.StatusCarro,
        p.CarroAntigo,
        p.CarroSeminovo,
        p.CaminhoImagem

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
      var carro = _context.carro.Where(x => x.Id == id).AsQueryable();

      result.Object = await carro.Include(x => x.Imagem).Select(p => new
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
        p.PaisOrigem,
        p.Bancos,
        p.ArCondicionado,
        p.Vidros,
        p.Freios,
        p.Tracao,
        p.Rodas,
        p.StatusCarro,
        p.CarroAntigo,
        p.CarroSeminovo,
        p.CaminhoImagem,
        p.Imagem

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
      var carro = _context.carro.Where(x => x.CarroSeminovo == true).AsQueryable();

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
        p.PaisOrigem,
        p.Bancos,
        p.ArCondicionado,
        p.Vidros,
        p.Freios,
        p.Tracao,
        p.Rodas,
        p.StatusCarro,
        p.CarroAntigo,
        p.CarroSeminovo,
        p.CaminhoImagem

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
      var carro = _context.carro.Include(x => x.Imagem).AsQueryable();
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
        p.PaisOrigem,
        p.Bancos,
        p.ArCondicionado,
        p.Vidros,
        p.Freios,
        p.Tracao,
        p.Rodas,
        p.StatusCarro,
        p.CarroAntigo,
        p.CarroSeminovo,
        p.CaminhoImagem,
        p.Imagem
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
    public async Task<IActionResult> UploadFile()
    {
      CarroModel carro = new CarroModel();
      try
      {
        var carroImagem = new List<ImagemModel>();
        carro = JsonConvert.DeserializeObject<CarroModel>(Request.Form["carro"]);
        var webRoot = _env.WebRootPath;
        var filePath = System.IO.Path.Combine(webRoot, "conteudo\\");
        if (carro.Id == null)
        {
          foreach (var arquivo in Request.Form.Files)
          {
            if (arquivo.Length > 0)
            {
              carro.Imagem.Add(new ImagemModel { Caminho = $"conteudo/{ arquivo.FileName}" });
              carro.CaminhoImagem = ($"conteudo/{arquivo.FileName}");
              var imagem = $"{ filePath}{ arquivo.FileName}";
              using (var stream = new FileStream(imagem, FileMode.Create))
              {
                await arquivo.CopyToAsync(stream);
              }
            }
          }
          _context.carro.Add(carro);
          _context.SaveChanges();

        }
        else
        {
          foreach (var arquivo in Request.Form.Files)
          {
            if (arquivo.Length > 0)
            {
              carro.Imagem = new List<ImagemModel>();
              carro.Imagem.Add(new ImagemModel { Caminho = $"conteudo/{ arquivo.FileName}" });
              carro.CaminhoImagem = ($"conteudo/{arquivo.FileName}");
              var imagem = $"{ filePath}{ arquivo.FileName}";
              using (var stream = new FileStream(imagem, FileMode.Create))
              {
                await arquivo.CopyToAsync(stream);
              }
            }
          }
          _context.carro.Update(carro);
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
    public async Task<IActionResult> DeleteCarroModel([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var carroModel = await _context.carro.FindAsync(id);
      if (carroModel == null)
      {
        return NotFound();
      }

      _context.carro.Remove(carroModel);
      await _context.SaveChangesAsync();

      return Ok(carroModel);
    }

    private bool CarroModelExists(int id)
    {
      return _context.carro.Any(e => e.Id == id);
    }
  }
}
