using DataLayer.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microServiceApiProduct
{
    public static class InMemoryContext
    {
        private static ConcurrentDictionary<string, Genre> Genres = new();
        private static ConcurrentDictionary<string, Author> Authors = new();
        private static ConcurrentDictionary<string, Product> Products = new();

        static void AddDafaultDataGenres()
        {
            Genre[] genres =
            {
                new Genre {GenreName = "Fantasy"},
                new Genre {GenreName = "Horror"},
                new Genre {GenreName = "Drama"},
                new Genre {GenreName = "Mysticism"},
                new Genre {GenreName = "Love Story"},
            };

            for (var i = 0; i < genres.Length; ++i)
            {
                Genres.TryAdd(genres[i].GenreCode, genres[i]);
            }

        }

        static void AddDafaultDataAuthor()
        {
            Author[] authors =
            {
                new Author {Name = "NAme_1", Surname="Surname_1", Email="Email_1"},
                new Author {Name = "NAme_2", Surname="Surname_2", Email="Email_2"},
                new Author {Name = "NAme_3", Surname="Surname_3", Email="Email_3"},
                new Author {Name = "NAme_4", Surname="Surname_4", Email="Email_4"}
            };

            for (var i = 0; i < authors.Length; ++i)
            {
                Authors.TryAdd(authors[i].Email, authors[i]);
            }

        }
        static void AddDefaultDataToProducts()
        {
            Authors.TryGetValue("Email_1", out var author_1);
            Authors.TryGetValue("Email_2", out var author_2);
            Authors.TryGetValue("Email_3", out var author_3);
            Authors.TryGetValue("Email_4", out var author_4);
                        
            var genres_1 = new List<Genre>();            
            var genres_2 = new List<Genre>();
            var genres_3 = new List<Genre>();
            var genres_4 = new List<Genre>();

            Product[] products = {
                new Product { ProductName = "Thunder", Description = "Something about Thunder", ReleaseDate = DateTime.Parse("12/02/2006"),
                    Author =  Authors.Values.FirstOrDefault(x=>x.Email == "Email_1"), Genres = genres_1 },

                new Product { ProductName = "Volcano", Description = "Something about Volcano", ReleaseDate = DateTime.Parse("24/08/2013"),
                    Author = Authors.Values.FirstOrDefault(x=>x.Email == "Email_2"), Genres = genres_2 },

                new Product { ProductName = "Tsunami", Description = "Something about Tsunami", ReleaseDate = DateTime.Parse("31/01/2017"),
                    Author = Authors.Values.FirstOrDefault(x=>x.Email == "Email_3"), Genres = genres_3 },

                new Product { ProductName = "CoronaVirus", Description = "Something about CoronaVirus", ReleaseDate = DateTime.Parse("01/12/2019"),
                    Author = Authors.Values.FirstOrDefault(x=>x.Email == "Email_4"), Genres = genres_4 }
            };

            for (var i = 0; i < products.Length; ++i)
            {
                Products.TryAdd(products[i].Code, products[i]);
            }
        }
        public static IEnumerable<Product> GetProducts()
        {
            return Products.Values.AsEnumerable();
        }

        public static Product GetProductByCode(string code)
        {
            return Products.TryGetValue(code, out var product) ? product : null;
            //return Products.Values.AsEnumerable().FirstOrDefault(x=>x.GetCode()==code);
        }

        public static bool AddProduct(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product), "Invalid product");
            }

            return Products.TryAdd(product.Code, product);
        }

        public static bool DeleteProduct(Product product)
        {
            return Products.TryRemove(product.Code, out var result);
        }


    }
}
