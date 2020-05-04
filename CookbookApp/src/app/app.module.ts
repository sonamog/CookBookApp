import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';
import { AppComponent } from './app.component';
import { CookbookdetailsComponent } from './cookbookdetails/cookbookdetails.component';
import { CookbookListComponent } from './cookbookdetails/cookbook-list/cookbook-list.component';
import { HomeComponent } from './cookbookdetails/home/home.component';
import { ContactComponent } from './cookbookdetails/contact/contact.component';
import { Routes, RouterModule } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RecipeService } from '../app/cookbookdetails/shared/recipe.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { filterTablePipe } from './cookbookdetails/myfilter/table-filter';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'cookbooklist', component: CookbookdetailsComponent }, 
  { path: 'contact', component: ContactComponent },
  { path: 'recipelist', component: CookbookListComponent }
  ]; 

@NgModule({
  declarations: [filterTablePipe,
    AppComponent,
    CookbookdetailsComponent,
    CookbookListComponent,
    HomeComponent,
    ContactComponent],

  imports: [NgxPaginationModule,NgbModule.forRoot(),
    HttpClientModule,
    FormsModule,RouterModule.forRoot(appRoutes),
    BrowserModule,BrowserAnimationsModule,
    ToastrModule.forRoot()],

  providers: [RecipeService],

  bootstrap: [AppComponent]

})

export class AppModule { }
