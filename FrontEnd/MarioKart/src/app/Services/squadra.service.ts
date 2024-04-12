import { Injectable } from '@angular/core';
import {Squadra} from "../Models/squadra";

@Injectable({
  providedIn: 'root'
})
export class SquadraService {
  private SquadList: Squadra[] = new Array();
  constructor() {
    if(!localStorage.getItem("SquadList"))
      localStorage.setItem("SquadList", JSON.stringify(this.SquadList))
    else
      this.SquadList = JSON.parse(localStorage.getItem("SquadList")!);
  }

  setLocal(list: Squadra[]){
    localStorage.setItem("SquadList", JSON.stringify(list))
  }
  getLocal(){
    return this.SquadList = JSON.parse(localStorage.getItem("SquadList")!);
  }

  GetAllSquads() : Squadra[]{
    this.getLocal();
    return this.SquadList;
}

  InsertSquad(s:Squadra){
    this.SquadList.push(s);
    this.setLocal(this.SquadList);
  }
  ModifySquad(s:Squadra){
    this.SquadList.forEach(e=>{
      if(e.Cod == s.Cod)
        e=s;
    })
    this.setLocal(this.SquadList);
  }

}
