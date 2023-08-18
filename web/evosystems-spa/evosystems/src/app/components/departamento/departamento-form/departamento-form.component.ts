import {
  Component,
  Inject,
  OnInit,
  Output,
  EventEmitter,
  Optional,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DepartamentoService } from 'src/app/services/departamento.service';
import { MatDialog } from '@angular/material/dialog';
import { FuncionarioFormComponent } from '../../funcionario/funcionario-form/funcionario-form.component';
import { MensagemService } from 'src/app/services/mensagem.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'departamento-form',
  templateUrl: './departamento-form.component.html',
  styleUrls: ['./departamento-form.component.css'],
})
export class DepartamentoFormComponent implements OnInit {
  public departamentoForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private service: DepartamentoService,
    private mensagemService: MensagemService,
    private dialog: MatDialog,
    public dialogRef: MatDialogRef<DepartamentoFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.departamentoForm = this.fb.group({
      id: [null],
      nome: ['', Validators.required],
      sigla: ['', Validators.required],
    });

    if (this.data !== null) {
      this.departamentoForm.patchValue({
        id: this.data.id,
        nome: this.data.nome,
        sigla: this.data.sigla,
      });
    }
  }

  salvar() {
    if (this.departamentoForm.value.id == null) {
      this.service
        .inserirDepartamento(this.departamentoForm.value)
        .subscribe((resp) => {
          this.dialogRef.close();
          Swal.fire({
            title: 'Atenção',
            text: 'Departamento salvo com sucesso',
            icon: 'success',
          });
          this.mensagemService.enviarMensagem(0);
        });
    } else {
      this.service
        .atualizarDepartamento(this.departamentoForm.value)
        .subscribe((resp) => {
          this.dialogRef.close();
          Swal.fire({
            title: 'Atenção',
            text: 'Departamento atualizado com sucesso',
            icon: 'success',
          });
          this.mensagemService.enviarMensagem(0);
        });
    }
  }

  cancel(): void {
    this.dialogRef.close();
  }

  addFuncionario() {
    const dialogRef = this.dialog.open(FuncionarioFormComponent, {
      width: '700px',
      data: {
        departamentoId: this.departamentoForm.value.id,
      },
    });
    dialogRef.afterClosed().subscribe((result) => {});
  }
}
