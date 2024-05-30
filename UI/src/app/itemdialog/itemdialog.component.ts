import { Component, OnInit, Input, input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';

import { Item } from '../model/item';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-itemdialog',
  standalone: true,
  imports: [
    CommonModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatDialogModule,
    MatButtonModule,
  ],
  templateUrl: './itemdialog.component.html',
  styleUrl: './itemdialog.component.scss'
})

export class ItemdialogComponent implements OnInit {
  item : Item;
  public id : any;

  constructor(private http : HttpClient){
    this.item = {};
  }
  ngOnInit(): void {

  }

  public setItem(item : Item) : void{
    this.item.id = item.id;
    this.item.name = item.name;
    this.item.description = item.description;
    this.item.category = item.category;
    this.item.url = item.url; 
  }
}
