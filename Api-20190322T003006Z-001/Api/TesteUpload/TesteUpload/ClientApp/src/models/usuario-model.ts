import { RifasModel } from './rifas-model';

export class UsuarioModel {
    id: any;
    usuario: string;
    senha: string;
    nome: string;
    telefone: number;
    rifa: RifasModel;
    codigoRifa: number;
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
