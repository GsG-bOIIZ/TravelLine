import { Injectable } from "@angular/core";
import { IGroup } from './group.interface';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class GroupService {
    private readonly apiUrl: string = 'http://localhost:4200/rest/group';

    constructor(private httpClient: HttpClient) {
    }

    public addGroup(group: IGroup): Observable<null> {        
        return this.httpClient.post<null>(`${this.apiUrl}/create`, group);
    }

    public deleteGroup(id: number): Observable<object> {
        return this.httpClient.delete(`${this.apiUrl}/delete/${id}`);
    }

    public getGroups(): Observable<IGroup[]> {
        return this.httpClient.get<IGroup[]>(`${this.apiUrl}/all`);
    }

    public updateGroup(group: IGroup): Observable<null> {
        return this.httpClient.post<null>(`${this.apiUrl}/update`, group);
    }

    public getGroupsWithFacultyId(id: number): Observable<IGroup[]> {
        return this.httpClient.get<IGroup[]>(`${this.apiUrl}/f/${id}`);
    }

    public getGroupByName(name: string): Observable<IGroup> {
        return this.httpClient.get<IGroup>(`${this.apiUrl}/name/${name}`);
    }
}
