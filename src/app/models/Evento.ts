import { Lote } from './Lote';
import { RedeSocial } from './RedeSocial';

export interface Evento {
  id: number;
  eventoId: number;
  tema: string;
  local: string;
  foto: string;
  qtdPessoas: number;
  dataEvento?: Date;
  telefone: string;
  email: string;
  lotes: Lote[];
  redesSociais: RedeSocial[];
}
