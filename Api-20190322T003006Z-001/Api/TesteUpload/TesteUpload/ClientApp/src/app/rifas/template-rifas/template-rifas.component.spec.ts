import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateRifasComponent } from './template-rifas.component';

describe('TemplateRifasComponent', () => {
  let component: TemplateRifasComponent;
  let fixture: ComponentFixture<TemplateRifasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TemplateRifasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateRifasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
