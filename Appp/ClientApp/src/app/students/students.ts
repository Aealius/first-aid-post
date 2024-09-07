import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../data-service';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ThemePalette } from '@angular/material/core';
import { getLocaleDateFormat } from '@angular/common';
import { AddStudentsDialog } from './add-students-dialog';

@Component({
  selector: 'students',
  templateUrl: './students.html',
  styleUrls: ['./students.css']
})
export class StudentsComponent implements OnInit, AfterViewInit {
  user: any;
  searchLine: string = "";
  id: number = 0;

  displayedColumns: string[] = ['no', 'name', 'birthDate', 'faculty', 'group', 'speciality', 'enrollDate', 'expulsionDate'];
  dataSource!: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private dataService: DataService, private router: Router, private snackbar: MatSnackBar, public dialog: MatDialog) {
    this.user = dataService.user;
    if (this.user == null || this.user.userId == null) {
      this.router.navigate(['/login']);
    }
  }

  ngOnInit() {
    this.dataService.getStudentsData(this.searchLine).subscribe((data: any) => { this.dataSource = new MatTableDataSource<any>(data); });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator
  }

  openDialog(action: string) {
    if (action == 'delete') {
      this.deleteForm(this.id);
    }

    if (action == 'add') {
      let groups: any;
      let faculties: any;
      let specialities: any;

      this.dataService.getFacultyData().subscribe((data: any) => {
        faculties = data;

        this.dataService.getSpecialityData().subscribe((data2: any) => {
          specialities = data2;

          this.dataService.getGroupData().subscribe((data3: any) => {
            groups = data3;

            const dialogRef = this.dialog.open(AddStudentsDialog, {
              width: '500px',
              data: {
                status: 'new',
                groups: groups,
                specialities: specialities,
                faculties: faculties,
              },
            });

            dialogRef.afterClosed().subscribe((data: any) => {
              if (data != null) {
                this.dataService.savetudentsData(data).subscribe((data: any) => {
                  this.snackbar.open("Операция завершена", "", { duration: 5000 });
                  this.id = 0;
                  this.searchData();
                });
              }
            });
          });
        });
      });
    }

    if (action == 'modify') {
      let name = '';
      let surname = '';
      let lastname = '';
      let sex = '';
      let birthDate = '';
      let enrollDate = '';
      let expulsionDate = '';
      let facultyId = -1;
      let specialityId = -1;
      let groupId = -1;

      let groups: any;
      let faculties: any;
      let specialities: any;

      for (var i = 0; i < this.dataSource.data.length; i++) {
        if (this.dataSource.data[i].studentId == this.id) {
          name = this.dataSource.data[i].name;
          surname = this.dataSource.data[i].surname;
          lastname = this.dataSource.data[i].lastname;
          sex = this.dataSource.data[i].sex;
          birthDate = this.dataSource.data[i].birthDate;
          enrollDate = this.dataSource.data[i].enrollDate;
          expulsionDate = this.dataSource.data[i].expulsionDate;
          groupId = this.dataSource.data[i].groupId;
          specialityId = this.dataSource.data[i].specialityId;
          facultyId = this.dataSource.data[i].facultyId;
        }
      }

      this.dataService.getFacultyData().subscribe((data: any) => {
        faculties = data;

        this.dataService.getSpecialityData().subscribe((data2: any) => {
          specialities = data2;

          this.dataService.getGroupData().subscribe((data3: any) => {
            groups = data3;

            const dialogRef = this.dialog.open(AddStudentsDialog, {
              width: '500px',
              data: {
                status: 'update',
                name: name,
                surname: surname,
                lastname: lastname,
                sex: sex,
                birthDate: birthDate,
                expulsionDate: expulsionDate,
                enrollDate: enrollDate,
                facultyId: facultyId,
                groupId: groupId,
                specialityId: specialityId,
                groups: groups,
                specialities: specialities,
                faculties: faculties,
              },
            });

            dialogRef.afterClosed().subscribe((data: any) => {
              if (data != null) {
                data.studentId = this.id;
                this.dataService.savetudentsData(data).subscribe((data: any) => {
                  this.snackbar.open("Операция завершена", "", { duration: 5000 });
                  this.id = 0;
                  this.searchData();
                });
              }
            });
          });
        });
      });
    }
  }

  deleteForm(id: number) {
    this.snackbar.open("Операция завершена", "", { duration: 5000 });
    return this.dataService.deletetudentsData(id).subscribe((data: any) => { this.id = 0; this.searchData() });
  }

  searchData() {
    this.id = 0;
    this.dataService.getStudentsData(this.searchLine).subscribe((data: any) => { this.dataSource = new MatTableDataSource<any>(data); this.dataSource.paginator = this.paginator; })
  }

  openDetails() {
    this.router.navigate(['/detailsPage/' + this.id]);
  }
}
