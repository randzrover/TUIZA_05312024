import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemdialogComponent } from './itemdialog.component';

describe('ItemdialogComponent', () => {
  let component: ItemdialogComponent;
  let fixture: ComponentFixture<ItemdialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ItemdialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ItemdialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
