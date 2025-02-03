import { Component } from '@angular/core';
import { SharedDataService } from './services/shared-data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'LibeyTechnicalTest';
  searchValue: string = '';

  constructor(private sharedDataService: SharedDataService) {}

  refresherUsers(): void {
    this.sharedDataService.fetchUsers(this.searchValue);
  }

  handleSearchValue(){
    if(this.searchValue.length === 0){
      this.refresherUsers();
    }
  }
}
