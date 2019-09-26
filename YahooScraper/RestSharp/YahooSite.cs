using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using unirest_net.http;
using RestSharp.Authenticators;
using System.IO;



namespace YahooScraper.RestSharp
{
    public class YahooSite
    {

        public static void YahooAPI()
        {
            Console.WriteLine("Start");
            RestClient yahoo = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com");
            RestRequest request = new RestRequest("/market/get-summary?region=US&lang=en", Method.GET);
            request.AddHeader("X-RapidAPI-Host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("X-RapidAPI-Key", "bd2f89ddc5mshaafba2c2850cce3p1e4c01jsna4733c78a5d4");

            IRestResponse restResponse = yahoo.Execute(request);

            dynamic jStocks = JsonConvert.DeserializeObject(restResponse.Content);


            JArray stockResult = jStocks["marketSummaryResponse"]["result"];


            string type = "RS";

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestSharp;Integrated Security=True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                foreach (JToken stock in stockResult)
                {
                    connection.Open();

                    SqlCommand insertStatement = new SqlCommand("INSERT into [Stocks] (TimeStamp, Symbol, Change, Time, ChgPct, Price, Closing,Method) VALUES (@TimeStamp, @Symbol, @Change, @Time, @ChgPct, @Price, @Closing, @Method)", connection);
                    insertStatement.Parameters.AddWithValue("@TimeStamp", DateTime.Now.ToString());
                    insertStatement.Parameters.AddWithValue("@Symbol", stock["symbol"].ToString());
                    insertStatement.Parameters.AddWithValue("@Change", stock["regularMarketChange"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@Time", stock["regularMarketTime"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@ChgPct", stock["regularMarketChangePercent"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@Price", stock["regularMarketPrice"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@Closing", stock["regularMarketPreviousClose"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@Method", type);



                    insertStatement.ExecuteNonQuery();
                    connection.Close();
                }
            }       
        }
    }
}