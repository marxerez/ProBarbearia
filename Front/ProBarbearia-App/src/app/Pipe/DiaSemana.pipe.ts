import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'DiaSemana'
})
export class DiaSemanaPipe implements PipeTransform {

  transform(day: any): any {


    switch (day) {
      case 0:
        return "Domingo";
        break;
      case 1:
        return "Segunda";
        break;
      case 2:
        return "Terça";
        break;
      case 3:
        return "Quarta";
        break;
      case 4:
        return "Quinta";
        break;
      case 5:
        return "Sexta";
        break;
      case 6:
        return "Sãbado";
        break;

    }

  }

}
