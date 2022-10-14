import { AbstractControl, FormGroup } from "@angular/forms";

export class ValidaCampoSenha {
  static ValidaCampo(password: string, confirmeSenha: string): any {
    return (group: AbstractControl) => {
      const formGroup = group as FormGroup;
      const control = formGroup.controls[password];
      const matchingControl = formGroup.controls[confirmeSenha];

      if (matchingControl.errors && !matchingControl.errors.campoValidado) {
        return null;
      }

      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ campoValidado: true});
      } else {
        matchingControl.setErrors(null);
      }

      return null;
    };
  }
}
