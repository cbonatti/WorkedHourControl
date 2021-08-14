import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { LocalStorageService } from "./local-storage.service";
import { UserModel } from "./models/user.model";

export const PATH_LOGIN = 'loginContext';

@Injectable()
export class AuthService {

    public isLoggedIn = new BehaviorSubject<boolean>(false);

    constructor(private localStorageService: LocalStorageService) {
    }

    getUsuarioContexto() {
        var context = <UserModel>this.localStorageService.readObject(PATH_LOGIN);
        return context;
    }

    setUsuarioContexto(login) {
        this.localStorageService.writeObject(PATH_LOGIN, login);
        if (login)
            this.isLoggedIn.next(true);
        else
            this.isLoggedIn.next(false);
    }
}