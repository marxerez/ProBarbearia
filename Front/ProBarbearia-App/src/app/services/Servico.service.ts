import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Servico } from '../models/Servico';

@Injectable({
  providedIn: 'root'
})
export class ServicoService {

  baseURL = "https://localhost:5001/api/Servico";
constructor(private http: HttpClient) { }

public CarregaServicos(estabelecimentoId: number, profissionalId: number): Observable<Servico[]>{
  return this.http.get<Servico[]>(this.baseURL +'/servicos?estabelecimentoId= '+ estabelecimentoId +'&profissionalId='+ profissionalId).pipe(take(1));
}

public CarregaServicosNaoAssociado(estabelecimentoId: number, profissionalId: number): Observable<Servico[]>{
  return this.http.get<Servico[]>(this.baseURL +'/servicosNaoAssociado?estabelecimentoId= '+ estabelecimentoId +'&profissionalId='+ profissionalId).pipe(take(1));
}

}
