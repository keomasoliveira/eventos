import { HttpClient } from '@angular/common/http';
import { Component, Injectable, OnInit } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnInit {
  widthImg: number = 100;
  showImg: boolean = true;
  private _filterList: string = '';
  events: any = [];
  eventosfiltrados: any = [];

  public get filterList() {
    return this._filterList;
  }
  public set filterList(value: string) {
    this._filterList = value;
    this.eventosfiltrados = this.filterList
      ? this.filtrarEventos(this.filterList)
      : this.events;
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.events.filter(
      (event: any) => event.eventName.toLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getevents();
  }

  AlterImg() {
    this.showImg = !this.showImg;
  }

  public getevents() {
    this.http
      .get(
        'https://my-json-server.typicode.com/keomasoliveira/api-fake/eventos'
      )
      .subscribe(
        (response) => {
          this.events = response;
          this.eventosfiltrados = this.events;
        },
        (error) => console.log(error)
      );
  }
}
