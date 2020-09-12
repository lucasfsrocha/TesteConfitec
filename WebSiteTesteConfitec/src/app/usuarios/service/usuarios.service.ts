import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuarios } from '../model/usuarios';
import { OutUsuarios } from '../model/out-usuarios';

@Injectable({
  providedIn: 'root'
})

export class UsuariosService {
  constructor(private http: HttpClient) { }

  apiUrl: string = 'https://localhost:44333/usuarios/';

  adicionar(usuario: Usuarios): Observable<OutUsuarios>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<OutUsuarios>(`${this.apiUrl}Adicionar`, usuario, httpOptions);
  }

  editar(usuario: Usuarios): Observable<OutUsuarios>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<OutUsuarios>(`${this.apiUrl}Editar`, usuario, httpOptions);
  }

  excluir(id: number): Observable<OutUsuarios>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<OutUsuarios>(`${this.apiUrl}Excluir?id=` + id, httpOptions);
  }

  obterlista(): Observable<OutUsuarios>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<OutUsuarios>(`${this.apiUrl}ObterLista`, httpOptions);
  }

  obterporemail(email: string): Observable<OutUsuarios>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<OutUsuarios>(`${this.apiUrl}ObterPorEmail?email=` + email, httpOptions);
  }

  obterpornome(nome: string): Observable<OutUsuarios>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<OutUsuarios>(`${this.apiUrl}ObterPorNome?nome=` + nome, httpOptions);
  }

}
