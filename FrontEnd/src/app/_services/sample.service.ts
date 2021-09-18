import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Globals } from '../_shared/global';
import { SampleModel } from '../_models/sample-model';
import { ResponseModel } from '../_models/response-model';
import { first } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class SampleService {

    constructor(
        private _http: HttpClient
    ) { }

    post(data: SampleModel): Observable<any> {
        console.log(data);
        let url = `${Globals.POST_SAMPLE_URL}`;
        return this._http
            .post(url, data);
    }
}