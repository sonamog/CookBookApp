import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../shared/recipe.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Recipe } from '../shared/recipe.model';
import { ToastrService } from 'ngx-toastr'
import { filterTablePipe } from '../myfilter/table-filter';

@Component({
  selector: 'app-cookbook-list',
  templateUrl: './cookbook-list.component.html',
  styleUrls: ['./cookbook-list.component.css']
})

export class CookbookListComponent implements OnInit {
  // for create a new recipe
  // recipes: Recipe[];
  category:string="";
  namerecipe:string;
  description:string;
  datecreate:Date;
  Recipe_Id:number;
  
  p: number = 1;
  entries: number = 5; 
  Recipes: Recipe[];
  desc:boolean=false;
  sortby:string='';
  checkedbox:boolean=false;
  left_count:number=255;

  
  constructor(private RecipeService: RecipeService, 
    private popup: NgbModal, 
    private toastr: ToastrService) { }

  ngOnInit() {
    this.getList();
  }

  getList(): void {
    this.RecipeService.getRecipeList()
       .subscribe(data => this.Recipes=data);
  }

  CharCountLeft():void{
    this.left_count=255-this.description.length;
  }

  addRecipe():void{
     //debugger;
     var newRecipe:Recipe=new Recipe();
     newRecipe.Recipe_Category=this.category;
     newRecipe.Recipe_name=this.namerecipe;
     newRecipe.Recipe_Description=this.description;
     newRecipe.Recipe_Date=this.datecreate;
     this.RecipeService.addRecipe(newRecipe).subscribe(data=>this.Recipes.push(data as Recipe)); 
     this.toastr.success('New Record Added Succcessfully', 'Recipe Details');  
     this.getList();
  }

  getRecipe(recipe:Recipe):void{   
    this.category = recipe.Recipe_Category;
    this.namerecipe =recipe.Recipe_name;
    this.description = recipe.Recipe_Description
    this.datecreate = recipe.Recipe_Date  
    this.Recipe_Id =recipe.Recipe_Id;
  }

  UpdateRecipe():void{
      //debugger;
     var uprecipe=new Recipe();
     uprecipe.Recipe_Id=this.Recipe_Id;
     uprecipe.Recipe_Date=this.datecreate;
     uprecipe.Recipe_Description=this.description;
     uprecipe.Recipe_name = this.namerecipe;
     uprecipe.Recipe_Category = this.category ;
     this.RecipeService.updateRecipe(uprecipe).subscribe(()=>{
     this.getList();
     this.toastr.info('Record Updated Succcessfully', 'Recipe Details');
     });  
  }

  //order by for the dropdown if user selects options
  sortOrder():void {   
    if(this.sortby==""){
      this.Recipes.sort(function(a,b){
        return a.Recipe_Id>b.Recipe_Id? 1 : ((a.Recipe_Id<b.Recipe_Id)? -1 : 0);
      });
    }
    else if (this.sortby =='RecipeDate'){
      this.Recipes.sort( function(a,b){
        return a.Recipe_Date>b.Recipe_Date? 1 : (a.Recipe_Date<b.Recipe_Date? -1 : 0);
      });
    }      
    else if (this.sortby =='RecipeCategory'){
      this.Recipes.sort(function(a,b){
        return(a.Recipe_Category>b.Recipe_Category ? 1: ((a.Recipe_Category < b.Recipe_Category)? -1: 0));
      });
    }
    if (this.desc){
      this.Recipes.reverse();
    }        
  } 
}
