import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Estado } from '../models/Estado';

@Injectable({
  providedIn: 'root'
})
export class EstadoService {

  baseURL= "https://localhost:5001/api/Estado";
constructor(private http: HttpClient) { }

public CarregaEstados(): Observable<Estado[]>{
  return this.http.get<Estado[]>(`${this.baseURL}`).pipe(take(1));
}


}


