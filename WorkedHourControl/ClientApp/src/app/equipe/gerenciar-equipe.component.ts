import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ErroHandler } from '../error-handle.service';
import { ItemSelectedModel } from '../models/item-selected.model';
import { TeamModel } from '../models/team.model';
import { RestService } from '../rest.service';

@Component({
	selector: 'app-gerenciar-equipe',
	templateUrl: './gerenciar-equipe.component.html'
})
export class GerenciarEquipeComponent implements OnInit {
	team: any;
	loading = false;
	employees: ItemSelectedModel[];

	@Input() id;

	constructor(private restService: RestService, public activeModal: NgbActiveModal) {
		this.team = new TeamModel();
	}

	ngOnInit() {
		this.buscarColaboradores();
	}

	buscarColaboradores() {
		this.loading = true;
		this.restService.get<any>('employee').subscribe(result => {
			this.carregarListaColaboradores(result);
			if (this.id)
				this.buscarEquipe();
			else
				this.loading = false;
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	carregarListaColaboradores(result) {
		this.employees = [];
		result.forEach(element => {
			this.employees.push(new ItemSelectedModel(element.id, element.name, false));
		});
	}

	buscarEquipe() {
		this.loading = true;
		this.restService.get<any>('team?id=' + this.id).subscribe(result => {
			this.loading = false;
			this.team = result;
			this.selecionarColaboradoresVinculadosAEquipe();
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	selecionarColaboradoresVinculadosAEquipe() {
		this.team.employees.forEach(element => {
			const colaborador = this.employees.find(x => x.id == element.id);
			if (colaborador)
				colaborador.selected = true;
		});
	}

	salvar() {
		this.team.employees = this.employees.filter(x => x.selected).map(x => x.id);
		if (this.id)
			this.alterar();
		else
			this.incluir();
	}

	incluir() {
		this.loading = true;
		this.restService.post<TeamModel[]>('team', this.team).subscribe(result => {
			this.loading = false;
			this.activeModal.close('entity saved')
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	alterar() {
		this.loading = true;
		this.restService.put<TeamModel[]>('team', this.team).subscribe(result => {
			this.loading = false;
			this.activeModal.close('entity saved')
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	selecionar(item) {
		const colaborador = this.employees.find(x => x.id == item);
		colaborador.selected = !colaborador.selected;
	}
}