import { Injectable } from "@angular/core";
import { CanActivate } from "@angular/router";
import { AuthService } from "./auth.service";

@Injectable()
export class AuthGuardService implements CanActivate {

    constructor(private service: AuthService) { }

    canActivate(): boolean {
        var usuarioContexto = this.service.getUsuarioContexto();
        if (!usuarioContexto)
            return false;

        return true;
    }
}

@Injectable()
export class AuthGuardServiceGestor implements CanActivate {

    constructor(private service: AuthService) { }

    canActivate(): boolean {
        var usuarioContexto = this.service.getUsuarioContexto();
        if (!usuarioContexto)
            return false;

        return usuarioContexto.profile == "Gestor";
    }
}