import { Component } from '@angular/core';
import { LoadingDotsComponent } from "../../components/loading-dots/loading-dots.component";
import { Router, RouterModule } from '@angular/router';

@Component({
    selector: 'app-splashscreen',
    standalone: true,
    templateUrl: './splashscreen.component.html',
    styleUrl: './splashscreen.component.css',
    imports: [LoadingDotsComponent, RouterModule]
})
export class SplashscreenComponent {
    constructor(private _route: Router) {
        setTimeout(() => {
            this._route.navigate(['/welcome']);
        }, 3000);
    }
}
