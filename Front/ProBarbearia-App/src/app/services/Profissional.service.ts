import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Profissional } from '../models/Profissional';
import { ServicoProfissional } from '../models/ServicoProfissional';

@Injectable({
  providedIn: 'root'
})
export class ProfissionalService {

  baseURL= "https://localhost:5001/api/Profissional";
constructor(private http: HttpClient) { }


public CarregaProfissionais(estabelecimentoId: number): Observable<Profissional[]>{
  return this.http.get<Profissional[]>(this.baseURL + '/profissionais?estabelecimentoId=' + estabelecimentoId);
}



}
