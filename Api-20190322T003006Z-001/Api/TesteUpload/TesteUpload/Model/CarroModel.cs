using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteUpload.Model
{

    [Table("Carro")]
    public class CarroModel
    {
        public CarroModel()
        {
            Imagem = new List<ImagemModel>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Ano { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Descricao { get; set; }
        public string   Preco { get; set; }
        public string Cor { get; set; }
        public string Quilometragem { get; set; }
        public string Potencia { get; set; }
        public string PaisOrigem { get; set; }
        public string Bancos { get; set; }
        public string ArCondicionado { get; set; }
        public string Vidros { get; set; }
        public string Freios { get; set; }
        public string Tracao { get; set; }
        public string Rodas { get; set; }
        public string StatusCarro { get; set; }
        public bool? CarroAntigo  { get; set; }
        public bool? CarroSeminovo { get; set; }
        public string CaminhoImagem { get; set; }
        public string Velocidade { get; set; }
        public string Combustivel { get; set; }
        public string Cambio { get; set; }

        public virtual ICollection<ImagemModel> Imagem { get; set; }
    }
}

