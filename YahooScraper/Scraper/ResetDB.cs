using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace YahooScraper.Scraper
{
    public class ResetDB
    {

        public static void Reset()
        {
            //string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
           
            //string sql = @"DELETE FROM StockTable;
            //               DBCC CHECKIDENT(StockTable, RESEED, 0);";
            //SqlConnection sqlConn = new SqlConnection(sql, connStr);
                
                   
            //        sqlConn.Open();
            //        reset = command.ExecuteNonQuery();
                

                   
            
        }
       

        
        //public void Reset()
        //{
        //    using (ConnDB())
        //    {
        //        string sql = @"DELETE FROM StockTable;
        //            DBCC CHECKIDENT(StockTable, RESEED, 0);";

        //        using (SqlCommand command = new SqlCommand(sql, ConnDB())
        //        {
        //                ConnDB().Open();
        //        reset = command.ExecuteNonQuery();
        //         }
        //    }
        //}
    }
}

            //SqlCommand resetTable = new SqlCommand(sql, ConnDB());
