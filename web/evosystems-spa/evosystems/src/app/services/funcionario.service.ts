import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FuncionarioService {
  BASE_URL: string = 'https://localhost:44372';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(private http: HttpClient) {}

  getFuncionariorPeloId(departamentoId: number): Observable<[]> {
    return this.http.get<[]>(
      `${this.BASE_URL}/api/Funcionario/GetFuncionarioPeloDepartamentoId?departamentoId=${departamentoId}`
    );
  }

  getFuncionarios(): Observable<[]> {
    return this.http.get<[]>(`${this.BASE_URL}/api/funcionario/getFuncionario`);
  }

  inserirFuncionario(funcionario: any) {
    return this.http.post(
      `${this.BASE_URL}/api/funcionario/createFuncionario`,
      funcionario
    );
  }

  atualizarFuncionario(funcionario: any) {
    return this.http.put(
      `${this.BASE_URL}/api/funcionario/updateFuncionario`,
      funcionario
    );
  }

  deletarFuncionario(id: number) {
    return this.http.delete(
      `${this.BASE_URL}/api/funcionario/deleteFuncionario?id=${id}`
    );
  }
}
