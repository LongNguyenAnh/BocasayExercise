import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { SampleModel } from '../_models/sample-model';
import { SampleService } from '../_services/sample.service';

@Component({
    selector: 'form-sample',
    templateUrl: './sample.component.html'
 })

 export class SampleComponent {
    sampleForm: FormGroup;
    loading = false;
    submitted = false;
    isSuccess = false;

    constructor(private formBuilder: FormBuilder, private sampleService: SampleService) { 
        this.sampleForm = this.formBuilder.group({
            firstname: ['', Validators.required],
            lastname: ['', Validators.required]
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.sampleForm.controls; }

    onClickSubmit(submitData: SampleModel)
    {
        this.submitted = true;
        this.isSuccess = false;
        // stop here if form is invalid
        if (this.sampleForm.invalid) {
            return;
        }
        this.loading = true;
        this.sampleService.post(submitData).pipe(first()).subscribe(s => {
            if (s.result == 'error')
            {
                alert(s.message);
            }
            else{
                alert(s.result);
            }
            this.loading = false;
            this.resetForm(this.sampleForm);
        })
    }

    resetForm(form: FormGroup) {
        form.reset();
        Object.keys(form.controls).forEach(key => {
          form.get(key)?.setErrors(null) ;
        });
    }
 }