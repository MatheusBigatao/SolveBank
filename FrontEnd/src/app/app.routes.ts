import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { SplashscreenComponent } from './pages/splashscreen/splashscreen.component';

export const routes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'splashscreen', component: SplashscreenComponent}
];
