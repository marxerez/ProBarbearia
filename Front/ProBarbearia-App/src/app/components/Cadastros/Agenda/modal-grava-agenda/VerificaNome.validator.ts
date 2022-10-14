import { AbstractControl, AsyncValidatorFn, ValidationErrors, ValidatorFn } from "@angular/forms";

export function verificaNome(valor: number): ValidatorFn   {
  return (control: AbstractControl): ValidationErrors | null => {
    return (valor == 0) ? { testa: true } : null;

  }
}
