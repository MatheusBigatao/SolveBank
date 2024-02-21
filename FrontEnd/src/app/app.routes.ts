import { Routes } from '@angular/router';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { CadastroComponent } from './pages/cadastro/cadastro.component';
import { RecoverPasswordComponent } from './pages/recover-password/recover-password.component';

export const routes: Routes = [
  { path: '', component: LandingPageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'cadastro', component: CadastroComponent },
<<<<<<< HEAD
  { path: 'home', component: HomeComponent },
  { path: 'recover-password', component: RecoverPasswordComponent },
  { path: "", redirectTo: "home", pathMatch: "full" }

]
=======
  { path: 'home', component: HomeComponent }
]
>>>>>>> f909386e5ad0279c15e702b220d23162fc8042e0
