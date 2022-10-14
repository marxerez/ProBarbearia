import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { take, tap } from 'rxjs/operators';
import { ServicoProfissional } from '../models/ServicoProfissional';
import { ServicoProfissionalEditar } from '../models/ServicoProfissionalEditar';

@Injectable({
  providedIn: 'root'
})
export class ServicoProfissionalService {


  baseURL= "https://localhost:5001/api/ServicoProfissional";
constructor(private http: HttpClient) { }

private _atualizaDados = new Subject<void>();

get AtualizaDados(){
  return this._atualizaDados;
}

public CarregaServicoProfissionais(estabelecimentoId: number ,servicoId: number): Observable<ServicoProfissional[]>{
  return this.http.get<ServicoProfissional[]>(this.baseURL + '/servicoProfissionais?estabelecimentoId=' + estabelecimentoId+'&servicoId='+ servicoId );
}

public AdicionaServicoProfissional(servicoProfissionalEditar: ServicoProfissionalEditar): Observable<any> {

  return this.http.post(this.baseURL, servicoProfissionalEditar ).pipe(
    tap( () =>{
      this.AtualizaDados.next();
    }
    )
    );
}
public DeletaServicoProfissional(profissionalId: number ,servicoId: number): Observable<any> {

  return this.http.delete(this.baseURL+ '/deleta?profissionalId=' + profissionalId +'&servicoId='+ servicoId ).pipe(
    tap( () =>{
      this.AtualizaDados.next();
    }
    )
    );
}

}
