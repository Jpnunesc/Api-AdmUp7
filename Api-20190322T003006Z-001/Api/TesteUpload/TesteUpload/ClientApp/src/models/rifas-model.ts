export class RifasModel {

    id: string;
    descricao: string;
    imagem: string;
    preco: string;
    quantidade: number;
    status: string;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
