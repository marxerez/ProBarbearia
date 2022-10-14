import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { take } from 'rxjs/operators';
import { Estabelecimento } from '../models/Estabelecimento';

@Injectable({
  providedIn: 'root'
})
export class EstabelecimentoService {

  //ReplaySubject reproduz valores antigos para novos assinantes quando eles se inscrevem pela primeira vez.
  //Replica o objeto Usuario para os novos subscribers(assinantes)
  private estabelecimentoFonte = new ReplaySubject<Estabelecimento | null>(1);
  public estabelecimentoAtual$ = this.estabelecimentoFonte.asObservable();
  baseURL = "https://localhost:5001/api/Estabelecimento";

  constructor(private http: HttpClient) { }

  public CarregaEstabelecimentosPorUsuario(): Observable<Estabelecimento[]> {
    return this.http.get<Estabelecimento[]>(`${this.baseURL}`).pipe(take(1));
  }

  public defineEstabelecimentoAtual(estabelecimento: Estabelecimento): void {
    localStorage.setItem('estabelecimento', JSON.stringify(estabelecimento));
    console.log("observer");
    console.log(estabelecimento);
    this.estabelecimentoFonte.next(estabelecimento);
  }

  // public verificaEstabelecimento(): void {
  //   let estabelecimentoAtual: Estabelecimento | null;
  //   this.estabelecimentoAtual$.pipe(take(1)).subscribe(estabelecimento => {

  //     estabelecimentoAtual = estabelecimento

  //     if (estabelecimentoAtual)
  //       this.defineEstabelecimentoAtual(estabelecimentoAtual);

  //   });
  // }
  logout(): void {
    localStorage.removeItem('user');
    this.estabelecimentoFonte.next(null) ;
   // this.usuarioAtualFonte.complete();
  }
  public CarregaEstabelecimentoNaoRegistrado(nome: string, estadoId: number,cidadeId: number): Observable<Estabelecimento[]>{
     return this.http.get<Estabelecimento[]>(this.baseURL + '/pesquisa?nome=' + nome+'&estadoId='+ estadoId +'&cidadeId='+ cidadeId);
  }


}
