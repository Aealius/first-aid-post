import { Component, Inject } from "@angular/core";
import { DataService } from "../data-service";
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DateAdapter } from "@angular/material/core";

@Component({
  selector: 'add-students-dialog',
  templateUrl: 'add-students-dialog.html',
})
export class AddStudentsDialog {
  name: string = '';
  surname: string = '';
  lastname: string = '';
  sex: string = '';
  birthDate = new Date();
  enrollDate = new Date();
  expulsionDate = new Date();
  facultyId: number | undefined;
  specialityId: number | undefined;
  groupId: number | undefined;

  groups: any;
  faculties: any;
  specialities: any;

  isNameNeed = false;
  isSurnameNeed = false;
  isLastnameNeed = false;
  isBirthDateNeed = false;
  isEnrollDateNeed = false;
  isExpulsionDateNeed = false;
  isSexNeed = false;
  isGroupIdNeed = false;
  isSpecialityIdNeed = false;
  isFacultyIdNeed = false;

  constructor(public dialogRef: MatDialogRef<AddStudentsDialog>, @Inject(MAT_DIALOG_DATA) public data: any, private dateAdapter: DateAdapter<Date>) {
    this.dateAdapter.setLocale('ru-RU');
    this.groups = data.groups;
    this.faculties = data.faculties;
    this.specialities = data.specialities;

    if (data.status == "update") {
      this.name = data.name;
      this.surname = data.surname;
      this.lastname = data.lastname;
      this.facultyId = data.facultyId;
      this.groupId = data.groupId;
      this.specialityId = data.specialityId;
      this.sex = data.sex;
      this.birthDate = data.birthDate;
      this.enrollDate = data.enrollDate;
      this.expulsionDate = data.expulsionDate;
    }
    
  }

  closeDialog() {
    let needReturn = false;

    if (this.name == '') {
      needReturn = true;
      this.isNameNeed = true;

    }
    else {
      this.isNameNeed = false;
    }

    if (this.surname == '') {
      needReturn = true;
      this.isSurnameNeed = true;

    }
    else {
      this.isSurnameNeed = false;
    }

    if (this.lastname == '') {
      needReturn = true;
      this.isLastnameNeed = true;

    }
    else {
      this.isLastnameNeed = false;
    }

    if (this.enrollDate == null) {
      needReturn = true;
      this.isEnrollDateNeed = true;

    }
    else {
      this.isEnrollDateNeed = false;
    }

    if (this.expulsionDate == null) {
      needReturn = true;
      this.isExpulsionDateNeed = true;

    }
    else {
      this.isExpulsionDateNeed = false;
    }

    if (this.birthDate == null) {
      needReturn = true;
      this.isBirthDateNeed = true;

    }
    else {
      this.isBirthDateNeed = false;
    }

    if (this.sex == '') {
      needReturn = true;
      this.isSexNeed = true;

    }
    else {
      this.isSexNeed = false;
    }

    if (this.facultyId == null) {
      needReturn = true;
      this.isFacultyIdNeed = true;

    }
    else {
      this.isFacultyIdNeed = false;
    }

    if (this.groupId == null) {
      needReturn = true;
      this.isGroupIdNeed = true;

    }
    else {
      this.isGroupIdNeed = false;
    }

    if (this.specialityId == null) {
      needReturn = true;
      this.isSpecialityIdNeed = true;

    }
    else {
      this.isSpecialityIdNeed = false;
    }

    if (needReturn) {
      return;
    }

    let data = {
      name: this.name,
      surname: this.surname,
      lastname: this.lastname,
      sex: this.sex,
      birthDate: this.birthDate,
      enrollDate: this.enrollDate,
      expulsionDate: this.expulsionDate,
      groupId: this.groupId,
      facultyId: this.facultyId,
      specialityId: this.specialityId,
    }

    this.dialogRef.close(data);
  }
}
