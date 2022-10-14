import { Time } from "@angular/common";
import { Horario } from "./Horario";
import { Profissional } from "./Profissional";
import { ProfissionalHorario } from "./ProfissionalHorario";

export class AgrupadoPorProfissionalHorario {

    profissional!: Profissional;
    profissionalHorariosAgrupado: ProfissionalHorario[]=[];
}
