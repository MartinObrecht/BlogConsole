using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public class UpdateScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando tag");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Update(new Tag
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug

            });

            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(DataBase.Connection);
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}