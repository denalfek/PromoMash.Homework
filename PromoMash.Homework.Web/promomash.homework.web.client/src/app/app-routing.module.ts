import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthWizardFirstStepComponent } from './auth-wizard-first-step/auth-wizard-first-step.component';

const routes: Routes = [
  { path: 'auth-first', component: AuthWizardFirstStepComponent },
  { path: '', redirectTo: '/auth-first', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
