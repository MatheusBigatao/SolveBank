import { ContaBancaria } from "../../ContaBancaria/ContaBancaria";
import { WebToken } from "../../WebToken/WebToken";

export class responseExibirUsuarioDTO {
    id: string = "";
    nomeCompleto: string = "";
    email: string = "";
    cpf_cnpj: string = "";
    enumTipoUsuario: number = 0;
    contaBancarias: ContaBancaria[] = [];
    dataCadastro: Date = new Date();
    removido:boolean = false;
    WebToken:WebToken = new WebToken();
}