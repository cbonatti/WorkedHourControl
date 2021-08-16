export class CreateWorkedHourModel {
    date: Date;
    timeSpent: number;
    projectId: number;
    teamId: number;
    employeeId: number;

    constructor(date, time, project, team, employee) {
        this.date = date;
        this.timeSpent = time;
        this.projectId = project;
        this.teamId = team;
        this.employeeId = employee;
    }
}