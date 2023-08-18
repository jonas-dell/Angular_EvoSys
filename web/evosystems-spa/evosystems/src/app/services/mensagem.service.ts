import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class MensagemService {
  private mensagem = new Subject<number>();

  enviarMensagem(departamentoId: number) {
    this.mensagem.next(departamentoId);
  }

  receberMensagem(): Observable<number> {
    return this.mensagem.asObservable();
  }
}
