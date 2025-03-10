import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CountryService } from '../../../../core/services/country/country.service';
import { ProvinceService } from '../../../../core/services/province/province.service';

@Component({
  selector: 'app-location-form',
  standalone: false,
  templateUrl: './location-form.component.html',
  styleUrl: './location-form.component.css'
})
export class LocationFormComponent implements OnInit {
  @Output() formCreated = new EventEmitter<FormGroup>();
  locationForm: FormGroup;
  countries: any[] = [];
  provinces: any[] = [];

  constructor(
    private fb: FormBuilder,
    private countryService: CountryService,
    private provinceService: ProvinceService
  ) { }

  ngOnInit(): void {
    this.locationForm = this.fb.group({
      country: ['', Validators.required],
      province: ['', Validators.required]
    });

    this.formCreated.emit(this.locationForm);
    this.loadCountries();
  }

  loadCountries(): void {
    this.countryService.get().subscribe(countries => {
      this.countries = countries;
    });
  }

  onCountryChange(): void {
    const countryId = this.locationForm.get('country')?.value;
    if (countryId) {
      this.provinceService.get(countryId).subscribe(provinces => {
        this.provinces = provinces;
        this.locationForm.get('province')?.setValue('');
      });
    } else {
      this.provinces = [];
    }
  }
}
