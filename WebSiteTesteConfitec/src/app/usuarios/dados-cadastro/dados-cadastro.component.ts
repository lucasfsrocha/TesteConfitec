import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UsuariosService } from '../service/usuarios.service';
import { Usuarios } from '../model/usuarios';

@Component({
  selector: 'app-dados-cadastro',
  templateUrl: './dados-cadastro.component.html',
  styleUrls: ['./dados-cadastro.component.css']
})
export class DadosCadastroComponent implements OnInit {

  submitted = false;
  usuarioForm: any;
  usuario: Usuarios;

  constructor(private formBuilder: FormBuilder,
              private toastr: ToastrService,
              private userService: UsuariosService,
              private router: Router) { }

  ngOnInit(): void {
    this.usuarioForm = this.formBuilder.group({
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      email: ['', Validators.required],
      datanascimento: ['', Validators.required],
      escolaridade: ['', Validators.required]
    });
  }

  onSubmit() {
    debugger;
    this.submitted = true;
    if (this.usuarioForm.invalid) {
      this.toastr.success('Erro');
      return;
    }

    this.usuario = new Usuarios();

    this.usuario.Nome = this.usuarioForm.value.nome;
    this.usuario.Sobrenome = this.usuarioForm.value.sobrenome;
    this.usuario.Email = this.usuarioForm.value.email;
    this.usuario.DataNascimento = this.usuarioForm.value.datanascimento;
    this.usuario.Escolaridade = this.usuarioForm.value.escolaridade;

    this.userService.adicionar(this.usuario).subscribe(data => {
      if (data.status === 'OK'){
        this.toastr.success('Usuário inserido com sucesso: ' + this.usuario.Nome + ' ' + this.usuario.Sobrenome);
        this.router.navigate(['usuarios']);
      }
      else {
        this.toastr.error('Erro ao inserir o usuário ' + this.usuario.Nome + ' ' + this.usuario.Sobrenome);
      }
    });
  }

  Cancelar() {
    this.router.navigate(['usuarios']);
  }

}
