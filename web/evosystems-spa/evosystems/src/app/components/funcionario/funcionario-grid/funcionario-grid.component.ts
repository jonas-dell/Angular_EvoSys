import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MensagemService } from 'src/app/services/mensagem.service';
import { FuncionarioFormComponent } from '../funcionario-form/funcionario-form.component';
import { FuncionarioService } from 'src/app/services/funcionario.service';
import Swal from 'sweetalert2';

export interface Funcionario {
  id: number;
  nome: string;
  foto: string;
  rg: string;
  departamentoId: number;
}

@Component({
  selector: 'funcionario-grid',
  templateUrl: './funcionario-grid.component.html',
  styleUrls: ['./funcionario-grid.component.css'],
})
export class FuncionarioGridComponent implements OnInit {
  dataSource = new MatTableDataSource<[]>([]);
  displayedColumns: string[] = ['id', 'nome', 'foto', 'rg', 'acoes'];

  @Input() departamentoId!: number;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private funcionarioService: FuncionarioService,
    private dialog: MatDialog,
    private mensagemService: MensagemService
  ) {}

  ngOnInit() {
    this.funcionarioService
      .getFuncionariorPeloId(this.departamentoId)
      .subscribe((resp) => {
        this.dataSource.data = resp;
        console.log(this.dataSource.data);
      });
    this.mensagemService.receberMensagem().subscribe((departamentoId) => {
      if (departamentoId === this.departamentoId) {
        this.funcionarioService
          .getFuncionariorPeloId(this.departamentoId)
          .subscribe((resp) => {
            this.dataSource.data = resp;
          });
      }
    });
  }

  editar(e: any) {
    const dialogRef = this.dialog.open(FuncionarioFormComponent, {
      width: '700px',
      data: e,
    });
  }

  excluir(e: any) {
    this.funcionarioService.deletarFuncionario(e.id).subscribe((resp) => {
      Swal.fire({
        title: 'Atenção',
        text: 'Funcionário excluído com sucesso',
        icon: 'success',
      });
      this.mensagemService.enviarMensagem(this.departamentoId);
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
}
