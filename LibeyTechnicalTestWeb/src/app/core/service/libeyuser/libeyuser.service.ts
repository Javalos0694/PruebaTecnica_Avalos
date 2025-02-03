import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { LibeyUser } from 'src/app/entities/libeyuser';
@Injectable({
  providedIn: 'root',
})
export class LibeyUserService {
  constructor(private http: HttpClient) {}
  Find(documentNumber: string): Observable<LibeyUser> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
    return this.http.get<LibeyUser>(uri);
  }

  GetUsers(filter: string): Observable<LibeyUser[]> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/users?filter=${filter}`;
    return this.http.get<Array<LibeyUser>>(uri);
  }

  CreateUser(user: LibeyUser): Observable<boolean> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
    const response = this.http.post<boolean>(uri, user);
    return response;
  }

  DeleteUser(documentNumber: string): Observable<boolean> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
    const response = this.http.delete<boolean>(uri);
    return response;
  }
}
