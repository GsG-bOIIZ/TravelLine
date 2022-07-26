import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import {IStudent} from "./student.interface";
import {IGroup} from "./group.interface";

@Injectable()
export class StudentService {
    private readonly apiUrl: string = 'http://localhost:4200/rest/student';

    constructor(private httpClient: HttpClient) {
    }

    public addStudent(student: IStudent): Observable<null> {
        return this.httpClient.post<null>(`${this.apiUrl}/create`, student);
    }

    public deleteStudent(id: number): Observable<object> {
        return this.httpClient.delete(`${this.apiUrl}/delete/${id}`);
    }

    public getStudents(): Observable<IStudent[]> {
        return this.httpClient.get<IStudent[]>(`${this.apiUrl}/all`);
    }

    public updateStudent(student: IStudent): Observable<null> {
        return this.httpClient.post<null>(`${this.apiUrl}/update`, student);
    }

    public getStudentsWithClassId(id: number): Observable<IStudent[]> {
        return this.httpClient.get<IStudent[]>(`${this.apiUrl}/g/${id}`);
    }

    public getStudentByName(name: string): Observable<object> {
        return this.httpClient.get(`${this.apiUrl}/name/${name}`);
    }
}
