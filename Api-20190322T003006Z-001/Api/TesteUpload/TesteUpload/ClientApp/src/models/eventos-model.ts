export class EventoModel {
    id: number;
    descricao: string;
    imagem: string;
    mes: number;
    titulo: string;
    local: string;
    imgBase64: string;
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
