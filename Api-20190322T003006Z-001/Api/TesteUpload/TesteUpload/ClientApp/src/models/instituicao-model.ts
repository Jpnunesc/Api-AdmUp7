export class InstituicaoModel {
    id: number;
    descricao: string;
    imagem: string;
    nome: string;

constructor(values: Object = {}) {
     Object.assign(this, values);
      }
}