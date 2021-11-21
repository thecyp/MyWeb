using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyWeb.Controllers
{
    public class ClientNumberController : Controller
    {
        public IActionResult ClientNumberQryForm()
        {
            return this.View();
        }

        public IActionResult byCountry([FromFormAttribute(Name = "id")] string country)
        {
            string message = null;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = MyWeb.Properties.Resources.nor;
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    message = "資料庫連接成功";
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = System.Data.CommandType.Text;
                    comm.CommandText = "Select Count(*) as ClientNumber From Customers where Country=@Country";
                    SqlParameter p1 = new SqlParameter("Country", country);
                    SqlParameterCollection col = comm.Parameters;
                    col.Add(p1);
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        message = $"{country}的訂單共{reader["ClientNumber"]}筆";
                    }
                    else
                    {
                        message = "查無資料";
                    }

                    conn.Close();

                }
            }
            catch (SqlException ex)
            {
                message = "連接失敗..." + ex.Message;
            }
            return Content(message);
        }
    }
}
