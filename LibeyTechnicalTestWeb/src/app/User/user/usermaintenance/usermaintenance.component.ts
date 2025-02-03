import { Component, OnInit } from '@angular/core';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { ActivatedRoute } from '@angular/router';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css'],
})
export class UsermaintenanceComponent implements OnInit {
  userForm: FormGroup;
  user: LibeyUser = {} as LibeyUser;
  documentNumber?: string;

  constructor(
    private LibeyUserService: LibeyUserService,
    private route: ActivatedRoute
  ) {
    this.userForm = new FormGroup({
      DocumentTypeId: new FormControl('', [Validators.required]),
      DocumentNumber: new FormControl('', [Validators.required]),
      Name: new FormControl(''),
      FathersLastName: new FormControl(''),
      MothersLastName: new FormControl(''),
      Address: new FormControl(''),
      RegionCode: new FormControl('', [Validators.required]),
      ProvinceCode: new FormControl('', Validators.required),
      UbigeoCode: new FormControl('', Validators.required),
      Phone: new FormControl('', Validators.pattern('[0-9]{9}')),
      Email: new FormControl('', Validators.email),
      Password: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.documentNumber = params.get('id') || '';
    });

    if (this.documentNumber) {
      this.LibeyUserService.Find(this.documentNumber || '').subscribe(
        (data) => {
          this.user = data;
          this.userForm.patchValue({
            DocumentTypeId: this.user.documentTypeId,
            DocumentNumber: this.user.documentNumber,
            Name: this.user.name,
            FathersLastName: this.user.fathersLastName,
            MothersLastName: this.user.mothersLastName,
            Address: this.user.address,
            RegionCode: this.user.regionCode,
            ProvinceCode: this.user.provinceCode,
            UbigeoCode: this.user.ubigeoCode,
            Phone: this.user.phone,
            Email: this.user.email,
            Password: this.user.password,
          });
        }
      );
    }
  }

  Clear(){
    this.userForm.reset();
  }

  Submit() {
    if (this.userForm.valid) {
      const request = this.userForm.value;
      this.LibeyUserService.CreateUser(request).subscribe((data) => {
        if (data) {
          Swal.fire({
            icon: 'success',
            title: 'Changes Saved!',
            text: '',
          });
          this.Clear();
        }
      });
    } else {
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Something went wrong!',
      });
    }
  }
}
