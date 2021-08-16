export class ReportWorkedHourModel {
    startDate: Date;
    endDate: Date;
    projectId: number;
    teamId: number;
    employeeId: number;

    constructor(start, end, project, team, employee) {
        this.startDate = start;
        this.endDate = end;
        this.projectId = project;
        this.teamId = team;
        this.employeeId = employee;
    }
}