import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PendentesRifasComponent } from './pendentes-rifas.component';

describe('PendentesRifasComponent', () => {
  let component: PendentesRifasComponent;
  let fixture: ComponentFixture<PendentesRifasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PendentesRifasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PendentesRifasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
