import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegistrationService } from '../../../../core/services/registration/registration.service';
import { CountryService } from '../../../../core/services/country/country.service';
import { ProvinceService } from '../../../../core/services/province/province.service';

@Component({
  selector: 'app-auth-wizard',
  standalone: false,
  templateUrl: './auth-wizard.component.html',
  styleUrl: './auth-wizard.component.css'
})
export class AuthWizardComponent implements OnInit {
  currentStep: number = 1;
  loginForm: FormGroup;
  locationForm: FormGroup;
  isSubmitting = false;

  constructor(
    private fb: FormBuilder,
    private registrationService: RegistrationService,
    private countryService: CountryService,
    private provinceService: ProvinceService
  ) { } 

  ngOnInit(): void {
    this.loginForm = this.fb.group({});
    this.locationForm = this.fb.group({});
  }

  onLoginFormCreated(form: FormGroup): void {
    this.loginForm = form;
  }

  onLocationFormCreated(form: FormGroup): void {
    this.locationForm = form;
  }

  nextStep(): void {
    if (this.loginForm.valid) {
      this.currentStep = 2;
    } else {
      this.markFormGroupTouched(this.loginForm);
    }
  }

  previousStep(): void {
    this.currentStep = 1;
  }

  markFormGroupTouched(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(key => {
      const control = formGroup.get(key);
      control?.markAsTouched();

      if (control instanceof FormGroup) {
        this.markFormGroupTouched(control);
      }
    });
  }

  save(): void {
    if (this.locationForm.valid) {
      this.isSubmitting = true;

      const userData = {
        ...this.loginForm.value,
        ...this.locationForm.value
      };

      this.registrationService.register(userData).subscribe({
        next: (response) => {
          this.isSubmitting = false;
          console.log('Registration successful', response);
        },
        error: (error) => {
          this.isSubmitting = false;
          console.error('Registration failed', error);
        }
      });
    } else {
      this.markFormGroupTouched(this.locationForm);
    }
  }
}
