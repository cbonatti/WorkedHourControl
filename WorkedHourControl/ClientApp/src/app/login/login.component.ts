import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { ErroHandler } from '../error-handle.service';
import { LoginModel } from '../models/login.model';
import { UserModel } from '../models/user.model';
import { RestService } from '../rest.service';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
	login: LoginModel;
	loading = false;

	constructor(private restService: RestService, private service: AuthService, private router: Router) {
		this.login = new LoginModel();
	}

	ngOnInit() {
		var usuario = this.service.getUsuarioContexto();
		if (usuario)
			this.navigateToHome();
	}

	enter() {
		this.loading = true;
		this.restService.post<UserModel[]>('login', this.login, false).subscribe(result => {
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