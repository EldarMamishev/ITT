import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPersonToFamilyComponent } from './add-person-to-family.component';

describe('AddPersonToFamilyComponent', () => {
  let component: AddPersonToFamilyComponent;
  let fixture: ComponentFixture<AddPersonToFamilyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPersonToFamilyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPersonToFamilyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
