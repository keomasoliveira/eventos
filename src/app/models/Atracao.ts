import { RedeSocial } from './RedeSocial';

export interface Atracao {
  id: number;
  nome: string;

  tipoAtracao: string;

  imagemURL: string;
  telefone: string;
  email: string;
  redeSociais: RedeSocial;
}
