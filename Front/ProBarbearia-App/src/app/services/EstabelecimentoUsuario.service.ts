import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EstabelecimentoUsuarioService {

  baseURL = "https://localhost:5001/api/EstabelecimentoUsuario";

  constructor(private http: HttpClient) { }

  public AdicionaEstabelecimentoUsuario(estabelecimentoId: number): Observable<any> {

    return this.http.get(this.baseURL + '/adiciona?estabelecimentoId=' + estabelecimentoId).pipe(take(1));
  }

  public DeletaEstabelecimentoUsuario(estabelecimentoId: number): Observable<any> {

    return this.http.delete(this.baseURL + '/deleta?estabelecimentoId=' + estabelecimentoId).pipe(take(1));
  }

}
