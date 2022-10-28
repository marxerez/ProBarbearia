import { Usuario } from "./identity/Usuario";
import { UsuarioProfissional } from "./identity/UsuarioProfissional";

export class Profissional {
  userId: number = 0;
  user!: UsuarioProfissional;
  estabelecimentoId: number =0;
}
