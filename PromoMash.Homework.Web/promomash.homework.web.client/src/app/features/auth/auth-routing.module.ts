import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthWizardComponent } from './components/auth-wizard/auth-wizard.component';

const routes: Routes = [
  { path: 'app-auth-wizard', component: AuthWizardComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
