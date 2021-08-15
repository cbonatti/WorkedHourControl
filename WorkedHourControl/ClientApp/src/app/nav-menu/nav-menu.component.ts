import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isLoggedIn = false;
  isManager = false;

  name = '';
  profile = '';

  constructor(private service: AuthService, private router: Router) {
    this.service.isLoggedIn.subscribe(value => {
      this.loadUser();
    });
  }

  ngOnInit(): void {
    this.loadUser();
  }

  loadUser() {
    var usuarioContexto = this.service.getUsuarioContexto();
    if (!usuarioContexto) {
      this.isLoggedIn = false;
    } else {
      this.isLoggedIn = true;
      this.isManager = usuarioContexto.profile == "Gestor";
      this.name = usuarioContexto.name;
      this.profile = usuarioContexto.profile;
    }
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.service.setUsuarioContexto(null);
    this.isLoggedIn = false;
    this.isManager = false;
    this.router.navigate(['/']);
  }
}
