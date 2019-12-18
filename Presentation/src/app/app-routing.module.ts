import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FamiliesByPersonComponent } from './family/families-by-person/families-by-person.component';
import { FamilyModule } from './family/family.module';

const routes: Routes = [
  { path: '', redirectTo: 'family', pathMatch: 'full' },
 
  { path: 'family', loadChildren: () => FamilyModule }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
