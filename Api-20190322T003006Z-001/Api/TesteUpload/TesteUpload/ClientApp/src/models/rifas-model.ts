export class RifasModel {

    id: string;
    descricao: string;
    imagem: string;
    preco: string;
    codigo: string;
    quantidade: number;
    status: string;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
