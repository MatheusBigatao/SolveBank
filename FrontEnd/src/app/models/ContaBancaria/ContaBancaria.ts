import { Atendimento } from "../Atendimento/Atendimento"
import { Cartao } from "../Cartao/Cartao"
import { Transacao } from "../Transacoes/Transacao"

export class ContaBancaria {

    Id: string = ""
    agencia: string = ""
    numero: number = 0
    saldo: number = 0
    limite: number = 0
    limiteUtilizado: number = 0
    transacoes: Transacao[] = []
    usuarioID: string = ""
    Cartoes: Cartao[] = []
    Atendimentos: Atendimento[] = []
    EnumCategoriaConta: number = 0
    Informacoes: string = ""
    removido: boolean = false

}