import { Component, OnInit, TemplateRef, ViewChild, viewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { RouterOutlet } from '@angular/router';

import { Item } from './model/item';
import { ItemService } from './services/item-service';

import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

import { ItemdialogComponent } from './itemdialog/itemdialog.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule, 
    RouterOutlet, 
    MatSlideToggleModule,
    MatGridListModule,
    MatCardModule,
    MatButtonModule,
    HttpClientModule,
    MatIconModule,
    MatDialogModule,
    ItemdialogComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})


export class AppComponent implements OnInit {

  @ViewChild('itemdialog',{static : true}) public child !: ItemdialogComponent;
  title = 'CodingExam';
  items : Item[] = [];
  selectedItem?: Item;
  headerNode = {
    header: new HttpHeaders(
      { 'rejectUnauthorized': 'false' }
      )
  }
  constructor(private http : HttpClient, public dialog: MatDialog){
    this.selectedItem = {};
  }

  ngOnInit(): void {
    this.getAllItems();
    //this.getItem();
  }

  public getAllItems() : void {
    this.http.get('https://localhost:5001/api/Items')
        .subscribe((items : any) => {
            this.items = items;
        });
  }

  viewItem(item : Item) : void {
     this.selectedItem = item;
     this.child.setItem(item);
    const dialogref = this.dialog.open(ItemdialogComponent);
  }

  // getItem() : void {
  //   this.http.get('https://localhost:5001/api/Items/cca4cf42-b2aa-4367-a251-8f10e8dfee9e')
  //   .subscribe((item : any) => {
  //       this.myItem = item;
  //       debugger;
  //   });
  // }
}
