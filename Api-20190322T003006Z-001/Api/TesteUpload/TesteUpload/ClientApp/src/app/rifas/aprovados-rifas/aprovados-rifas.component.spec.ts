import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AprovadosRifasComponent } from './aprovados-rifas.component';

describe('AprovadosRifasComponent', () => {
  let component: AprovadosRifasComponent;
  let fixture: ComponentFixture<AprovadosRifasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AprovadosRifasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AprovadosRifasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
