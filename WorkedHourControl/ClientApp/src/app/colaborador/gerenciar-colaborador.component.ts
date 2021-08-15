import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ErroHandler } from '../error-handle.service';
import { EmployeeModel } from '../models/employee.model';
import { RestService } from '../rest.service';

@Component({
	selector: 'app-gerenciar-colaborador',
	templateUrl: './gerenciar-colaborador.component.html'
})
export class GerenciarColaboradorComponent implements OnInit {
	employee: any;
	loading = false;

	@Input() id;

	usuario = '';
	senha = '';
	nome = '';
	perfilId = 2;

	constructor(private restService: RestService, public activeModal: NgbActiveModal) {
	}

	ngOnInit() {
		if (this.id)
			this.get();
	}

	get() {
		this.loading = true;
		this.restService.get<any>('user?id=' + this.id).subscribe(result => {
			this.loading = false;
			this.carregarDadosUsuario(result);
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	carregarDadosUsuario(user) {
		this.usuario = user.username;
		this.nome = user.name;
		this.perfilId = user.profile.id;
	}

	salvar() {
		if (this.id)
			this.alterar();
		else
			this.incluir();
	}

	criarPayload(): EmployeeModel {
		var employee = new EmployeeModel();
		employee.username = this.usuario;
		employee.password = this.senha;
		employee.name = this.nome;
		employee.profile = this.perfilId;
		return employee;
	}

	incluir() {
		var employee = this.criarPayload();
		this.loading = true;
		this.restService.post<EmployeeModel[]>('user', employee).subscribe(result => {
			this.loading = false;
			this.activeModal.close('entity saved')
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	alterar() {
		var employee = this.criarPayload();
		employee.id = this.id;
		this.loading = true;
		this.restService.put<EmployeeModel[]>('user', employee).subscribe(result => {
			this.loading = false;
			this.activeModal.close('entity saved')
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}
}


