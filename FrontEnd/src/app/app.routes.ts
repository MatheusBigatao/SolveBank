import { Routes } from '@angular/router';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { CadastroComponent } from './pages/cadastro/cadastro.component';
import { RecoverPasswordComponent } from './pages/recover-password/recover-password.component';
import { SplashscreenComponent } from './pages/splashscreen/splashscreen.component';
export const routes: Routes = [
  { path: '', component: LandingPageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'cadastro', component: CadastroComponent },
  { path: 'home', component: HomeComponent },
  { path: 'recover-password', component: RecoverPasswordComponent },
  { path: 'splashscreen', component: SplashscreenComponent}
]

