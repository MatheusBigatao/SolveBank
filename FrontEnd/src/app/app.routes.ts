import { Routes } from '@angular/router';
import { SignUpComponent } from './pages/signUp/signUp.component';
import { HomeComponent } from './pages/home/home.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginComponent } from './pages/login/login.component';
import { RecoverPasswordComponent } from './pages/recover-password/recover-password.component';
import { SplashscreenComponent } from './pages/splashscreen/splashscreen.component';
import { TransactionsComponent } from './pages/transactions/transactions.component';
import { ExternalTransferComponent} from './externalPages/transfer/transfer.component';
import { ExternalHomeComponent } from './externalPages/home/home.component';
import { ExternalDepositComponent } from './externalPages/deposit/deposit.component';
import { ExternalLoginComponent } from './externalPages/login/login.component';
import { ExternalWithdrawComponent } from './externalPages/withdraw/withdraw.component';
import { ExternalAuthenticationComponent } from './externalPages/authentication/authentication.component';

export const routes: Routes = [
  { path: '', component: SplashscreenComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signUp', component: SignUpComponent },
  { path: 'home', component: HomeComponent },
  { path: 'recover-password', component: RecoverPasswordComponent },
  { path: 'welcome', component: LandingPageComponent },
  { path: 'transactions', component: TransactionsComponent },
  { path: 'external/home', component: ExternalHomeComponent },
  { path: 'external/login', component:ExternalLoginComponent},
  { path: 'external/deposit', component:ExternalDepositComponent},
  { path: 'external/transfer', component:ExternalTransferComponent},
  { path: 'external/withdraw', component:ExternalWithdrawComponent},
  { path: 'external/authentication', component:ExternalAuthenticationComponent},
];
