export class ImagemModel {
    id: number;
    imagem: File;
    imgBase64: string;
constructor(values: Object = {}) {
     Object.assign(this, values);
      }
}
