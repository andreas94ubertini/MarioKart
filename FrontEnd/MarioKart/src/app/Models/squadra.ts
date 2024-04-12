import {Personaggi} from "./personaggi";

export class Squadra {
    Nom: string|undefined;
    NomSquad: string|undefined;
    Cred: number|undefined;
    Cod: string|undefined;
    Pers: Personaggi[] = new Array();
    constructor(nome?:string,nomeSquadra?:string) {
      this.Nom = nome;
      this.NomSquad = nomeSquadra;
      this.Cred = 10;
      this.Cod = "SQ"+ new Date().getTime();
    }
}
