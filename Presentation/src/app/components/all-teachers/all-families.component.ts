import { Component, OnInit } from '@angular/core';
import { Family } from 'src/app/entities/family';
import { FamilyService } from '../family.service';
import { getAllDebugNodes } from '@angular/core/src/debug/debug_node';

@Component({
  selector: 'app-all-families',
  templateUrl: './all-families.component.html',
  styleUrls: ['./all-families.component.css']
})
export class AllFamiliesComponent implements OnInit {
  public families : Family[];
  
  constructor(private familyService : FamilyService) { }

  ngOnInit() {
    this.getAll();
  }  

  getAll() : void {
    this.familyService.getFamilies().subscribe(families => this.families = families);
  }
}
