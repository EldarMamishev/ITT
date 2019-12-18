import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CONNECTION_PATH } from '../constants/default-constants';
import { FamiliesByPersonComponent } from './families-by-person/families-by-person.component';
import { AllFamiliesComponent } from './all-families/all-families.component';
import { CreateFamilyComponent } from './create-family/create-family.component';

const routes: Routes = [
  { path: '', redirectTo: 'all', pathMatch: 'full' },

  { path: 'all', component: AllFamiliesComponent},
  { path: 'person', component: FamiliesByPersonComponent },
  { path: 'create', component: CreateFamilyComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FamilyRoutingModule { }
