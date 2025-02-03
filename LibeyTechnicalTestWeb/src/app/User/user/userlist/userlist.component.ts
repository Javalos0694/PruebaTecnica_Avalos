import { Component, OnInit } from '@angular/core';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { SharedDataService } from 'src/app/services/shared-data.service';
import { Router } from '@angular/router';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css'],
})
export class UserlistComponent implements OnInit {
  users: LibeyUser[] = [];
  constructor(
    private sharedDataService: SharedDataService,
    private libeyUserService: LibeyUserService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.sharedDataService.getUsers$().subscribe((data) => {
      this.users = data;
    });

    this.sharedDataService.fetchUsers('');
  }

  setUserEdit(user: LibeyUser) {
    this.sharedDataService.setUser(user);
    this.router.navigate([`user/maintenance/${user.documentNumber}`]);
  }

  deleteUser(documentNumber: string) {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
      if (result.isConfirmed) {
        this.libeyUserService.DeleteUser(documentNumber).subscribe((data) => {
          this.sharedDataService.fetchUsers('');
          Swal.fire({
            title: 'Deleted!',
            text: 'Your file has been deleted.',
            icon: 'success',
          });
        });
      }
    });
  }
}
