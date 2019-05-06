import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';
import { ProdutoService } from '../service/produto.service';
import { Produto } from './produto';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.scss']
})
export class ProdutoComponent implements OnInit {

  dados: Produto[] = [
    
  ];
  exibirColunas: string[] = ['produtoID', 'nome', 'descricao'];
  carregandoResult = true;

  constructor(private produtoService: ProdutoService, private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.obterProdutos();
  }

  obterProdutos(): void {
    this.produtoService.obterProdutos()
      .subscribe(produtos => {
        this.dados = produtos;
        console.log(this.dados);
        this.carregandoResult = false;
      }, err => {
        console.log(err);
        this.carregandoResult = false;
      });
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

}
