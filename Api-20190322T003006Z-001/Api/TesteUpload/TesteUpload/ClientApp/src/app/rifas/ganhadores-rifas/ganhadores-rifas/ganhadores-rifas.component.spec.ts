import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GanhadoresRifasComponent } from './ganhadores-rifas.component';

describe('GanhadoresRifasComponent', () => {
  let component: GanhadoresRifasComponent;
  let fixture: ComponentFixture<GanhadoresRifasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GanhadoresRifasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GanhadoresRifasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
