import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Agenda } from '../models/Agenda';
import { AgrupadoPorProfissionalHorario } from '../models/AgrupadoPorProfissionalHorario';
import { ProfissionalHorario } from '../models/ProfissionalHorario';
import { ProfissionalHorarioEditar } from '../models/ProfissionalHorarioEditar';

@Injectable({
  providedIn: 'root'
})
export class ProfissionalHorarioService {


  baseURL = "https://localhost:5001/api/ProfissionalHorario";
  constructor(private http: HttpClient) { }

  private _atualizaDados = new Subject<void>();

  get AtualizaDados(){
    return this._atualizaDados;
  }


  public CarregaProfissionalHorarios(agenda: Agenda,  gerenciaAgenda: Boolean, mudaModoExibicao: string): Observable<AgrupadoPorProfissionalHorario[]> {


    let parametros = new HttpParams()
      .set('ProfissionalId', agenda.profissionalId)
      .set('ServicoId', agenda.servicoID)
      .set('EstabelecimentoId', agenda.estabelecimentoId)
      .set('DiaAgendado', agenda.diaAgendado)
      .set('DataAgendamento', agenda.dataAgendamento.toDateString())   //agenda.dataAgendamento.toDateString())
      .set('gerenciaAgenda', String(gerenciaAgenda))
      .set('modoExibicao', mudaModoExibicao);


    //console.log(parametros)

    return this.http.get<AgrupadoPorProfissionalHorario[]>(this.baseURL + '/pesquisa', { 'params': parametros });


  }


  public CarregaProfissionalHorariosEditar(profissionalId: number ): Observable<ProfissionalHorarioEditar[]>{
    return this.http.get<ProfissionalHorarioEditar[]>(this.baseURL + '/profissionalHorariosEditar?profissionalId=' + profissionalId);
  }

  public AdicionaProfissionalHorario(profissionalHorarioEditar: ProfissionalHorarioEditar): Observable<any> {

    return this.http.post(this.baseURL, profissionalHorarioEditar ).pipe(
      tap( () =>{
        this.AtualizaDados.next();
      }
      )
      );
  }
  public DeletaProfissionalHorario(id: number): Observable<any> {

    return this.http.delete(this.baseURL+ '/deleta?id=' + id).pipe(
      tap( () =>{
        this.AtualizaDados.next();
      }
      )
      );
  }

}
