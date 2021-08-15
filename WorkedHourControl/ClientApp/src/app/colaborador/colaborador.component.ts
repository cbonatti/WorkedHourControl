import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from '../auth.service';
import { ErroHandler } from '../error-handle.service';
import { RestService } from '../rest.service';
import { GerenciarColaboradorComponent } from './gerenciar-colaborador.component';

@Component({
	selector: 'app-colaborador',
	templateUrl: './colaborador.component.html'
})
export class ColaboradorComponent implements OnInit {
	employees: any;
	loading = false;

	constructor(private restService: RestService, private modalService: NgbModal) {
	}

	ngOnInit() {
		this.get();
	}

	get() {
		this.loading = true;
		this.restService.get<any>('employee').subscribe(result => {
			this.employees = result;
			this.loading = false;
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	incluir() {
		const modalRef = this.modalService.open(GerenciarColaboradorComponent).result.then((result) => {
			this.get();
		});
	}

	alterar(id) {
		const modalRef = this.modalService.open(GerenciarColaboradorComponent);
		modalRef.componentInstance.id = id;
		modalRef.result.then((result) => {
			this.get();
		});
	}
}