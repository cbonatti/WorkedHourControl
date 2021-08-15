import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { ErroHandler } from '../error-handle.service';
import { UserModel } from '../models/user.model';
import { RestService } from '../rest.service';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

	usuario = '';
	senha = '';
	loading = false;

	constructor(private restService: RestService, private service: AuthService, private router: Router) {
	}

	ngOnInit() {
		var usuario = this.service.getUsuarioContexto();
		if (usuario)
			this.navigateToHome();
	}

	login() {
		this.loading = true;
		let req = new LoginRequest();
		req.username = this.usuario;
		req.password = this.senha;
		this.restService.post<UserModel[]>('login', req, false).subscribe(result => {
			this.service.setUsuarioContexto(result);
			this.loading = false;
			this.navigateToHome();
		}, error => {
			this.loading = false;
			ErroHandler.handle(error);
		});
	}

	navigateToHome() {
		this.router.navigate(['/']);
	}
}

export class LoginRequest {
	username: string;
	password: string;
}
