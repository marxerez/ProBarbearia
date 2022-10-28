import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { take, tap } from 'rxjs/operators';
import { UsuarioNaoProfissional } from '../models/identity/UsuarioNaoProfissional';
import { Profissional } from '../models/Profissional';
import { ServicoProfissional } from '../models/ServicoProfissional';

@Injectable({
  providedIn: 'root'
})
export class ProfissionalService {

  baseURL= "https://localhost:5001/api/Profissional";
constructor(private http: HttpClient) { }

private _atualizaDados = new Subject<void>();

get AtualizaDados(){
  return this._atualizaDados;
}

public CarregaProfissionais(estabelecimentoId: number): Observable<Profissional[]>{
  return this.http.get<Profissional[]>(this.baseURL + '/profissionais?estabelecimentoId=' + estabelecimentoId);
}

public CarregaProfissionaisPorNome(estabelecimentoId: number, nomeProfissional: string): Observable<Profissional[]>{
  return this.http.get<Profissional[]>(this.baseURL + '/pesquisa?estabelecimentoId=' + estabelecimentoId +'&nomeProfissional='+ nomeProfissional);
}

public AdicionaProfissional(profissional: UsuarioNaoProfissional): Observable<any> {

  return this.http.post(this.baseURL,profissional).pipe(
    tap( () =>{
      this.AtualizaDados.next();
    }
    )
    );
}

public DeletaProfissional(estabelecimentoId: number, usuarioId: number): Observable<any> {

  return this.http.delete(this.baseURL+ '/deleta?estabelecimentoId=' + estabelecimentoId +'&usuarioId='+ usuarioId).pipe(
    tap( () =>{
      this.AtualizaDados.next();
    }
    )
    );
}


}
