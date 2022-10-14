import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Cidade } from '../models/Cidade';

@Injectable({
  providedIn: 'root'
})
export class CidadeService {

  baseURL= "https://localhost:5001/api/Cidade";
constructor(private http: HttpClient) { }

public CarregaCidades(idEstado: number): Observable<Cidade[]>{
  return this.http.get<Cidade[]>(`${this.baseURL}/${idEstado}`).pipe(take(1));
}


}
