import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";

import { AuthenticationService } from '../services';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor{

    constructor(private authenticationService: AuthenticationService){}
    intercept(request: HttpRequest<any>, next: HttpHandler):Observable<HttpEvent<any>>{
        return next.handle(request).pipe(catchError((error:HttpErrorResponse) => {
            console.log(error);
            if(error.status === 401){
                this.authenticationService.logout();
                location.reload(true);
            } else if(error.status === 404){
                return throwError('Não foi possível estabelecer conexão com o servidor. Tente novamente.');
            }


            const errorMessage = error.error.message || error.statusText;
            return throwError(errorMessage);
        }))
    }
}