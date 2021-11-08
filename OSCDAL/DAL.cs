using OSCDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCDAL
{
    public class DAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        //SqlDataReader sqlDataReaderObj;
        public DAL()
        {
            sqlConObj = new SqlConnection();
            sqlCmdObj = new SqlCommand();

        }
        
        public int Login(Customer c)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.
                    ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                bool check = false;
                //string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GroceryStoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                //SqlConnection con = new SqlConnection(connString);
                sqlConObj.Open();
                string query = "Select * from dbo.users";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                SqlDataReader col = cmd.ExecuteReader();
                while (col.Read())
                {
                    if (c.Email == System.Convert.ToString(col[3]) && c.Password == System.Convert.ToString(col[4]))
                    {
                        check = true;
                        break;
                    }
                }
                sqlConObj.Close();
                if (check == true)
                    
                return 1;
                else
                    return -1;
            }
            catch(Exception e) { throw e; }
        }
        public int AdminLogin(Admin a)
        {
            if (a.User == "admin" && a.Pass == "admin")
            {
                return 1;
            }
            else
                return -1;
        }
        public bool signup(Customer c)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.
                    ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                bool check = false;
         
                sqlConObj.Open();

                string query = $"insert into dbo.users(email, Password) values('{c.Email}','{c.Password}')";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                int insertedRows = cmd.ExecuteNonQuery();
                if (insertedRows >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
    }
}
