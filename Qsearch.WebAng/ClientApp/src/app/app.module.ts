import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { QsearchComponent } from './qsearch/qsearch.component';
import { HttpClient } from '@angular/common/http';
import { Configuration } from './configuration';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    QsearchComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,    
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'qsearch', component: QsearchComponent },
    ])
  ],
  providers: [Configuration],
  bootstrap: [AppComponent]
})
export class AppModule {
  clientConfiguration: any;  

  constructor(private http: HttpClient, private configuration: Configuration) {

    console.log('APP STARTING');
    this.http.get('/api/ClientAppSettings').subscribe(result => {
      this.clientConfiguration = result;
      this.configuration.searchApiUrl = this.clientConfiguration.searchApiUrl;
    }, error => { console.error(error) });
  }


  configClient() {

    // console.log('window.location', window.location);
    // console.log('window.location.href', window.location.href);
    // console.log('window.location.origin', window.location.origin);    
  }
}
