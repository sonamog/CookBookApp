import { Injectable } from '@angular/core';
import { Recipe} from './recipe.model';
import { Http, Response, Headers, RequestOptions, RequestMethod, Jsonp } from '@angular/http';
import { Observable} from 'rxjs';
import { HttpClient, HttpHeaders} from '@angular/common/http';
// import { of } from 'rxjs/observable/of';
// import { HttpParams } from '@angular/common/http';
// import 'rxjs/add/operator/map';
// import 'rxjs/add/operator/toPromise';

const httpOptions={
headers: new HttpHeaders({'Content-Type':'application/x-www-form-urlencoded'})
};

@Injectable()

export class RecipeService {
  private recipeUrl='http://localhost:55776/api/Recipes'; // Url to web api
  
  constructor(private http: HttpClient) { } 

  getRecipeList(): Observable<Recipe[]>{   
    return this.http.get<Recipe[]>(this.recipeUrl);    
  }
  
  getRecipe(id:number):Observable<Recipe>{
      const url=this.recipeUrl+id;
      return this.http.get<Recipe>(url);
  }

  addRecipe(newrep:Recipe):Observable<Recipe>{     
      var newRecipeString = JSON.stringify(newrep);
      return this.http.post<Recipe>(this.recipeUrl+"?recipe="+newRecipeString, null, httpOptions);      
  }

  updateRecipe(newrep:Recipe):Observable<Recipe>{
      var newRecipeString = JSON.stringify(newrep);
      return this.http.post<Recipe>(this.recipeUrl+"?recipe="+newRecipeString, null, httpOptions);
  }

  deleteRecipe(id:number):any{ 
    const url=this.recipeUrl+id;
    var res = this.http.delete(url).subscribe();  
  }
}