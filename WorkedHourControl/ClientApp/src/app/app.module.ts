import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoadingComponent } from './loading/loading.component';
import { AuthService } from './auth.service';
import { AuthGuardService, AuthGuardServiceGestor } from './auth-guard.service';
import { LoginComponent } from './login/login.component';
import { ColaboradorComponent } from './colaborador/colaborador.component';
import { EquipeComponent } from './equipe/equipe.component';
import { ProjetoComponent } from './projeto/projeto.component';
import { LocalStorageService } from './local-storage.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoadingComponent,
    LoginComponent,
    ColaboradorComponent,
    EquipeComponent,
    ProjetoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginComponent },
      { path: 'projetos', component: ProjetoComponent, canActivate: [AuthGuardService] },
      { path: 'equipes', component: EquipeComponent, canActivate: [AuthGuardServiceGestor] },
      { path: 'colaboradores', component: ColaboradorComponent, canActivate: [AuthGuardServiceGestor] },
    ])
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [AuthService, AuthGuardService, AuthGuardServiceGestor, LocalStorageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
