import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Configuration } from '../configuration';

@Component({
  selector: 'app-qsearch',
  templateUrl: './qsearch.component.html',
  styleUrls: ['./qsearch.component.css']
})
export class QsearchComponent implements OnInit {
  public questions: Questions[];
    configuration: Configuration;
  httpclient: HttpClient;
  showspinner: boolean;

  constructor(http: HttpClient, configuration: Configuration) {
    this.configuration = configuration;
    this.httpclient = http;
    this.showspinner = false;
  }

  public getQuestionsFromApi(query: string) {
    this.showspinner = true;
    var self = this;
    this.httpclient.get<Questions[]>(this.configuration.searchApiUrl + '/api/v1/qsearch/search', {
        params: new HttpParams().set("query", query)
      }).subscribe(result => {
      self.showspinner = false;
      this.questions = result;
    }, error => { self.showspinner = false; console.error(error) });
  }

  ngOnInit() {
  }
}

export class Questions {
  constructor() {
    this.CreationDate = new Date();
    this.IsAnswered = true;
    this.OwnerDisplayName = "Nikolay Ivanov 2 3";  
  }

  link: string;
  title: string;
  CreationDate: Date;
  IsAnswered: boolean;
  OwnerDisplayName: string;  
}
