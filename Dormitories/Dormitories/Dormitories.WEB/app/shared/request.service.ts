import {Injectable}     from '@angular/core';
import {Http, Response, Headers, RequestOptions} from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class RequestService {
    //todo: add token for all request
    constructor(private http: Http) {

    }

    private _baseUrl = 'api/';

    get(url: String) {
        let temp = '';
        return this.http.get(this._baseUrl + url)
            //.map(res => res.json())
            //.do(data => console.log(data))
            .catch(this.handleError);
    }

    post(url: String, obj: any) {
        //let body = JSON.stringify(inputBody);
        //let headers = new Headers({ 'Content-Type': 'application/json' });
        // let options = new RequestOptions({ headers: headers });

        return this.http.post(this._baseUrl + url, obj)
            //.map(res => res.json())
            .catch(this.handleError)
    }

    put(url: String, obj: any) {
        return this.http.put(this._baseUrl + url, obj)
            //.map(res => res.json())
            .catch(this.handleError)
    }

    delete(url: String) {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.delete(this._baseUrl + url, options)
            //.map(res => res.json())
            .catch(this.handleError)
    }

    private handleError(error: Response) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}
