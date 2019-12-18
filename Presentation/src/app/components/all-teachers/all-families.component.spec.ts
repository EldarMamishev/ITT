import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllFamiliesComponent } from './all-families.component';

describe('AllFamiliesComponent', () => {
  let component: AllFamiliesComponent;
  let fixture: ComponentFixture<AllFamiliesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllFamiliesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllFamiliesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
