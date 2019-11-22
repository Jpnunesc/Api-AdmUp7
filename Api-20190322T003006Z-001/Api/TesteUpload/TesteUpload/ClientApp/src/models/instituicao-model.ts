export class InstituicaoModel {
    id: number;
    descricao: string;
    imagem: string;
    nome: string;
    imgBase64: string;

constructor(values: Object = {}) {
     Object.assign(this, values);
      }
}