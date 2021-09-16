﻿using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=dev;Password=@DevTeste123";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            // ReadUsers(connection);
            // ReadRoles(connection);
            // ReadTags(connection);
            // ReadCategories(connection);
            ReadUsersWithRoles(connection);
            connection.Close();
        }
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void ReadCategories(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var items = repository.Get();
            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                System.Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    System.Console.WriteLine($" - {role.Name}");
                }
            }
        }

    }
}
