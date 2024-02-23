import { Routes } from '@angular/router';
import { SignUpComponent } from './pages/signUp/signUp.component';
import { HomeComponent } from './pages/home/home.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginComponent } from './pages/login/login.component';
import { RecoverPasswordComponent } from './pages/recover-password/recover-password.component';
import { SplashscreenComponent } from './pages/splashscreen/splashscreen.component';
import { TransactionsComponent } from './pages/transactions/transactions.component';
export const routes: Routes = [
  { path: '', component: LandingPageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signUp', component: SignUpComponent },
  { path: 'home', component: HomeComponent },
  { path: 'recover-password', component: RecoverPasswordComponent },
  { path: 'splashscreen', component: SplashscreenComponent },
  { path: 'transactions', component: TransactionsComponent },
];