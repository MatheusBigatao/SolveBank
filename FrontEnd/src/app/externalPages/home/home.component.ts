import { Component } from '@angular/core';
import { MenuHomeComponent } from '../../components/menu-home/menu-home.component';
import { Router, RouterModule } from '@angular/router';
import { ContaBancariaService } from '../../services/conta-bancaria.service';
import { responseExibirUsuarioDTO } from '../../models/DTOs/UsuarioDTOs/responseExibirUsuarioDTO';

@Component({
  selector: 'app-external-home',
  standalone: true,
  imports: [MenuHomeComponent, RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class ExternalHomeComponent {
  usuarioLogged: responseExibirUsuarioDTO = JSON.parse(
    localStorage.getItem('userLogged') || ''
  ) as responseExibirUsuarioDTO;

  saldoDaConta: number = 0

  constructor(
    private contaBancariaServicos: ContaBancariaService,
    private route: Router
  ) {}

  ngOnInit() {
    this.exibirSaldo()
  }

  exibirSaldo() {
    this.contaBancariaServicos
      .consultarSaldo(this.usuarioLogged.contasBancarias[0].id)
      .subscribe({
        next: res => {
          this.saldoDaConta = res.saldo
        },
        error: err => {
          console.log(err)
          if (err.status === 401) {
            localStorage.removeItem('userLogged');
            this.route.navigateByUrl('/external/login');
          }
        },
      });
  }

  logoutUser(){
    localStorage.removeItem('userLogged');
    this.route.navigateByUrl('/external/login');
  }
}
