import { EmployeeModel } from "./employee.model";
import { TeamModel } from "./team.model";

export class ProjectWorkedHour {
    id: number;
    name: string;
    workerHours: WorkedHour[];
}

export class WorkedHour {
    id: number;
    date: Date;
    timeSpent: number;
    team: TeamModel;
    employee: EmployeeModel;
}