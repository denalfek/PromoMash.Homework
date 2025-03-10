import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WeatherForecastComponent } from './features/weather-forecast/components/weather-forecast.component';
import { AuthWizardComponent } from './features/auth/components/auth-wizard/auth-wizard.component';

const routes: Routes = [
  {
    path: 'app-auth-wizard',
    component: AuthWizardComponent,
    loadChildren: () => import('./features/auth/auth.module').then(m => m.AuthModule)
  },
  { path: 'weather-forecast', component: WeatherForecastComponent },
  { path: '', redirectTo: 'app-auth-wizard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
