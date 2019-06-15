import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaRifaComponent } from './lista-rifa.component';

describe('ListaRifaComponent', () => {
  let component: ListaRifaComponent;
  let fixture: ComponentFixture<ListaRifaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaRifaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaRifaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
