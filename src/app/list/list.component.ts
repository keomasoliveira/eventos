import { Component, OnInit } from '@angular/core';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/Evento.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnInit {
  public widthImg: number = 200;
  public showImg: boolean = true;
  private FILTRO_LISTA: string = '';

  public eventos: Evento[] = [];
  public eventosfiltrados: Evento[] = [];

  public get filtroLista() {
    return this.FILTRO_LISTA;
  }
  public set filtroLista(value: string) {
    this.FILTRO_LISTA = value;
    this.eventosfiltrados = this.filtroLista
      ? this.filtrarEventos(this.filtroLista)
      : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (event: Evento) => event.tema.toLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private eventoService: EventoService) {}

  public ngOnInit() {
    this.GetEvents();
  }

  public AlterImg() {
    this.showImg = !this.showImg;
  }

  public GetEvents() {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosfiltrados = this.eventos;
      },
      error: (error: any) => console.log(error),
    });
  }
}
