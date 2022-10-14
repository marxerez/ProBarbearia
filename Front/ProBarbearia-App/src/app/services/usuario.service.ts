import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuario } from '../models/identity/Usuario';
import { map, take } from 'rxjs/operators';
import { UsuarioAgenda } from '../models/identity/UsuarioAgenda';

@Injectable()
export class UsuarioService {
  //ReplaySubject reproduz valores antigos para novos assinantes quando eles se inscrevem pela primeira vez.
  //Replica o objeto Usuario para os novos subscribers(assinantes)
  private usuarioAtualFonte = new ReplaySubject<Usuario | null>(1);
  public usuarioAtual$ = this.usuarioAtualFonte.asObservable();


  baseUrl = environment.apiURL + 'api/Usuario/';

  constructor(private http: HttpClient) { }

  public logar(model: any): Observable<void> {
    return this.http.post<Usuario>(this.baseUrl + 'logar', model).pipe(
      take(1),
      map((response: Usuario) => {
        const user = response;
        if (user) {
          this.defineUsuarioAtual(user)
        }
      })
    );
  }

  usuarioLogado(): Observable<Usuario> {
    return this.http.get<Usuario>(this.baseUrl + 'UsuarioLogado').pipe(take(1));
  }

  usuarioProfissionalId(usuarioId: Number): Observable<Usuario> {
    return this.http.get<Usuario>(this.baseUrl + 'usuarioProfissionalId?usuarioId=' + usuarioId).pipe(take(1));
  }


  atualizaUsuario(model: Usuario): Observable<void> {
    return this.http.put<Usuario>(this.baseUrl + 'AtualizaUsuario', model).pipe(
      take(1),
      map((user: Usuario) => {
        this.defineUsuarioAtual(user as any);
      }
      )
    )
  }

  public registrar(model: any): Observable<void> {
    return this.http.post<Usuario>(this.baseUrl + 'registrar', model).pipe(
      take(1),
      map((response: Usuario) => {
        const user = response;
        if (user) {
          this.defineUsuarioAtual(user)
        }
      })
    );
  }

  logout(): void {
    localStorage.removeItem('user');
    this.usuarioAtualFonte.next(null);
    // this.usuarioAtualFonte.complete();
  }

  public defineUsuarioAtual(user: Usuario): void {
    localStorage.setItem('user', JSON.stringify(user));
    this.usuarioAtualFonte.next(user);
  }


  public CarregaUsuariosPorNome(nomeUsuario: string): Observable<UsuarioAgenda[]> {
    return this.http.get<UsuarioAgenda[]>(this.baseUrl + 'ListaUsuarios?nomeUsuario=' + nomeUsuario).pipe(take(1));
  }


}
