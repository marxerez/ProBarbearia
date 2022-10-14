import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


@Injectable({
  providedIn: 'root'
})

export class AutenticacaoGuard implements CanActivate {

  constructor(private router: Router, private toaster: ToastrService) { }

  canActivate(): boolean {

    if (localStorage.getItem('user') !== null)
    return true;

    if (this.router.url == '/usuario/logar' || this.router.url == '/')
      this.router.navigate(['usuario/logar']);



    this.toaster.info('Usuário não autenticado!');

    return false;
  }



}
