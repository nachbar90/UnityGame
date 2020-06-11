import { Component, OnInit } from '@angular/core';
import { TokenService } from '../APIGetters/token.service';
import { AlertifyService } from '../APIGetters/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
  styles: ['h1 { font-weight: Bold; }']
})
export class MenuComponent implements OnInit {
  petData: any = {};
  petId: any = {};

  constructor(private tokenService: TokenService, private router: Router , private alertify: AlertifyService) { }

  ngOnInit() {
    this.petId = this.tokenService.getUserIdFromToken();
  }

  login(){
    this.tokenService.login(this.petData).subscribe(next =>{
        console.log('ok');
        this.alertify.ok('Udało się zalogować');
        this.router.navigate(['/pets']);
        this.petId = this.tokenService.getUserIdFromToken();
    }, error => {
      console.log(error);
      this.alertify.error(error);
    });
  }

  logged(){
    return this.tokenService.logged();
  }

  loggedOut(){
    localStorage.removeItem('token');
    this.alertify.info('Użytkownik został wylogowany');
    console.log('Wylogowanie');
    this.router.navigate(['/main']);
  }

}
