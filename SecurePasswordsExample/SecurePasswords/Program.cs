using System;
using System.Data;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecurePasswordLogic.Controller;
using SecurePasswordsDataAccess.Data;

namespace SecurePasswords
{
    class Program
    {
        private int count;
        static void Main(string[] args)
        {
            var services = Startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            
            serviceProvider.GetService<SerivceModule>()?.Run(args);

            RunUI();
        }

        public static void RunUI()
        {
            var userController = new UserController();
            do
            {
                Console.WriteLine("Create user ((true)/false)");
                byte count = 0;
                bool createUser;
                string username;
                string password;
                bool valid = false;
                bool inputright = bool.TryParse(Console.ReadLine(), out createUser);
                if (!inputright)
                {
                    createUser = true;
                }
                do
                {
                    Console.Clear();
                    Console.WriteLine("username: ");
                    username = Console.ReadLine();
                    Console.WriteLine("password: ");
                    password = Console.ReadLine();
                    if (createUser)
                    {
                        valid = userController.CreateUser(username, password);
                    }
                    else
                    {
                        valid = userController.UserLogin(username, password);
                        if (!valid)
                        {
                            count++;
                            Console.WriteLine("Wrong");
                            if (count > 6)
                            {
                                for (int i = 25; i > 0; i--)
                                {
                                    Console.Clear();
                                    Console.WriteLine("wait " + i + "sec");
                                    Thread.Sleep(1000);
                                }
                            }
                            else if (count > 3)
                            {
                                for (int i = 5; i > 0; i--)
                                {
                                    Console.Clear();
                                    Console.WriteLine("wait " + i + "sec");
                                    Thread.Sleep(1000);
                                }
                            }
                            else
                            {
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                } while (!valid);
                Console.WriteLine("Welcome " + username);
                Console.WriteLine("type end to exit the program");
            } while (Console.ReadLine() != "end");
        }
    }
}
