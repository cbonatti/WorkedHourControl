import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ErroHandler } from '../error-handle.service';
import { WorkedHour } from '../models/project-worked-hour.model';
import { ReportWorkedHourModel } from '../models/report-worked-hour.model';
import { RestService } from '../rest.service';

@Component({
	selector: 'app-report',
	templateUrl: './report.component.html'
})
export class ReportComponent implements OnInit {
	projetos: any;
	equipes: any;
	dataInicio: Date;
	dataFim: Date;
	loading = false;
	loadingProjetos = false;
	projetoSelecionado: any;
	equipeSelecionada: any;
	workedHours: WorkedHour[];
	totalHoras = 0;

	constructor(private restService: RestService, private datepipe: DatePipe) {
	}

	ngOnInit() {
		this.dataInicio = new Date();
		this.dataFim = new Date();
		this.buscarProjetos();
	}

	buscarProjetos() {
		this.loadingProjetos = true;
		this.restService.get<any>('project/report').subscribe(result => {
			this.projetos = result;
			if (this.projetos.length > 0)
				this.selecionarProjeto(this.projetos[0].id);
			this.loadingProjetos = false;
		}, error => {
			this.loadingProjetos = false;
			ErroHandler.handle(error);
		});
	}

	selecionarProjeto(item) {
		this.projetoSelecionado = this.projetos.find(x => x.id == parseInt(item));
		this.equipes = this.projetoSelecionado.teams;

		if (this.equipes.length > 0) {
			if (this.equipes[0].id != 0)
				this.equipes.splice(0, 0, { id: 0, name: '' })
		}
		// if (this.equipes && this.equipes.length > 0)
		// 	this.equipeSelecionada = this.equipes[0];
	}

	selecionarEquipe(item) {
		this.equipeSelecionada = this.equipes.find(x => x.id == parseInt(item));
	}

	gerar() {
		const startDate = this.datepipe.transform(this.dataInicio, 'yyyy-MM-dd');
		const endDate = this.datepipe.transform(this.dataFim, 'yyyy-MM-dd');
		let teamId = 0;
		if (this.equipeSelecionada)
			teamId = this.equipeSelecionada.id;
		const req = new ReportWorkedHourModel(startDate, endDate, this.projetoSelecionado.id, teamId, 0);
		this.loading = true;
		this.restService.post<any>('workedhour/report', req).subscribe(result => {
			this.loading = false;
			this.carregarHorasTrabalhadas(result);
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	carregarHorasTrabalhadas(projectWorkedHour) {
		this.workedHours = projectWorkedHour.workedHours;
		this.totalHoras = this.workedHours.reduce((sum, current) => sum + current.timeSpent, 0);
	}
}
