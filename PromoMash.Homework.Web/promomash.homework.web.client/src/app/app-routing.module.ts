import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WeatherForecastComponent } from './features/weather-forecast/components/weather-forecast.component';

const routes: Routes = [
  {
    path: 'app-auth-wizard',
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
