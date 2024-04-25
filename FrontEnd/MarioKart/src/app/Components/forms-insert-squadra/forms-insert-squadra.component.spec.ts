import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormsInsertSquadraComponent } from './forms-insert-squadra.component';

describe('FormsInsertSquadraComponent', () => {
  let component: FormsInsertSquadraComponent;
  let fixture: ComponentFixture<FormsInsertSquadraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FormsInsertSquadraComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FormsInsertSquadraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
