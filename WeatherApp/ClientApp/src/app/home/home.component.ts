import { Component, OnInit } from '@angular/core';
import { DataFormat, Options } from 'select2';
import { HttpClient, HttpHeaders } from '@angular/common/http';

class WeatherData {

}

@Component({
   selector: 'app-home',
   templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
   selectedCity: string = null;
   select2Options: Options;
   weatherData: WeatherData;
   loadHistory: boolean = false;
   history = null;

   constructor(
      private http: HttpClient) { }

   ngOnInit(): void {
      this.select2Options = {
         minimumInputLength: 3,
         ajax: {
            url: '/api/cities/enabled',
            dataType: 'json',
            delay: 300,
            processResults: function (data) {
               return { results: data };
            }
         }
      }
   }

   fetchWeatherData() {
      if (this.selectedCity) {
         this.http.get<WeatherData>('/api/weather?cityId=' + this.selectedCity).subscribe(weatherData => {
            this.weatherData = weatherData;
         })

         if (this.loadHistory) {
            this.http.get('/api/weatherHistory?cityId=' + this.selectedCity).subscribe(history => {
               this.history = history;
            })
         } else {
            this.history = null;
         }
      }
   }
}
