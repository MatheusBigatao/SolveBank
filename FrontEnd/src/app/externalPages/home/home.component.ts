import { Component } from '@angular/core';
import { MenuHomeComponent } from '../../components/menu-home/menu-home.component';
import { Router, RouterModule } from '@angular/router';
import { ContaBancariaService } from '../../services/conta-bancaria.service';
import { responseExibirUsuarioDTO } from '../../models/DTOs/UsuarioDTOs/responseExibirUsuarioDTO';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-external-home',
  standalone: true,
  imports: [CommonModule, MenuHomeComponent, RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class ExternalHomeComponent {
  usuarioLogged: responseExibirUsuarioDTO = JSON.parse(
    localStorage.getItem('userLogged') || ''
  ) as responseExibirUsuarioDTO;

  saldoDaConta: number = 0
  loadginSaldo: boolean = true

  constructor(
    private contaBancariaServicos: ContaBancariaService,
    private route: Router
  ) { }

  ngOnInit() {
  }

  exibirSaldo() {
    this.loadginSaldo = true
    this.contaBancariaServicos
      .consultarSaldo(this.usuarioLogged.contasBancarias[0].id)
      .subscribe({
        next: res => {          
          setTimeout(()=>{
            this.saldoDaConta = res.saldo
            this.loadginSaldo = false
          },1000)         
        },
        error: err => {
          console.log(err)          
          localStorage.removeItem('userLogged');
          this.route.navigateByUrl('/external/login');         
        },
      });
  }

  logoutUser() {
    localStorage.removeItem('userLogged');
    this.route.navigateByUrl('/external/login');
  }
}
