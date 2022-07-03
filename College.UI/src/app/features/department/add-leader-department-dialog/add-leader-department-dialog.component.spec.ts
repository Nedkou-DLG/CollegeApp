import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLeaderDepartmentDialogComponent } from './add-leader-department-dialog.component';

describe('AddLeaderDepartmentDialogComponent', () => {
  let component: AddLeaderDepartmentDialogComponent;
  let fixture: ComponentFixture<AddLeaderDepartmentDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddLeaderDepartmentDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLeaderDepartmentDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
