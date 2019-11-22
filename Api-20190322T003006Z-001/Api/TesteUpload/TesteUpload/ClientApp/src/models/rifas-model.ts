export class RifasModel {

    id: string;
    descricao: string;
    titulo: string;
    imagem: string;
    preco: string;
    codigo: string;
    quantidade: number;
    status: string;
    imgBase64: string;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
