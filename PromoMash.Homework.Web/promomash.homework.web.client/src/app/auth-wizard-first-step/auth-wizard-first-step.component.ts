import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

interface User {
  email: string;
  password: string;
}

@Component({
  selector: 'app-auth-wizard-first-step',
  standalone: false,
  templateUrl: './auth-wizard-first-step.component.html',
  styleUrl: './auth-wizard-first-step.component.css'
})
export class AuthWizardFirstStepComponent {
  currentStep = 1;
  authForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.authForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      confirmPassword: ['', Validators.required]
    }, { validators: this.passwordMatchValidator });
  }

  // Custom validator to check if passwords match
  passwordMatchValidator(form: FormGroup) {
    const password = form.get('password')?.value;
    const confirmPassword = form.get('confirmPassword')?.value;

    if (password !== confirmPassword) {
      form.get('confirmPassword')?.setErrors({ mismatch: true });
      return { mismatch: true };
    }

    return null;
  }

  // Navigate to next step
  nextStep() {
    if (this.currentStep === 1 &&
      this.authForm.get('email')?.valid &&
      this.authForm.get('password')?.valid &&
      this.authForm.get('confirmPassword')?.valid) {
      this.currentStep++;
    } else if (this.currentStep === 2) {
      this.onSubmit();
    }
  }

  // Navigate to previous step
  prevStep() {
    if (this.currentStep > 1) {
      this.currentStep--;
    }
  }

  // Form submission
  onSubmit() {
    if (this.authForm.valid) {
      console.log('Form submitted successfully', this.authForm.value);
      // Here you would typically call your authentication service
      // this.authService.register(this.authForm.value);
      this.http.post(
        '/users',
        {
          email: this.authForm.get('email')?.value,
          password: this.authForm.get('password')?.value
        }).subscribe(
          () => {
            
          },
          (error) => {
            console.error(error);
          }
        )
    }
  }
}
