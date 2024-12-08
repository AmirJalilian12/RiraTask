using Microsoft.Extensions.DependencyInjection;
using Rira.Application.Interfaces;
using Rira.Application.Services;
using Rira.Domain.Entities;
using Rira.Domain.Interfaces;
using Rira.Infrastructure.DB;
using Rira.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace riraTask
{
    public class Program
    {
        private readonly IProductService _productService;

        public Program(IProductService productService)
        {
            _productService = productService;
        }

        public void RunMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Product Management System ====");
                Console.WriteLine("1. Get all products by category");
                Console.WriteLine("2. Get the most expensive product");
                Console.WriteLine("3. Calculate total price of all products");
                Console.WriteLine("4. Group products by category");
                Console.WriteLine("5. Calculate average price of products");
                Console.WriteLine("6. Exit");
                Console.WriteLine("===================================");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GetProductsByCategory();
                        break;
                    case "2":
                        GetMostExpensiveProduct();
                        break;
                    case "3":
                        GetTotalPrice();
                        break;
                    case "4":
                        GroupProductsByCategory();
                        break;
                    case "5":
                        GetAveragePrice();
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        private void GetProductsByCategory()
        {
            Console.WriteLine("\nEnter category (Category1, Category2, Category3): ");
            if (Enum.TryParse(Console.ReadLine(), out Categories category))
            {
                var products = _productService.GetProductsByCategory(category);
                Console.WriteLine($"\nProducts in {category}:");
                foreach (var product in products)
                {
                    Console.WriteLine($"- {product.Name} (Price: {product.Price})");
                }
            }
            else
            {
                Console.WriteLine("Invalid category.");
            }
        }

        private void GetMostExpensiveProduct()
        {
            var product = _productService.GetMostExpensiveProduct();
            if (product != null)
            {
                Console.WriteLine($"\nMost Expensive Product: {product.Name}, Price: {product.Price}");
            }
            else
            {
                Console.WriteLine("\nNo products available.");
            }
        }

        private void GetTotalPrice()
        {
            var totalPrice = _productService.GetTotalPrice();
            Console.WriteLine($"\nTotal Price of all products: {totalPrice}");
        }

        private void GroupProductsByCategory()
        {
            var groupedProducts = _productService.GetProductsGroupedByCategory();
            Console.WriteLine("\nProducts grouped by category:");
            foreach (var group in groupedProducts)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var product in group)
                {
                    Console.WriteLine($"- {product.Name} (Price: {product.Price})");
                }
            }
        }

        private void GetAveragePrice()
        {
            var averagePrice = _productService.GetAveragePrice();
            Console.WriteLine($"\nAverage Price of all products: {averagePrice}");
        }
        //this part made by chatGPT
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var program = serviceProvider.GetRequiredService<Program>();
            program.RunMenu();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<Context>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<Program>(); 

            return services.BuildServiceProvider();
        }
    }
}
