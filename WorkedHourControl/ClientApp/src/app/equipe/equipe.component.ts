import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ErroHandler } from '../error-handle.service';
import { RestService } from '../rest.service';
import { GerenciarEquipeComponent } from './gerenciar-equipe.component';

@Component({
	selector: 'app-equipe',
	templateUrl: './equipe.component.html'
})
export class EquipeComponent implements OnInit {
	teams: any;
	loading = false;

	constructor(private restService: RestService, private modalService: NgbModal) {
	}

	ngOnInit() {
		this.get();
	}

	get() {
		this.loading = true;
		this.restService.get<any>('team/list').subscribe(result => {
			this.teams = result;
			this.loading = false;
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	incluir() {
		const modalRef = this.modalService.open(GerenciarEquipeComponent).result.then((result) => {
			this.get();
		});
	}

	alterar(id) {
		const modalRef = this.modalService.open(GerenciarEquipeComponent);
		modalRef.componentInstance.id = id;
		modalRef.result.then((result) => {
			this.get();
		});
	}
}
