import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaInstituicaoComponent } from './lista-instituicao.component';

describe('ListaInstituicaoComponent', () => {
  let component: ListaInstituicaoComponent;
  let fixture: ComponentFixture<ListaInstituicaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaInstituicaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaInstituicaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
