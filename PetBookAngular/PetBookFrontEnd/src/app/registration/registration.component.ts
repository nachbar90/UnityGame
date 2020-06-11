import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { TokenService } from '../APIGetters/token.service';
import { AlertifyService } from '../APIGetters/alertify.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  petData: any = {};
  @Output() cancel = new EventEmitter();

  constructor(private authorizationAPI: TokenService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register()
  {
    this.authorizationAPI.register(this.petData).subscribe(() =>
    {
      this.alertify.ok('Rejestracja przebiegła pomyślnie');
      console.log('OK');
      console.log('Name: ' + this.petData.name + ' pass:  ' + this.petData.password);
    }, error => {
      console.log('Cos poszlo nie tak z rejestracja');
      console.log(error);
      this.alertify.error(error);
    });

  }

  cancelRegistration()
  {
    this.cancel.emit(false);
    console.log('cancel');
  }

}
