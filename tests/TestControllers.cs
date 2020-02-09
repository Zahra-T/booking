using System;
using System.Collections.Generic;
using Xunit;
using RA;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Tests
{
    public class TestControllers

    {

        [Fact]
        public async void TestSalonGet()
        {
            var apiClient = new HttpClient();
            var apiResponse = await apiClient.GetAsync($"http://localhost:5000/api/v1/salons");
            Assert.True(apiResponse.IsSuccessStatusCode);
        }

        [Fact]
        public async void TestSalonPost()
        {
            SalonExample example = new SalonExample();
            example.Name = "Mario";
            example.SeatHeight = 1;
            example.SeatWidth = 1;
            example.DisplayLength = 5;
 

            var apiClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://localhost:5000/api/v1/salons"),
                Content = new StringContent(JsonConvert.SerializeObject(example),
                                        Encoding.UTF8 ,  "application/json")
                
            };
            var response = await apiClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void TestSalonUpdate()
        {
            SalonExample example = new SalonExample();
            example.Name = "Mario";
            example.SeatHeight = 1;
            example.SeatWidth = 1;
            example.DisplayLength = 5;
 

            var apiClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"http://localhost:5000/api/v1/salons/4"),
                Content = new StringContent(JsonConvert.SerializeObject(example),
                                        Encoding.UTF8 ,  "application/json")
            };
            var response = await apiClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void TestSalonDelete()
        {
            var apiClient = new HttpClient();
            var apiResponse = await apiClient.DeleteAsync($"http://localhost:5000/api/v1/salons/8");
            Assert.True(apiResponse.IsSuccessStatusCode);
        }




        [Fact]
        public async void TestShowGet()
        {
            var apiClient = new HttpClient();
            var apiResponse = await apiClient.GetAsync($"http://localhost:5000/api/v1/shows");
            Assert.True(apiResponse.IsSuccessStatusCode);
        }

        [Fact]
        public async void TestShowPost()
        {
            ShowExample example = new ShowExample();
            example.Title = "Shuttle Island 2";
            example.StartTime = new DateTime(2017, 1, 18);
            example.EndTime = new DateTime(2017, 1, 18);
            example.Summary = "a horror movie";
            example.Price = 20;
            example.SalonId = 6;

            var apiClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://localhost:5000/api/v1/shows"),
                Content = new StringContent(JsonConvert.SerializeObject(example),
                                        Encoding.UTF8 ,  "application/json")
                
            };
            var response = await apiClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void TestShowUpdate()
        {
            ShowExample example = new ShowExample();
            example.Title = "Shuttle Island 3";
            example.StartTime = new DateTime(2017, 1, 18);
            example.EndTime = new DateTime(2017, 1, 18);
            example.Summary = "a horror movie";
            example.Price = 20;
            example.SalonId = 3;

            var apiClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://localhost:5000/api/v1/shows"),
                Content = new StringContent(JsonConvert.SerializeObject(example),
                                        Encoding.UTF8 ,  "application/json")
                
            };
            var response = await apiClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void TestShowDelete()
        {
            var apiClient = new HttpClient();
            var apiResponse = await apiClient.DeleteAsync($"http://localhost:5000/api/v1/shows/8");
            Assert.True(apiResponse.IsSuccessStatusCode);
        }

        

        
    }

    public class ShowExample{
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Summary { get; set; }
        public int Price { get; set; }
        public int SalonId { get; set; }
    
    }

    public class SalonExample{

        public string Name { get; set; }

        public int SeatWidth { get; set; }

        public int SeatHeight { get; set; }

        public int DisplayLength { get; set; }
    }
}
