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
                            string password = Orb.App.Console.ReadPassword();
                            Console.WriteLine(" 1. Login\n 2. SiginUp");
                            int status = Convert.ToInt32(Console.ReadLine());
                            Customer dto = new Customer();
                            dto.Email = username;
                            dto.Password = password;

                            if (status == 1)
                            {
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
                            string pass = Orb.App.Console.ReadPassword();


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
            catch (Exception e)
            {
                throw e;
            }
        }

    }


    namespace Orb.App
    {
        /// <summary>
        /// Adds some nice help to the console. Static extension methods don't exist (probably for a good reason) so the next best thing is congruent naming.
        /// </summary>
        static public class Console
        {
            /// <summary>
            /// Like System.Console.ReadLine(), only with a mask.
            /// </summary>
            /// <param name="mask">a <c>char</c> representing your choice of console mask</param>
            /// <returns>the string the user typed in </returns>
            public static string ReadPassword(char mask)
            {
                const int ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;
                int[] FILTERED = { 0, 27, 9, 10 /*, 32 space, if you care */ }; // const

                var pass = new Stack<char>();
                char chr = (char)0;

                while ((chr = System.Console.ReadKey(true).KeyChar) != ENTER)
                {
                    if (chr == BACKSP)
                    {
                        if (pass.Count > 0)
                        {
                            System.Console.Write("\b \b");
                            pass.Pop();
                        }
                    }
                    else if (chr == CTRLBACKSP)
                    {
                        while (pass.Count > 0)
                        {
                            System.Console.Write("\b \b");
                            pass.Pop();
                        }
                    }
                    else if (FILTERED.Count(x => chr == x) > 0) { }
                    else
                    {
                        pass.Push((char)chr);
                        System.Console.Write(mask);
                    }
                }

                System.Console.WriteLine();

                return new string(pass.Reverse().ToArray());
            }

            /// <summary>
            /// Like System.Console.ReadLine(), only with a mask.
            /// </summary>
            /// <returns>the string the user typed in </returns>
            public static string ReadPassword()
            {
                return Orb.App.Console.ReadPassword('*');
            }
        }
    }
}

