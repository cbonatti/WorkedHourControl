import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ErroHandler } from '../error-handle.service';
import { RestService } from '../rest.service';
import { GerenciarProjetoComponent } from './gerenciar-projeto.component';
import { LancamentosComponent } from './lancamentos.component';

@Component({
	selector: 'app-projeto',
	templateUrl: './projeto.component.html'
})
export class ProjetoComponent implements OnInit {
	projects: any;
	loading = false;

	constructor(private restService: RestService, private modalService: NgbModal) {
	}

	ngOnInit() {
		this.get();
	}

	get() {
		this.loading = true;
		this.restService.get<any>('project/list').subscribe(result => {
			this.projects = result;
			this.loading = false;
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	incluir() {
		const modalRef = this.modalService.open(GerenciarProjetoComponent).result.then((result) => {
			this.get();
		});
	}

	alterar(id) {
		const modalRef = this.modalService.open(GerenciarProjetoComponent);
		modalRef.componentInstance.id = id;
		modalRef.result.then((result) => {
			this.get();
		});
	}

	lancarHoras(item) {
		const modalRef = this.modalService.open(LancamentosComponent, { size: 'lg' });
		modalRef.componentInstance.id = item.id;
		modalRef.componentInstance.name = item.name;
	}
}
