using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „RestService” w kodzie, usłudze i pliku konfiguracji.
    // UWAGA: aby uruchomić klienta testowego WCF w celu przetestowania tej usługi, wybierz plik RestService.svc lub RestService.svc.cs w eksploratorze rozwiązań i rozpocznij debugowanie.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RestService : IRestService
    {
        private static List<Car> cars = new List<Car>()
        {
            new Car()
            {
                Id = 1,
                Brand = "BMW",
                Hp = 168.5
            },
             new Car()
            {
                Id = 2,
                Brand = "Opel",
                Hp = 120
            }, new Car()
            {
                Id = 3,
                Brand = "Koenigsegg",
                Hp = 899.2
            },
        };

        public string addJson(Car car)
        {
            return addXml(car);
        }

        public string addXml(Car car)
        {
            if (car == null)
                throw new WebFaultException<string>("400: Bad Rrquest", HttpStatusCode.BadRequest);

            bool containsCar = cars.Any(c => c.Id == car.Id);

            if (containsCar)
                throw new WebFaultException<string>("409: Conflict", HttpStatusCode.Conflict);

            cars.Add(car);

            return $"Added new Car. ID = {car.Id}";
        }

        public Car deleteJson(string id)
        {
            return deleteXml(id);
        }

        public Car deleteXml(string id)
        {
            int carId = int.Parse(id);
            var founcCar = cars.FirstOrDefault(c => c.Id == carId);

            if (founcCar == null)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            cars.Remove(founcCar);

            return founcCar;
        }

        public List<Car> getAllJson()
        {
            return getAllXml();
        }

        public List<Car> getAllXml()
        {
            return cars;
        }

        public Car getByIdJson(string id)
        {
            return getByIdXml(id);
        }

        public Car getByIdXml(string id)
        {
            int carId = int.Parse(id);
            var founcCar = cars.FirstOrDefault(c => c.Id == carId);

            if (founcCar == null)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            return founcCar;
        }
    }

}
