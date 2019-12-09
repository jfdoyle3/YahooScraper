using Newtonsoft.Json.Linq;
using System;
using System.Data.SqlClient;

namespace YahooScraper
{
    public class SQLWrite
    {
        public static void WriteDB(JArray rsStocks)
        {
            string type = "RS";
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestSharp;Integrated Security=True";
            // string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinancialDB;Integrated Security=True";

            Console.Write("Open\n");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                foreach (JToken stock in rsStocks)
                {
                    connection.Open();

                    SqlCommand insertStatement = new SqlCommand("INSERT into [RestSharpStocks] (DateStamp, Symbol, Change, MarketTime, ChgPct, Price, Closing, Method) VALUES (@DateStamp, @Symbol, @Change, @MarketTime, @ChgPct, @Price, @Closing, @Method)", connection);
                    // SqlCommand insertStatement = new SqlCommand("INSERT into [ScrapedStocks] (DateStamp, Symbol, Change, MarketTime, ChgPct, Price, Closing, Method) VALUES (@DateStamp, @Symbol, @Change, @MarketTime, @ChgPct, @Price, @Closing, @Method)", connection);

                    insertStatement.Parameters.AddWithValue("@DateStamp", DateTime.Now.ToString());
                    insertStatement.Parameters.AddWithValue("@Symbol", stock["symbol"].ToString());
                    insertStatement.Parameters.AddWithValue("@Change", stock["regularMarketChange"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@MarketTime", stock["regularMarketTime"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@ChgPct", stock["regularMarketChangePercent"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@Price", stock["regularMarketPrice"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@Closing", stock["regularMarketPreviousClose"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@Method", type);

                    insertStatement.ExecuteNonQuery();
                    connection.Close();
                }

                Console.WriteLine("Database: Written and Closed");
            }
        }
    }
}