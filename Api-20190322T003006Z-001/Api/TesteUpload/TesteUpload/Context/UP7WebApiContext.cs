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

    public DbSet<CarroModel> Carro { get; set; }
    public DbSet<EventoModel> Eventos { get; set; }
    public DbSet<ImagemModel> Imagens { get; set; }
    public DbSet<InstituicaoModel> Instituicao { get; set; }
    public DbSet<ParceiroModel> Parceiros { get; set; }
    public DbSet<RifaModel> Rifas { get; set; }
    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<CodigoModel> Codigos { get; set; }
    public DbSet<AdicionalModel> Adicional { get; set; }
}


