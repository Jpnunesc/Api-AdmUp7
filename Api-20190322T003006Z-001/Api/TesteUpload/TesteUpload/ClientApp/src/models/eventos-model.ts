export class EventoModel {
    id: number;
    descricao: string;
    imagem: string;
    mes: number;

constructor(values: Object = {}) {
     Object.assign(this, values);
      }
}
