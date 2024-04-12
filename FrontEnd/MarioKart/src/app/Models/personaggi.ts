import {Squadra} from "./squadra";

export class Personaggi {
  Cos: string | undefined;
  Cod: string | undefined;
  Nom: string | undefined;
  Cat: string | undefined;
  Img: string | undefined;
  SquadRif: number | undefined;
  Squads: Squadra[] = new Array();
  constructor(Cos?: string,Cod?: string,Nom?: string,Cat?: string,Img?: string,SquadRif?: number) {
    this.Cos = Cos;
    this.Cod = Cod;
    this.Nom = Nom;
    this.Cat = Cat;
    this.Img = Img;
    this.SquadRif = SquadRif;

  }

}
