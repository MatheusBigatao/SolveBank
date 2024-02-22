import { Component } from '@angular/core';
import { LoadingDotsComponent } from "../../components/loading-dots/loading-dots.component";

@Component({
    selector: 'app-splashscreen',
    standalone: true,
    templateUrl: './splashscreen.component.html',
    styleUrl: './splashscreen.component.css',
    imports: [LoadingDotsComponent]
})
export class SplashscreenComponent {

}
