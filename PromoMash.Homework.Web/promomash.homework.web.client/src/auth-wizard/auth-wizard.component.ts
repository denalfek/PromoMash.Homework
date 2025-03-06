// Step 1: Generate a new component for the auth wizard
// Run this command in your terminal:
// ng generate component auth-wizard

// auth-wizard.component.ts
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-auth-wizard',
  standalone: false,
  templateUrl: './app-auth-wizard/auth-wizard.component.html',
  styleUrls: ['./app-auth-wizard/auth-wizard.component.css']
})
export class AuthWizardComponent {

  title = '';
  currentStep = 1;
  authForm: FormGroup;

  constructor(private fb: FormBuilder) {
    console.log("Test!");
    
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
    if (this.currentStep === 1 && this.authForm.get('email')?.valid) {
      this.currentStep++;
    } else if (this.currentStep === 2 &&
      this.authForm.get('password')?.valid &&
      this.authForm.get('confirmPassword')?.valid) {
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
    }
  }
}
