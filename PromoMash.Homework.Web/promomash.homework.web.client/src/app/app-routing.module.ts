import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthWizardComponent } from '../auth-wizard/auth-wizard.component';

const routes: Routes = [
  { path: 'auth', component: AuthWizardComponent },
//  { path: '', redirectTo: '/auth', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
