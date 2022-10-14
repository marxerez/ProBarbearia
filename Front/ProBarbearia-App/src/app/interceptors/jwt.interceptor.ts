import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, take } from 'rxjs/operators';
import { Usuario } from '../models/identity/Usuario';
import { UsuarioService } from '../services/usuario.service';
import { EstabelecimentoService } from '../services/Estabelecimento.service';
import { Estabelecimento } from '../models/Estabelecimento';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private usuarioservico: UsuarioService,
    private estabelecimentoServico: EstabelecimentoService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    let usuarioAtual: Usuario | null;
    let estabelecimentoAtual: Estabelecimento | null;

    this.usuarioservico.usuarioAtual$.pipe(take(1)).subscribe(user => {
      usuarioAtual = user

      if (usuarioAtual) {
        request = request.clone({
            setHeaders: {
              Authorization: `Bearer ${usuarioAtual.token}`
            }
          }
        );
      }
    });
    this.estabelecimentoServico.estabelecimentoAtual$.pipe(take(1)).subscribe(estabelecimento => {
      estabelecimentoAtual = estabelecimento
    });

    return next.handle(request).pipe(
      catchError(error => {
        if (error) {

          //habilitar após os testes
          localStorage.removeItem('user');
          localStorage.removeItem('estabelecimento');
        }
        return throwError(error);
      })
    );
  }
}
