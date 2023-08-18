import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DepartamentoService {
  BASE_URL: string = 'https://localhost:44372';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(private http: HttpClient) {}

  getDepartamentos(): Observable<[]> {
    return this.http.get<[]>(
      `${this.BASE_URL}/api/departamento`,
      this.httpOptions
    );
  }

  inserirDepartamento(departamento: any) {
    return this.http.post(
      `${this.BASE_URL}/api/departamento`,
      departamento,
      this.httpOptions
    );
  }

  atualizarDepartamento(Departamento: any) {
    return this.http.put(
      `${this.BASE_URL}/api/departamento`,
      Departamento,
      this.httpOptions
    );
  }

  deletarDepartamento(id: number) {
    console.log(`${this.BASE_URL}/api/Departamento?id=${id}`);
    return this.http.delete(
      `${this.BASE_URL}/api/Departamento?id=${id}`,
      this.httpOptions
    );
  }
}
