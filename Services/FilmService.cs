using Interfaces;
using MovieTime.Models;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers;
using RestSharp.Serializers.Xml;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Diagnostics;

namespace Services
{

    public class FilmService : IFilmService
    {
        private ILogger<FilmService> _logger;

        public FilmService(ILogger<FilmService> logger)
        {
            this._logger = logger;
        }

        public IEnumerable<Films> GetFilms()
        {
            
            var client = new RestClient("https://5.formovietickets.com:2255/Data.ASP");
            client.Authenticator = new HttpBasicAuthenticator("test", "test");

            Uri u = new Uri("/", UriKind.Relative);

            var request = new RestRequest(u, Method.Post);
            request.RequestFormat = DataFormat.Xml;
            request.RootElement = "Response";
            request.AddHeader("Authorization", "Basic dGVzdDp0ZXN0");
            request.AddHeader("Content-Type", "application/xml");
            var body = @"<Request> " + "\n" +
            @"    <Version>1</Version> " + "\n" +
            @"    <Command>ShowTimeXml</Command> " + "\n" +
            @"    <ShowAvalTickets>1</ShowAvalTickets> " + "\n" +
            @"    <ShowSales>1</ShowSales> " + "\n" +
            @"    <ShowSaleLinks>1</ShowSaleLinks> " + "\n" +
            @"</Request>";
            request.AddParameter("application/xml", body, ParameterType.RequestBody);
            client.UseXmlSerializer();
            RestResponse response = client.Execute(request);
            
           

            _logger.LogError("Response Status Code: " + response.StatusCode.ToString());

            var dotNetXmlDeserializer = new DotNetXmlDeserializer(); //RestSharp.RestXmlRequest(); //   Deserializers.DotNetXmlDeserializer();
            dotNetXmlDeserializer.RootElement = "Response";
            var topResults = dotNetXmlDeserializer.Deserialize<ShowSchedule>(response);

            var results = topResults?.PerformanceScheduleResponse?.FilmList?.Films.AsEnumerable();

            return results;

        }


        public List<PerformanceScheduleRequest> GetRequest()
        {
            List<PerformanceScheduleRequest> performanceScheduleRequests = new List<PerformanceScheduleRequest>();
            PerformanceScheduleRequest PSR = new PerformanceScheduleRequest();

            PSR.Command = "ShowTimeXml";
            PSR.Version = "1";
            PSR.ShowSale = 1;
            PSR.ShowAvailTickets = 1;
            performanceScheduleRequests.Add(PSR);
            return performanceScheduleRequests;
        }
    }
}