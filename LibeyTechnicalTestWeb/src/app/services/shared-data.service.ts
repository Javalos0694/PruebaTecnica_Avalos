import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { LibeyUser } from '../entities/libeyuser';
import { LibeyUserService } from '../core/service/libeyuser/libeyuser.service';

@Injectable({
  providedIn: 'root',
})
export class SharedDataService {
  private usersSubject = new BehaviorSubject<LibeyUser[]>([]);
  private userSubject = new BehaviorSubject<LibeyUser>({} as LibeyUser);
  constructor(private LibeyUserService: LibeyUserService) {}

  fetchUsers(filter: string): void {
    this.LibeyUserService.GetUsers(filter).subscribe((data: LibeyUser[]) => {
      this.usersSubject.next(data);
    });
  }

  fetchUser(documentNumber: string): void {
    this.LibeyUserService.Find(documentNumber).subscribe((data: LibeyUser) => {
      this.userSubject.next(data);
    });
  }

  setUser(user: LibeyUser): void {
    this.userSubject.next(user);
  }

  getUsers$(): Observable<LibeyUser[]> {
    return this.usersSubject.asObservable();
  }

  getUser$(): Observable<LibeyUser> {
    return this.userSubject.asObservable();
  }
}
