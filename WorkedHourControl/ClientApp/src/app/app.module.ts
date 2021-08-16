import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoadingComponent } from './loading/loading.component';
import { AuthService } from './auth.service';
import { AuthGuardService, AuthGuardServiceGestor } from './auth-guard.service';
import { LoginComponent } from './login/login.component';
import { ColaboradorComponent } from './colaborador/colaborador.component';
import { EquipeComponent } from './equipe/equipe.component';
import { ProjetoComponent } from './projeto/projeto.component';
import { LocalStorageService } from './local-storage.service';
import { GerenciarColaboradorComponent } from './colaborador/gerenciar-colaborador.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RestService } from './rest.service';
import { GerenciarEquipeComponent } from './equipe/gerenciar-equipe.component';
import { GerenciarProjetoComponent } from './projeto/gerenciar-projeto.component';
import { LancamentosComponent } from './projeto/lancamentos.component';
import { LancamentoComponent } from './projeto/lancamento.component';
import { DatePipe } from '@angular/common';
import { ReportComponent } from './report/report.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoadingComponent,
    LoginComponent,
    ColaboradorComponent,
    EquipeComponent,
    ProjetoComponent,
    GerenciarColaboradorComponent,
    GerenciarEquipeComponent,
    GerenciarProjetoComponent,
    LancamentosComponent,
    LancamentoComponent,
    ReportComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'projetos', component: ProjetoComponent, canActivate: [AuthGuardService] },
      { path: 'equipes', component: EquipeComponent, canActivate: [AuthGuardServiceGestor] },
      { path: 'colaboradores', component: ColaboradorComponent, canActivate: [AuthGuardServiceGestor] },
      { path: 'report', component: ReportComponent, canActivate: [AuthGuardServiceGestor] },
    ])
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
  providers: [AuthService, AuthGuardService, AuthGuardServiceGestor, LocalStorageService, RestService, DatePipe],
  entryComponents: [GerenciarColaboradorComponent, GerenciarEquipeComponent, GerenciarProjetoComponent, LancamentosComponent, LancamentoComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
