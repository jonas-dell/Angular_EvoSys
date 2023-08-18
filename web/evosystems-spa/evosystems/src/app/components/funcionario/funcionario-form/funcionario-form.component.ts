import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { FuncionarioService } from 'src/app/services/funcionario.service';
import { MensagemService } from 'src/app/services/mensagem.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'funcionario-form',
  templateUrl: './funcionario-form.component.html',
  styleUrls: ['./funcionario-form.component.css'],
})
export class FuncionarioFormComponent implements OnInit {
  public funcionarioForm!: FormGroup;
  dataSource = new MatTableDataSource<[]>([]);

  constructor(
    private fb: FormBuilder,
    private service: FuncionarioService,
    private mensagemService: MensagemService,
    private dialog: MatDialog,
    public dialogRef: MatDialogRef<FuncionarioFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.funcionarioForm = this.fb.group({
      id: [null],
      nome: ['', Validators.required],
      foto: ['', Validators.required],
      rg: ['', Validators.required],
      departamentoId: [null],
    });

    if (this.data !== null) {
      this.funcionarioForm.patchValue({
        id: this.data.id,
        nome: this.data.nome,
        foto: this.data.foto,
        rg: this.data.rg,
        departamentoId: this.data.departamentoId,
      });
    }
  }

  salvar() {
    this.funcionarioForm.value.departamentoId = this.data.departamentoId;
    if (this.funcionarioForm.value.id == null) {
      this.service
        .inserirFuncionario(this.funcionarioForm.value)
        .subscribe((resp) => {
          this.dialogRef.close();
          Swal.fire({
            title: 'Atenção',
            text: 'Funcionário salvo com sucesso',
            icon: 'success',
          });
          this.mensagemService.enviarMensagem(
            this.funcionarioForm.value.departamentoId
          );
        });
    } else {
      this.service
        .atualizarFuncionario(this.funcionarioForm.value)
        .subscribe((resp) => {
          this.dialogRef.close();
          Swal.fire({
            title: 'Atenção',
            text: 'Funcionário atualizado com sucesso',
            icon: 'success',
          });
          this.mensagemService.enviarMensagem(
            this.funcionarioForm.value.departamentoId
          );
        });
    }
  }

  cancel(): void {
    this.dialogRef.close();
  }
}
