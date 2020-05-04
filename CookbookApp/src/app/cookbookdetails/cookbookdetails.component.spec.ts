import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CookbookdetailsComponent } from './cookbookdetails.component';

describe('CookbookListComponent', () => {
  let component: CookbookdetailsComponent;
  let fixture: ComponentFixture<CookbookdetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CookbookdetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CookbookdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
