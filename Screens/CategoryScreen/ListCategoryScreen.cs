using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreen
{
    public class ListCategoryScreen
    {
        public static void Load()
        {
            Console.WriteLine("Lista de categorias");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Category>(DataBase.Connection);
            var categories = repository.Get();
            foreach (var category in categories)
                Console.WriteLine($"{category.Id} - {category.Name} ({category.Slug})");
        }
    }
}