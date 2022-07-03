import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentCoursesListComponent } from './student-courses-list.component';

describe('StudentCoursesListComponent', () => {
  let component: StudentCoursesListComponent;
  let fixture: ComponentFixture<StudentCoursesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentCoursesListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentCoursesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
