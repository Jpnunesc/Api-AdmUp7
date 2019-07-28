import { ImagemModel } from './ImagemModel';
import { AdicionalModel } from './adicionalModel';

export class CarroModel {
    id: number;
    marca: string;
    modelo: string;
    ano: string;
    preco: string;
    cor: string;
    quilometragem: string;
    potencia: string;
    descricao: string;
    cambio: string;
    velocidade: string;
    combustivel: string;
    carroAntigo = false;
    carroSeminovo = false;
    caminhoImgPrincipal: string;
    caminhoImagem: string;
    portas: string;

    Imagem: Array<ImagemModel>;
    adicional: Array<AdicionalModel>;

    constructor(values: Object = {}) {
      this.Imagem = new Array<ImagemModel>();
      this.adicional = new Array<AdicionalModel>();
      Object.assign(this, values);
    }
  }
