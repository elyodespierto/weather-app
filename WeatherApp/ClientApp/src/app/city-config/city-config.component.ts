import { Component, OnInit } from '@angular/core';
import { DataFormat, Options } from 'select2';
import { HttpClient, HttpHeaders } from '@angular/common/http';

class WeatherData {

}

@Component({
   selector: 'city-config',
   templateUrl: './city-config.component.html',
})
export class CityConfigComponent implements OnInit {
   cities = null;
   selectedCity = null;
   select2Options: Options;

   constructor(
      private http: HttpClient) { }

   ngOnInit(): void {
      this.select2Options = {
         minimumInputLength: 3,
         ajax: {
            url: '/api/cities',
            dataType: 'json',
            delay: 300,
            processResults: function (data) {
               return { results: data };
            }
         }
      }

      this.http.get('/api/citiesConfig').subscribe(cities => {
         this.cities = cities;
      })
   }

   deleteCity(){
      this.http.delete('/api/citiesConfig?cityId=' + this.selectedCity).subscribe(response => {
         this.http.get('/api/citiesConfig').subscribe(cities => {
            this.cities = cities;
         })
      })
   }

   addCity() {
      this.http.post('/api/citiesConfig', { cityId: Number(this.selectedCity)}).subscribe(response => {
         this.http.get('/api/citiesConfig').subscribe(cities => {
            this.cities = cities;
         })
      })
   }
}
