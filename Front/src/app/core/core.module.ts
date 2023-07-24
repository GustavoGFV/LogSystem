import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from './api/api.service';
import { RouterModule } from '@angular/router';
import { ApiRoutes } from './api/routes/apiroutes';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule
  ],
  providers:[
    ApiRoutes,
    ApiService
  ]
})
export class CoreModule { }
