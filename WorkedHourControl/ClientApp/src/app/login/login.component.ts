import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { UserModel } from '../models/user.model';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

	usuario = '';
	senha = '';
	loading = false;

	constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private service: AuthService, private router: Router) {
	}

	ngOnInit() {
		var usuario = this.service.getUsuarioContexto();
		if (usuario)
			this.navigateToHome();
	}

	login() {
		let req = new LoginRequest();
		req.username = this.usuario;
		req.password = this.senha;
		this.http.post<UserModel[]>(this.baseUrl + 'api/login', req).subscribe(result => {
			this.service.setUsuarioContexto(result);
			this.navigateToHome();
		}, error => alert(error.error));
	}

	navigateToHome() {
		this.router.navigate(['/']);
	}
}

export class LoginRequest {
	username: string;
	password: string;
}
