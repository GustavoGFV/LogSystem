import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ApiRoutes } from "./routes/apiroutes";
import { Observable, catchError, throwError } from "rxjs";
import { LogDto } from "src/app/interface/log-dto";

@Injectable({
  providedIn: "root",
})
export class ApiService {
  constructor(private http: HttpClient, private routes: ApiRoutes) {}

  getAll(): Observable<LogDto[]> {
    return this.http.get<LogDto[]>(this.routes.loggerV1);
  }
  getId(id: number): Observable<LogDto[]> {
    return this.http.get<LogDto[]>(this.routes.loggerV1 + id);
  }
  getDate(initialDate: Date, finalDate: Date): Observable<LogDto[]> {
    return this.http.get<LogDto[]>(
      this.routes.loggerV1 + "Date/" + initialDate + "&" + finalDate
    );
  }
  getCode(code: string): Observable<LogDto[]> {
    return this.http.get<LogDto[]>(this.routes.loggerV1 + "Error/" + code);
  }
  getCodeDate(
    initialDate: Date,
    finalDate: Date,
    code: string
  ): Observable<LogDto[]> {
    return this.http.get<LogDto[]>(
      this.routes.loggerV1 +
        "Date/" +
        initialDate +
        "&" +
        finalDate +
        "/Error/" +
        code
    );
  }
}
