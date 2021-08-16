import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from '../auth.service';
import { ErroHandler } from '../error-handle.service';
import { CreateWorkedHourModel } from '../models/create-worked-hour.model';
import { TeamModel } from '../models/team.model';
import { RestService } from '../rest.service';

@Component({
	selector: 'app-lancamento',
	templateUrl: './lancamento.component.html'
})
export class LancamentoComponent implements OnInit {
	equipes: TeamModel[];
	equipeSelecionada: TeamModel;
	bloquearEdicaoData = false;
	loading = false;

	@Input() id;
	@Input() name;
	@Input() employeeId;
	@Input() teamId;
	@Input() data: Date;
	@Input() tempo: number;

	constructor(private restService: RestService, public activeModal: NgbActiveModal, private datepipe: DatePipe) {
	}

	ngOnInit() {
		if (!this.data)
			this.data = new Date();
		else
			this.bloquearEdicaoData = true;
		this.buscarEquipes();
	}

	buscarEquipes() {
		this.loading = true;
		this.restService.get<TeamModel>('projectteam/project/' + this.id + '/employee/' + this.employeeId).subscribe(result => {
			this.carregarEquipes(result);
			this.loading = false;
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	carregarEquipes(result) {
		if (result.length > 0) {
			if (this.teamId)
				this.equipeSelecionada = result.find(x => x.id == this.teamId);
			else
				this.equipeSelecionada = result[0];
		}
		this.equipes = result;
	}

	salvar() {
		let data = this.datepipe.transform(this.data, 'yyyy-MM-dd');
		const req = new CreateWorkedHourModel(data, this.tempo, this.id, this.equipeSelecionada.id, this.employeeId);
		this.loading = true;
		this.restService.post<TeamModel>('workedhour', req).subscribe(result => {
			this.loading = false;
			this.activeModal.close('entity saved')
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	selecionarEquipe(item) {
		this.equipeSelecionada = this.equipes.find(x => x.id == parseInt(item));
	}
}