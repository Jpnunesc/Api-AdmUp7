import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastraRifasComponent } from './cadastra-rifas.component';

describe('CadastraRifasComponent', () => {
  let component: CadastraRifasComponent;
  let fixture: ComponentFixture<CadastraRifasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastraRifasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastraRifasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
