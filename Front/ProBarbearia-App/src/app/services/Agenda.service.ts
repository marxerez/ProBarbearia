import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { take, tap } from 'rxjs/operators';
import { Agenda } from '../models/Agenda';
import { AgendaUsuario } from '../models/AgendaUsuario';
import { AgrupadoPorProfissionalHorario } from '../models/AgrupadoPorProfissionalHorario';

@Injectable({
  providedIn: 'root'
})
export class AgendaService {

  baseURL = "https://localhost:5001/api/Agenda";


  constructor(private http: HttpClient) { }

  private _atualizaDados = new Subject<void>();

  get AtualizaDados() {
    return this._atualizaDados;
  }


  public CarregaMinhaAgenda(estabelecimentoId: number): Observable<AgendaUsuario[]> {
    return this.http.get<AgendaUsuario[]>(this.baseURL + '/minhaAgenda?estabelecimentoId=' + estabelecimentoId).pipe(take(1));
  }

  public AdicionaAgenda(agenda: Agenda): Observable<any> {

    return this.http.post(this.baseURL, agenda).pipe(
      tap(() => {
        this.AtualizaDados.next();
      }
      )
    );
  }

  public DeletaAgendaUsuario(agendaId: number): Observable<any> {

    return this.http.delete(this.baseURL + '/deleta?agendaId=' + agendaId).pipe(
      tap(() => {
        this.AtualizaDados.next();
      }
      )
    );
  }

  // public AdicionaAgenda(agenda: Agenda): Observable<any> {

  //   return this.http.post(this.baseURL, agenda).pipe(take(1));
  // }

  // public DeletaAgendaUsuario(agendaId: number): Observable<any> {

  //   return this.http.delete(this.baseURL + '/deleta?agendaId=' + agendaId).pipe(take(1));
  // }



}
