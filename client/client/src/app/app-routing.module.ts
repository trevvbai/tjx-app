import { NgModule } from '@angular/core';
import {RouterModule, RouterOutlet} from "@angular/router";
import {routes} from "./app.routes";



@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
  ],
  exports: [
    RouterModule,
  ]
})
export class AppRoutingModule { }
