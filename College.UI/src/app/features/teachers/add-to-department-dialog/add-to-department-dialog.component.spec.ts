import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddToDepartmentDialogComponent } from './add-to-department-dialog.component';

describe('AddToDepartmentDialogComponent', () => {
  let component: AddToDepartmentDialogComponent;
  let fixture: ComponentFixture<AddToDepartmentDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddToDepartmentDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddToDepartmentDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
