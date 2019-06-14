import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastraCarrosComponent } from './cadastra-carros.component';

describe('CadastraCarrosComponent', () => {
  let component: CadastraCarrosComponent;
  let fixture: ComponentFixture<CadastraCarrosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastraCarrosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastraCarrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
