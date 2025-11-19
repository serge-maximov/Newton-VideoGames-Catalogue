import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VGameListComponent } from './vgame-list.component';

describe('VgameList', () => {
  let component: VGameListComponent;
  let fixture: ComponentFixture<VGameListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VGameListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VGameListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
