import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataService {

  private loginUrl = "/api/login";
  private studentsUrl = "/api/students";
  private facultyUrl = "/api/faculty";
  private groupUrl = "/api/group";
  private specialityUrl = "/api/speciality";
  private medicalcardUrl = "/api/medicalcard";
  private medicalcardRecordUrl = "/api/medicalcardRecord";
  private medexamUrl = "/api/medexam";
  private excerptrecordUrl = "/api/excerptrecord";
  private refferalrecordUrl = "/api/refferalrecord";
  private vactinationUrl = "/api/vactination";
  private certificateUrl = "/api/certificate";
  public user: any;

  constructor(private http: HttpClient) {
  }

  loginPost(login: string, password: string) {
    const body = { login: login, pwd: password };
    return this.http.post(this.loginUrl, body);
  }

  getStudentsData(searchLine: string) {
    return this.http.get(this.studentsUrl + '/all?searchLine=' + searchLine);
  }

  deletetudentsData(id: number) {
    return this.http.delete(this.studentsUrl + '/delete?id=' + id);;
  }

  savetudentsData(model: any) {
    return this.http.post(this.studentsUrl, model);
  }

  getFacultyData() {
    return this.http.get(this.facultyUrl + '/all');
  }

  getGroupData() {
    return this.http.get(this.groupUrl + '/all');
  }

  getSpecialityData() {
    return this.http.get(this.specialityUrl + '/all');
  }

  getMedCardData(id: number) {
    return this.http.get(this.medicalcardUrl + '?id=' + id);
  }

  getMedCardRecordsData(id: number) {
    return this.http.get(this.medicalcardRecordUrl + '/all?id=' + id);
  }

  getMedexamData(id: number) {
    return this.http.get(this.medexamUrl + '/all?id=' + id);
  }

  getExcerptrecordData(id: number) {
    return this.http.get(this.excerptrecordUrl + '/all?id=' + id);
  }

  getRefferalrecordData(id: number) {
    return this.http.get(this.refferalrecordUrl + '/all?id=' + id);
  }

  getVactinationData(id: number) {
    return this.http.get(this.vactinationUrl + '/all?id=' + id);
  }

  getCertificateData(id: number) {
    return this.http.get(this.certificateUrl + '/all?id=' + id);
  } 
}
