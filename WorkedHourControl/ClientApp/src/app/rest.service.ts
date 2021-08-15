import { HttpClient, HttpEvent } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthService } from "./auth.service";

@Injectable()
export class RestService {
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private service: AuthService) {
    }

    get<T>(url: string, sendReader = true) {
        let header;
        if (sendReader)
            header = this.service.getHeader();
        return this.http.get<T>(this.baseUrl + 'api/' + url, header)
    }

    post<T>(url: string, payload: any, sendReader = true) {
        let header;
        if (sendReader)
            header = this.service.getHeader();
        return this.http.post<T>(this.baseUrl + 'api/' + url, payload, header)
    }

    put<T>(url: string, payload: any, sendReader = true) {
        let header;
        if (sendReader)
            header = this.service.getHeader();
        return this.http.put<T>(this.baseUrl + 'api/' + url, payload, header)
    }
}