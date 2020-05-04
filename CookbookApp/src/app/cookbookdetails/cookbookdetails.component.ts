import {Component, OnInit} from '@angular/core';
import {Recipe} from './shared/recipe.model';
import {RecipeService} from '../cookbookdetails/shared/recipe.service';


@Component({
  selector: 'app-cookbookdetails',
  templateUrl: './cookbookdetails.component.html',
  styleUrls: ['./cookbookdetails.component.css']
})

export class CookbookdetailsComponent implements OnInit {
  
  constructor() { }

  ngOnInit() {
 
  }
  
}
