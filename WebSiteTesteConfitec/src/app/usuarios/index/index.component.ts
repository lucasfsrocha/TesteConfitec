import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ColDef, ColumnApi, GridApi, GridOptions } from 'ag-grid-community';
import { ToastrService } from 'ngx-toastr';
import { Usuarios } from '../model/usuarios';
import { UsuariosService } from '../service/usuarios.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
    public gridOptions: GridOptions;
    public rowData: any[];
    // public columnDefs: any[];

    public usuarios: Usuarios[];
    public columnDefs: ColDef[];
    private api: GridApi;
    private columnApi: ColumnApi;

    public mensagemTeste: any;

    constructor(private usuariosService: UsuariosService, private router: Router, private toastr: ToastrService) {
      this.gridOptions = ({
        defaultColDef: {
          width: 60,
          autoHeight: true,
          editable: false,
          filter: 'agTextColumnFilter',
          resizable: false
        },
        rowHeight: 100,
        maxColWidth: 300,
        minColWidth: 150,
        rowMultiSelectWithClick: false,
        rowSelection: 'single',
        pagination: true,
        paginationPageSize: 10
      } as GridOptions);

      this.columnDefs = this.createColumnDefs();
  }

  ngOnInit(): void {
    this.obterLista();
  }

  onGridReady(params): void {
    this.api = params.api;
    this.columnApi = params.columnApi;
    this.api.sizeColumnsToFit();
  }

  private createColumnDefs(): ColDef[] {
    return [
      { headerName: 'Id', field: 'id', hide: true },
      { headerName: 'Nome', field: 'nome', sortable: true, sort: 'asc' },
      { headerName: 'Sobrenome', field: 'sobrenome'},
      { headerName: 'Email', field: 'email' },
      { headerName: 'Dt Nasc', field: 'datanascimento' },
      { headerName: 'Escolaridade', field: 'escolaridade' }
    ];
  }

  adicionar(): void {
    this.router.navigate(['usuarios/dados-cadastro/adicionar']);
  }

  editar(): void {
    this.router.navigate(['usuarios/dados-cadastro/editar']);
  }

  excluir(): void {
    let selectedRows = this.api.getSelectedRows();

    if (selectedRows.length === 0) {
      this.toastr.error('Erro', 'Favor selecionar um usuário para excluir.');
      return;
    }
    else {
      this.usuariosService.excluir(selectedRows[0].id).subscribe(data => {
        if (data.status === 'OK'){
          this.obterLista();
          this.toastr.success('Usuário excluído com sucesso: ' + selectedRows[0].nome + ' ' + selectedRows[0].sobrenome);
        }
        else {
          this.toastr.error('Erro ao excluir o usuário ' + selectedRows[0].nome + ' ' + selectedRows[0].sobrenome);
        }
      });
    }
  }

  obterLista(): any {
    this.usuariosService.obterlista().subscribe(data => {
      if (data.status === 'OK'){
        this.rowData = data.listaUsuarios;
      }
      else {
        this.rowData = null;
        this.toastr.error('Erro ao obter lista');
      }
    });
  }

}
