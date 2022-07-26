import { Injectable } from "@angular/core";
import { IFaculty } from './faculty.interface';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class FacultyService {
    private readonly apiUrl: string = 'http://localhost:4200/rest/faculty';

    constructor(private httpClient: HttpClient) {
    }

    public addFaculty(faculty: IFaculty): Observable<null> {
        
        return this.httpClient.post<null>(`${this.apiUrl}/create`, faculty);
    }

    public deleteFaculty(id: number): Observable<object> {
        return this.httpClient.delete(`${this.apiUrl}/delete/${id}`);
    }

    public getFaculties(): Observable<IFaculty[]> {
        return this.httpClient.get<IFaculty[]>(`${this.apiUrl}/all`);
    }

    public updateFaculty(faculty: IFaculty): Observable<null> {
        return this.httpClient.post<null>(`${this.apiUrl}/update`, faculty);
    }

    public getFacultyByName(name: string): Observable<IFaculty> {
        return this.httpClient.get<IFaculty>(`${this.apiUrl}/name/${name}`);
    }
}
