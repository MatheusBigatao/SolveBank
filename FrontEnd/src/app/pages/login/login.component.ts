import { Component } from '@angular/core';
import { FooterRightsComponent } from '../../components/footer-rights/footer-rights.component';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FooterRightsComponent, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
    loginForm: FormGroup;

    constructor() {
        this.loginForm = new FormGroup({
            cpf: new FormControl('', [Validators.required, Validators.pattern(/^\d{3}\.\d{3}\.\d{3}-\d{2}$/)]),
            senha: new FormControl('', Validators.required),
            lembrar: new FormControl(false)
        });
    }

    submitForm(){
        // console.log(this.loginForm.value);
    }
}
