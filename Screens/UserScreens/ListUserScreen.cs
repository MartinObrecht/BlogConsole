using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class ListUserScreen
    {
        public static void Load()
        {
            Console.WriteLine("Lista de usuários");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<User>(DataBase.Connection);
            var users = repository.Get();

            foreach (var user in users)
                Console.WriteLine($"{user.Id} - {user.Name} - {user.Email}");
            
        }
    }
}