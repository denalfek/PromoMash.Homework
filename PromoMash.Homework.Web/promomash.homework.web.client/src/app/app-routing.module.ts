import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthWizardFirstStepComponent } from './auth-wizard-first-step/auth-wizard-first-step.component';
import { WeatherForecastComponent } from './weather-forecast/weather-forecast.component';

const routes: Routes = [
  { path: 'auth-first-step', component: AuthWizardFirstStepComponent },
  { path: 'weather-forecast', component: WeatherForecastComponent },
  { path: '', redirectTo: '/auth-first-step', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
