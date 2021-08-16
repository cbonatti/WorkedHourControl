import { Observable, Subject } from "rxjs";
import { EmployeeModel } from "./employee.model";

export class UserModel {
    username: string;
    employee: EmployeeModel;
    token: string;

    private logger = new Subject<boolean>();

    isLoggedIn(): Observable<boolean> {
        return this.logger.asObservable();
    }
}