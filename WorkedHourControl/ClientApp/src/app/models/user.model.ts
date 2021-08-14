import { Observable, Subject } from "rxjs";

export class UserModel {
    username: string;
    name: string;
    profile: string;
    token: string;

    private logger = new Subject<boolean>();
    private loggedIn = false;

    isLoggedIn(): Observable<boolean> {
        return this.logger.asObservable();
    }
}