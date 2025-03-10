/// <reference path="auth-routing.module.ts" />
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { AuthWizardComponent } from './components/auth-wizard/auth-wizard.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { LocationFormComponent } from './components/location-form/location-form.component';


@NgModule({
  declarations: [
    AuthWizardComponent,
    LoginFormComponent,
    LocationFormComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    AuthRoutingModule
  ]
})
export class AuthModule { }
