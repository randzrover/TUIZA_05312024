import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Item } from '../model/item';
import { Constant } from '../model/constant';

@Injectable({
    providedIn: 'root',
  })

export class ItemService {
    http = inject(HttpClient);
    
    
    
    getItems () : any {
        this.http.get(Constant.GetItems)
        .subscribe((items : any) => {
            return items;
        })
    }
}