import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastraEventosComponent } from './cadastra-eventos.component';

describe('CadastraEventosComponent', () => {
  let component: CadastraEventosComponent;
  let fixture: ComponentFixture<CadastraEventosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastraEventosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastraEventosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
