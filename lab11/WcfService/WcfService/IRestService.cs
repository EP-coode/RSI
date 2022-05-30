using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IRestService” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IRestService
    {

        [OperationContract]
        [WebGet(UriTemplate = "/Car")]
        List<Car> getAllXml();

        [OperationContract]
        [WebGet(UriTemplate = "/Car/{id}")]
        Car getByIdXml(string id);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/Car",
            Method = "POST",
            RequestFormat = WebMessageFormat.Xml)]
        string addXml(Car car);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/Car/{id}",
            Method = "DELETE")]
        Car deleteXml(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/Car", ResponseFormat = WebMessageFormat.Json)]
        List<Car> getAllJson();

        [OperationContract]
        [WebGet(UriTemplate = "/json/Car/{id}", ResponseFormat = WebMessageFormat.Json)]
        Car getByIdJson(string id);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/json/Car",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string addJson(Car car);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/json/Car/{id}",
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        Car deleteJson(string id);


        [OperationContract]
        [WebInvoke(
             UriTemplate = "/json/Car",
            Method = "PATCH",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        Car updateJson(Car car);


        [OperationContract]
        [WebInvoke(
             UriTemplate = "/info",
            Method = "GET")]
        string getInfo();
    }

    [DataContract]
    public class Car
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }
        [DataMember(Order = 1)]
        public string Brand { get; set; }
        [DataMember(Order = 2)]
        public double Hp { get; set; }
    }
}
