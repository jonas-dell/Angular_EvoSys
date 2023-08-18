import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { DepartamentoService } from 'src/app/services/departamento.service';
import { DepartamentoFormComponent } from '../departamento-form/departamento-form.component';
import { MensagemService } from 'src/app/services/mensagem.service';
import Swal from 'sweetalert2';
import { FuncionarioService } from 'src/app/services/funcionario.service';

export interface Departamento {
  id: number;
  nome: string;
  sigla: string;
}

@Component({
  selector: 'departamento-grid',
  templateUrl: './departamento-grid.component.html',
  styleUrls: ['./departamento-grid.component.css'],
})
export class DepartamentoGridComponent implements OnInit {
  dataSource = new MatTableDataSource<[]>([]);
  displayedColumns: string[] = ['id', 'nome', 'sigla', 'acoes'];
  @Input() departamentoId!: number;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private departamentoService: DepartamentoService,
    private funcionarioService: FuncionarioService,
    private dialog: MatDialog,
    private mensagemService: MensagemService
  ) {}

  ngOnInit() {
    this.departamentoService.getDepartamentos().subscribe((resp) => {
      this.dataSource.data = resp;
    });

    this.mensagemService.receberMensagem().subscribe((departamentoId) => {
      this.departamentoService.getDepartamentos().subscribe((resp) => {
        this.dataSource.data = resp;
      });
    });
  }

  editar(e: any) {
    const dialogRef = this.dialog.open(DepartamentoFormComponent, {
      width: '700px',
      data: e,
    });
  }

  excluir(e: any) {
    this.funcionarioService
      .getFuncionariorPeloId(e.id)
      .subscribe((funcionarios) => {
        if (funcionarios.length > 0) {
          Swal.fire({
            title: 'Atenção',
            text: 'Não é possível excluir o departamento pois possui funcionários associados',
            icon: 'warning',
          });
        } else {
          this.departamentoService
            .deletarDepartamento(e.id)
            .subscribe((resp) => {
              Swal.fire({
                title: 'Atenção',
                text: 'Departamento excluído com sucesso',
                icon: 'success',
              });
              this.mensagemService.enviarMensagem(0);
            });
        }
      });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
}
