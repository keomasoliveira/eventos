import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/Evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss'],
})
export class EventoListaComponent implements OnInit {
  public modalRef?: BsModalRef;
  public message?: string;
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

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) {}

  public ngOnInit() {
    this.spinner.show();
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
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar os eventos', 'Erro!');
      },
      complete: () => this.spinner.hide(),
    });
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O Evento foi deletado com sucesso.', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }
  detalheEvento(id: number) {
    this.router.navigate([`eventos/detalhe/${id}`]);
  }
}
