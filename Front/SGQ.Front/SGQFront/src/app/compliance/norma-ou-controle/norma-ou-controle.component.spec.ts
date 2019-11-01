import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NormaOuControleComponent } from './norma-ou-controle.component';

describe('NormaOuControleComponent', () => {
  let component: NormaOuControleComponent;
  let fixture: ComponentFixture<NormaOuControleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NormaOuControleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NormaOuControleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
