import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VGameEditComponent } from './vgame-edit.component';

describe('VgameEdit', () => {
  let component: VGameEditComponent;
  let fixture: ComponentFixture<VGameEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VGameEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VGameEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
