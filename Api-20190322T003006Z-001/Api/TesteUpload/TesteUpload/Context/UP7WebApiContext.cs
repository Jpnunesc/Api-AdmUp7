using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteUpload.Model;

public class UP7WebApiContext : DbContext
{
    public UP7WebApiContext(DbContextOptions<UP7WebApiContext> options)
        : base(options)
    {
    }

    public DbSet<CarroModel> carro { get; set; }
    public DbSet<EventoModel> eventos { get; set; }
    public DbSet<ImagemModel> imagens { get; set; }
    public DbSet<InstituicaoModel> instituicao { get; set; }
    public DbSet<ParceiroModel> parceiros { get; set; }
    public DbSet<RifaModel> rifas { get; set; }
    public DbSet<UsuarioModel> usuarios { get; set; }
    public DbSet<CodigoModel> codigos { get; set; }
}


