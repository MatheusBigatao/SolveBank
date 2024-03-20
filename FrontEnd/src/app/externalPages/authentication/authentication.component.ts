import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-authentication',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './authentication.component.html',
  styleUrl: './authentication.component.css'
})
export class ExternalAuthenticationComponent {
  authForm: FormGroup;

  constructor (private _router: Router) {
    this.authForm = new FormGroup({
      token: new FormControl('', [Validators.required, Validators.minLength(8)])
    });
  }

  authUser() {
    setTimeout(() => {
      this._router.navigateByUrl("/external/home")
    }, 2000);
  }
}
