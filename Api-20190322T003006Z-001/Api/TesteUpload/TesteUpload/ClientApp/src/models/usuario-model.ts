export class UsuarioModel {

usuario: string;
senha: string;
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
