import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from '../auth.service';
import { ErroHandler } from '../error-handle.service';
import { ProjectWorkedHour, WorkedHour } from '../models/project-worked-hour.model';
import { RestService } from '../rest.service';
import { LancamentoComponent } from './lancamento.component';

@Component({
	selector: 'app-lancamentos',
	templateUrl: './lancamentos.component.html'
})
export class LancamentosComponent implements OnInit {
	workedHours: WorkedHour[];
	loading = false;
	employeeId: number;

	@Input() id;
	@Input() name;

	constructor(private restService: RestService, public activeModal: NgbActiveModal, private service: AuthService, private modalService: NgbModal) {
	}

	ngOnInit() {
		this.employeeId = this.service.getUsuarioContexto().employee.id;
		this.buscarLancamentos();
	}

	buscarLancamentos() {
		this.loading = true;
		this.restService.get<ProjectWorkedHour>('workedhour/project/' + this.id + '/employee/' + this.employeeId).subscribe(result => {
			this.carregarHorasTrabalhadas(result);
			this.loading = false;
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	carregarHorasTrabalhadas(projectWorkedHour) {
		this.workedHours = projectWorkedHour.workedHours
	}

	lancar(item) {
		const modalRef = this.modalService.open(LancamentoComponent, { size: 'sm' });
		modalRef.componentInstance.id = this.id;
		modalRef.componentInstance.name = this.name;
		modalRef.componentInstance.employeeId = this.employeeId;
		if (item) {
			modalRef.componentInstance.data = item.date;
			modalRef.componentInstance.tempo = item.timeSpent;
			modalRef.componentInstance.teamId = item.team.id;
		}
		modalRef.result.then((result) => {
			this.buscarLancamentos();
		});
	}

	excluir(id) {
		this.loading = true;
		this.restService.delete('workedhour/' + id).subscribe(result => {
			this.buscarLancamentos();
			this.loading = false;
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}
}