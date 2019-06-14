import { ImagemModel } from './ImagemModel';

export class CarroModel {
    id: number;
    marca: string;
    modelo: string;
    ano: string;
    preco: string;
    cor: string;
    quilometragem: string;
    potencia: string;
    paisOrigem: string;
    bancos: string;
    arCondicionado: string;
    vidros: string;
    freios: string;
    tracao: string;
    rodas: string;
    descricao: string;
    statusCarro: string;
    carroAntigo = false;
    carroSeminovo = false;
    caminhoImgPrincipal: string;
    caminhoImagem: string;

    Imagem: Array<ImagemModel>;

    constructor(values: Object = {}) {
      this.Imagem = new Array<ImagemModel>();
      Object.assign(this, values);
    }
  }
