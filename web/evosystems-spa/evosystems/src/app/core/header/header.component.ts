import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DepartamentoFormComponent } from '../../components/departamento/departamento-form/departamento-form.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  constructor(public dialog: MatDialog) {}

  addDepartamento() {
    const dialogRef = this.dialog.open(DepartamentoFormComponent, {
      width: '700px',
    });

    dialogRef.afterClosed().subscribe((result) => {});
  }
}
