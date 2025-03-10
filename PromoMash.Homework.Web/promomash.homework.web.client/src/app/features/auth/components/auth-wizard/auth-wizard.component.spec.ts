import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthWizardComponent } from './auth-wizard.component';

describe('AuthWizardComponent', () => {
  let component: AuthWizardComponent;
  let fixture: ComponentFixture<AuthWizardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AuthWizardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthWizardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
