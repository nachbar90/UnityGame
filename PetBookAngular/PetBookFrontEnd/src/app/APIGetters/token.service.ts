import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
url = 'http://localhost:5000/api/authorization/';
JWT = new JwtHelperService();

constructor(private http: HttpClient) {}

login(petData: any){
  return this.http.post(this.url + 'login', petData).pipe(
    map((response: any) => {
      const token = response;
      if (token){
        localStorage.setItem('token', token.token);
      }
    })
  );
}

logged()
{
  const token = localStorage.getItem('token');
  return !this.JWT.isTokenExpired(token);
}

register(petData: any)
{
  console.log('Name: ' + petData.name + ' pass:  ' + petData.password);
  return this.http.post(this.url + 'registration', petData);
}

getUserIdFromToken()
{
  const token = localStorage.getItem('token');
  const decodedToken = this.JWT.decodeToken(token);
  return decodedToken.nameid;
}
}
