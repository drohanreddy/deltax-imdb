import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule, FormControl } from '@angular/forms';
@Component({
    templateUrl: "./actorform.component.html",
    selector:'app-actor-form'
})
export class ActorForm {
    actorForm:FormGroup;
    constructor(private fb: FormBuilder) {
        this.setDefaultForm();
    }

    setDefaultForm() {
        this.actorForm = this.fb.group({
          actorName: new FormControl("", [Validators.required, Validators.minLength(2)]),
          plot: new FormControl("", [Validators.required, Validators.minLength(100)])
        });
      }
}
