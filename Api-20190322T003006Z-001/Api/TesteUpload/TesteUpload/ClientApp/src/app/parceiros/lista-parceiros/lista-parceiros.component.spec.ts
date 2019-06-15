import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaParceirosComponent } from './lista-parceiros.component';

describe('ListaParceirosComponent', () => {
  let component: ListaParceirosComponent;
  let fixture: ComponentFixture<ListaParceirosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaParceirosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaParceirosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
