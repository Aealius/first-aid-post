import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from '../data-service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'detailsPage',
  templateUrl: './details.html',
  styleUrls: ['./details.css']
})
export class DetailComponent implements OnInit, AfterViewInit {
  studentId: number;
  id = 0;
  weight = '';
  height = '';
  bloodTypeName = '';
  healthGroupName = '';
  medcardData: any;
  excerptrecordData: any;
  refferalrecordData: any;
  certificatenData: any;
  vactinationData: any;
  medexemData: any;

  medcardRecordData: any;

  displayedColumns: string[] = ['no', 'complaints', 'diagnosis', 'visitDate'];
  dataSource!: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private dataService: DataService, private router: Router, private activateRoute: ActivatedRoute) {
    this.studentId = activateRoute.snapshot.params["id"];

    if (this.dataService.user == null || this.dataService.user.userId == null) {
      this.router.navigate(['/login']);
    }
  }

  ngOnInit() {
    this.dataService.getMedCardData(this.studentId).subscribe((dataCard: any) => {
      this.medcardData = dataCard;

      this.weight = dataCard.weight;
      this.height = dataCard.height;
      this.bloodTypeName = dataCard.bloodTypeName;
      this.healthGroupName = dataCard.healthGroupName;
    });

    this.dataService.getMedexamData(this.studentId).subscribe((medexamData: any) => {
      this.medexemData = medexamData;
    });

    this.dataService.getExcerptrecordData(this.studentId).subscribe((excerptrecordData: any) => {
      this.excerptrecordData = excerptrecordData;

      for (var i = 0; i < this.excerptrecordData.length; i++) {
        let a = new Date(Date.parse(this.excerptrecordData[i].date)).toLocaleDateString();

        this.excerptrecordData[i].date = a;
      }
    });

    this.dataService.getRefferalrecordData(this.studentId).subscribe((refferalrecordData: any) => {
      this.refferalrecordData = refferalrecordData;

      for (var i = 0; i < this.refferalrecordData.length; i++) {
        let a = new Date(Date.parse(this.refferalrecordData[i].date)).toLocaleDateString();

        this.refferalrecordData[i].date = a;
      }
    });

    this.dataService.getVactinationData(this.studentId).subscribe((vactinationData: any) => {
      this.vactinationData = vactinationData;

      for (var i = 0; i < this.vactinationData.length; i++) {
        let a = new Date(Date.parse(this.vactinationData[i].immuneDate)).toLocaleDateString();

        this.vactinationData[i].immuneDate = a;
      }
    });

    this.dataService.getCertificateData(this.studentId).subscribe((certificatenData: any) => {
      this.certificatenData = certificatenData;

      for (var i = 0; i < this.certificatenData.length; i++) {
        let a = new Date(Date.parse(this.certificatenData[i].toDate)).toLocaleDateString();
        let b = new Date(Date.parse(this.certificatenData[i].fromDate)).toLocaleDateString();

        this.certificatenData[i].toDate = a;
        this.certificatenData[i].fromDate = b;
      }
    });

    this.dataService.getMedCardRecordsData(this.studentId).subscribe((data: any) => {
      this.medcardRecordData = data;

      this.dataSource = new MatTableDataSource<any>(data);
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator
  }

  back() {
    this.router.navigate(['/students']);
  }
}
