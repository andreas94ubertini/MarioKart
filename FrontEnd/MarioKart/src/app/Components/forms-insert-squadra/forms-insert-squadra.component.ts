import { Component } from '@angular/core';
import {SquadraService} from "../../Services/squadra.service";
import {Squadra} from "../../Models/squadra";

@Component({
  selector: 'app-forms-insert-squadra',
  templateUrl: './forms-insert-squadra.component.html',
  styleUrl: './forms-insert-squadra.component.css'
})
export class FormsInsertSquadraComponent {
  Nom?:string;
  NomSquad?:string
  constructor(private squadraSvc: SquadraService) {
  }

  SaveSquad(){
    if(this.squadraSvc.CheckIfExists(this.NomSquad) && this.Nom?.trim() != "" && this.NomSquad?.trim() != "") {
      this.squadraSvc.InsertSquad(new Squadra(this.Nom, this.NomSquad));
      this.Nom = "";
      this.NomSquad = "";
    }

  }
}
