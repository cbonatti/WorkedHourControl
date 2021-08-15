import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ErroHandler } from '../error-handle.service';
import { ItemSelectedModel } from '../models/item-selected.model';
import { ProjectModel } from '../models/project.model';
import { RestService } from '../rest.service';

@Component({
	selector: 'app-lancamento',
	templateUrl: './lancamento.component.html'
})
export class LancamentoComponent implements OnInit {
	projeto: any;
	loading = false;
	equipes: ItemSelectedModel[];

	@Input() id;

	constructor(private restService: RestService, public activeModal: NgbActiveModal) {
		this.projeto = new ProjectModel();
	}

	ngOnInit() {
		this.buscarEquipes();
	}

	buscarEquipes() {
		this.loading = true;
		this.restService.get<any>('team/list').subscribe(result => {
			this.carregarListaEquipes(result);
			if (this.id)
				this.buscarProjeto();
			else
				this.loading = false;
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	carregarListaEquipes(result) {
		this.equipes = [];
		result.forEach(element => {
			this.equipes.push(new ItemSelectedModel(element.id, element.name, false));
		});
	}

	buscarProjeto() {
		this.loading = true;
		this.restService.get<any>('project?id=' + this.id).subscribe(result => {
			this.loading = false;
			this.projeto = result;
			this.selecionarEquipesVinculadasAoProjeto();
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	selecionarEquipesVinculadasAoProjeto() {
		this.projeto.teams.forEach(element => {
			const equipe = this.equipes.find(x => x.id == element.id);
			if (equipe)
				equipe.selected = true;
		});
	}

	salvar() {
		this.projeto.teams = this.equipes.filter(x => x.selected).map(x => x.id);
		if (this.id)
			this.alterar();
		else
			this.incluir();
	}

	incluir() {
		this.loading = true;
		this.restService.post<ProjectModel[]>('project', this.projeto).subscribe(result => {
			this.loading = false;
			this.activeModal.close('entity saved')
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	alterar() {
		this.loading = true;
		this.restService.put<ProjectModel[]>('project', this.projeto).subscribe(result => {
			this.loading = false;
			this.activeModal.close('entity saved')
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	selecionar(item) {
		const equipe = this.equipes.find(x => x.id == item);
		equipe.selected = !equipe.selected;
	}
}