import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDialogDepartmentComponent } from './add-dialog-department.component';

describe('AddDialogDepartmentComponent', () => {
  let component: AddDialogDepartmentComponent;
  let fixture: ComponentFixture<AddDialogDepartmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDialogDepartmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDialogDepartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
