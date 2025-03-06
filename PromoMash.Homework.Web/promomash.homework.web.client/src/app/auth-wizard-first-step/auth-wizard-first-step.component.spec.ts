import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthWizardFirstStepComponent } from './auth-wizard-first-step.component';

describe('AuthWizardFirstStepComponent', () => {
  let component: AuthWizardFirstStepComponent;
  let fixture: ComponentFixture<AuthWizardFirstStepComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AuthWizardFirstStepComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthWizardFirstStepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
