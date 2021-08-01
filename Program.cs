using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkListAndDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 10;
            Client client1 = new Client() { Name = "Вася", Surname = "Сидоров", Patronymic = "Ефимович", CountMoney = 1000, PassportID = 1 };
            Client client2 = new Client() { Name = "Петя", Surname = "Пупкин", Patronymic = "Степанович", CountMoney = 23, PassportID = 12 };
            Client client3 = new Client() { Name = "Федя", Surname = "Иванов", Patronymic = "Олегович", CountMoney = 65, PassportID = 49 };
            Client client4 = new Client() { Name = "Саша", Surname = "Смирнов", Patronymic = "Евгеньевич", CountMoney = 22235, PassportID = 4 };
            Client client5 = new Client() { Name = "Саша", Surname = "Бронштейн", Patronymic = "Иордаович", CountMoney = 32, PassportID = 5 };
            List<Client> clientsDataBase = new List<Client>() { client1, client2, client3, client4, client5 };

            while (userInput != 0)
            {
                Console.Clear();
                Console.WriteLine("Меню нашего банка:");
                Console.WriteLine("Нажмите 1, чтобы увдеть базу данных всех клиентов.");
                Console.WriteLine("Нажмите 2, чтобы найти клиента по номеру паспорта.");
                Console.WriteLine("Нажмите 3, чтобы найти клиента по имени (возможно несколько вариантов).");
                Console.WriteLine("Нажмите 4, чтобы увидеть всех клиентов с количеством денег меньше суммы, которую вы введёте.");
                Console.WriteLine("Нажмите 5, чтобы найти клиента с минимальным количеством денег на счёте.");
                Console.WriteLine("Нажмите 6, чтобы увидеть сумму денег всех клиентов банка.");
                Console.WriteLine("Нажмите 0, чтобы выйти из меню.");
                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        DisplayClientsData(clientsDataBase);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите номер паспорта пользователя, которого хотите найти.:");
                        int searchingPassportID = Convert.ToInt32(Console.ReadLine());
                        GetClient(searchingPassportID, clientsDataBase);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Введите имя пользователя:");
                        string searchingName = Console.ReadLine();
                        GetClient(searchingName, clientsDataBase);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Введите сумму денег:");
                        int range = Convert.ToInt32(Console.ReadLine());
                        GetClientsLowMoney(range, clientsDataBase);
                        break;
                    case 5:
                        GetClientMinimumMoney(clientsDataBase);
                        break;
                    case 6:
                        GetSumAllMoney(clientsDataBase);
                        break;
                }
            }
        }

        static void GetClientsLowMoney(int range, List<Client> clientsDataBase)
        {
            var ClientsLowMoney = from currentClient in clientsDataBase
                                  where currentClient.CountMoney
                                        < range
                                  select currentClient;

            DisplayClientsData(ClientsLowMoney.ToList());
        }

        static void GetClient(int passportID, List<Client> clientsDataBase)
        {
            var currentClients = from Client client in clientsDataBase
                                 where client.PassportID == passportID
                                 select client;
            DisplayClientsData(currentClients.ToList());
        }

        static void GetClient(string name, List<Client> clientDataBase)
        {
            var currentClients = from Client client in clientDataBase
                                 where client.Name.ToLower() == name.ToLower()
                                 select client;
            DisplayClientsData(currentClients.ToList());
        }

        static void GetClientMinimumMoney(List<Client> clientDataBase)
        {
            int minMoney = clientDataBase.Min(client => client.CountMoney);
            var clientMinMoney = from Client client in clientDataBase
                                 where client.CountMoney == minMoney
                                 select client;

            DisplayClientsData(clientMinMoney.ToList());
        }

        static void GetSumAllMoney(List<Client> clientDataBase)
        {
            int sumMoney = clientDataBase.Sum(client => client.CountMoney);
            Console.WriteLine(sumMoney);
            Console.ReadKey();
        }

        static void DisplayClientsData(object obj)
        {
            if (obj == null)
            {
            }

            if (!(obj is List<Client>))
            {
            }
            else
            {
                List<Client> clients = (List<Client>)obj;

                foreach (Client client in clients)
                {
                    DisplayClient(client);
                }
                Console.ReadKey();
            }
        }

        static void DisplayClient(Client client)
        {
            Console.WriteLine("Имя:" + client.Name);
            Console.WriteLine("Фамилия:" + client.Surname);
            Console.WriteLine("Отчество:" + client.Patronymic);
            Console.WriteLine("Количество денег на счету:" + client.CountMoney);
            Console.WriteLine("Номер паспорта:" + client.PassportID);
        }
    }
}
