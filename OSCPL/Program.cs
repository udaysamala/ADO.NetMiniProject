using OSCBL;
using OSCDAL;
using OSCDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCPL
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Boolean n = true;
                DAL dal = new DAL();

                BL bl = new BL();
                while (n)
                {
                    Console.WriteLine(" 1. Customer Login\n 2. Admin Login\n 3.Exit");
                    Console.Write("Enter Your Choice : ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    switch (a)
                    {
                        case 1:
                            Console.WriteLine("Enter the username :");
                            string username = Console.ReadLine();
                            Console.WriteLine("Enter the password :");
                            string password = Console.ReadLine();
                            Console.WriteLine(" 1. Login\n 2. SiginUp");
                            int status = Convert.ToInt32(Console.ReadLine());
                            Customer dto = new Customer();
                            dto.Email = username;
                            dto.Password = password;
                            
                            

                            
                            if (status == 1) {
                                int result1 = bl.CheckLogin(dto);
                                if (result1 == 1)
                                {
                                    Console.WriteLine("Login Successfull");
                                }
                                else
                                {
                                    Console.WriteLine("No data found! please signup");
                                    
                                }
                            }
                            if (status == 2)
                            {
                                Console.WriteLine("We are working on it! Check after some time");
                                
                            }
                           
                            break;
                        case 2:
                            Console.WriteLine("Enter the username :");
                            string user = Console.ReadLine();
                            Console.WriteLine("Enter the password :");
                            string pass = Console.ReadLine();


                            Admin dto1 = new Admin();
                            dto1.User = user;
                            dto1.Pass = pass;
                            int result = bl.checkadminlogin(dto1);
                             if (result == 1)
                                {
                                    Console.WriteLine("Login Successfull");
                                }
                             else
                                {
                                Console.WriteLine("Invalid Login credentials!");


                            }

                            
                            break;
                        default:
                            n = false;
                            break;

                    }

                }

            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
