using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Klient2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.WriteLine("Podaj format (xml lub json):");
                    string format = Console.ReadLine();
                    Console.WriteLine("Podaj metode (GET lub POST lub PUT):");
                    string method = Console.ReadLine();
                    Console.WriteLine("Podaj URI:");
                    string uri = Console.ReadLine();
                    HttpWebRequest req = WebRequest.Create(uri) as
                    HttpWebRequest;
                    req.KeepAlive = false;
                    req.Method = method.ToUpper();
                    if (format == "xml")

                        req.ContentType = "text/xml";
                    else if (format == "json")
                        req.ContentType = "application/json";
                    else
                    {
                        Console.WriteLine("Podales zle dane!");
                        return;
                    }
                    switch (method.ToUpper())
                    {
                        case "GET":
                            break;
                        // cont. on the next page

                        case "POST":
                            Console.WriteLine("Wklej zawartosc XML-a lub JSON - a(w jednej linii!)");
                            string dane = Console.ReadLine();
                            //przekodowanie tekstu wiadomosci:
                            byte[] bufor = Encoding.UTF8.GetBytes(dane);
                            req.ContentLength = bufor.Length;
                            System.IO.Stream postData = req.GetRequestStream();
                            postData.Write(bufor, 0, bufor.Length);
                            postData.Close();
                            break;
                        //tu ewentualnie kolejne opcje
                        case "PUT":
                            Console.WriteLine("Wklej zawartosc XML-a lub JSON - a(w jednej linii!)");
                            string dane2 = Console.ReadLine();
                            //przekodowanie tekstu wiadomosci:
                            byte[] bufor2 = Encoding.UTF8.GetBytes(dane2);
                            req.ContentLength = bufor2.Length;
                            System.IO.Stream postData2 = req.GetRequestStream();
                            postData2.Write(bufor2, 0, bufor2.Length);
                            postData2.Close();
                            break;
                        default:
                            break;
                    }
                    HttpWebResponse resp = req.GetResponse()
                    as HttpWebResponse;
                    //przekodowanie tekstu odpowiedzi:
                    Encoding enc = System.Text.Encoding.GetEncoding(1252);
                    StreamReader responseStream =
                    new StreamReader(resp.GetResponseStream(), enc);
                    string responseString = responseStream.ReadToEnd();
                    responseStream.Close();
                    resp.Close();
                    Console.WriteLine(responseString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("Do you want to continue?");
            } while (Console.ReadLine().ToUpper() == "Y");
        
    }
    }
}
