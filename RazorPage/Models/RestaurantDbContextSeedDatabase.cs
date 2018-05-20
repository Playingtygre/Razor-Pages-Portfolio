using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPage.Data;

namespace RazorPage.Models
{
    public static class RestaurantDbContextSeedDatabase
    {
        static object synchblock = new object();
        static volatile bool seeded = false;
        public static void EnsureSeedData(this RestaurantDbContext context)
        {
            if (!seeded && context.Restaurant.Count() == 0)
            {
                lock (synchblock)
                {
                    if (!seeded)
                    {
                        var restaurants = GenerateRestaurants();
                        context.Restaurant.AddRange(restaurants);
                        context.SaveChanges();
                        seeded = true;
                    }
                }

            }
        }

        public static Restaurant[] GenerateRestaurants()
        {
            return new Restaurant[] {
                new Restaurant {
                    Name = "Castle",
                    Description = "British pub located in Downtown Seattle",
                    MenuItems = string.Join(Environment.NewLine, new List<string> {
                        "All Sandwiches can be made Gluten Free",
                        "Gluten Free Beer",
                        "Shepards Pie",
                        "Nachos",

                    }),
                    ImageUrl ="/Images/OkayCat.jpg",

                    StarRating = 4,
                },
                new Restaurant {
                    Name = "Ghostfish",
                    Description = "100% Gluten Free Beers on tap!",
                    MenuItems = string.Join(Environment.NewLine, new List<string> {
                        "13 Different Beers on Tap",
                        "Mini Pizzas",
                        "Brunch Menu",
                        "Nachos",

                    }),
                    ImageUrl ="/Images/OkayCat.jpg",
                    StarRating = 4,
                },
                new Restaurant {
                    Name = "Cafe",
                    Description = "Eat like you give a Damn!",
                    MenuItems = string.Join(Environment.NewLine, new List<string> {
                        "Gluten Free French Toast",
                        "Omlettes",
                        "Gluten-Free Pancakes",
                        "Full pitcher of Mimosas",

                    }),
                    ImageUrl ="/Images/OkayCat.jpg",

                    StarRating = 5,
                },
                new Restaurant {
                    Name = "I Love",
                    Description = "Food Cart that shows up randomly around Seattle",
                    MenuItems = string.Join(Environment.NewLine, new List<string> {
                        "GF Coconut Cookies",
                        "Fiest Chicken and Quiona bowls",
                    }),
                    ImageUrl = "/Images/OkayCat.jpg",
                    StarRating = 5,
                },
                new Restaurant {
                    Name = "Biscuit Bitch",
                    Description = "Southern Inspired Fixins",
                    MenuItems = string.Join(Environment.NewLine, new List<string> {
                        "Biscuits",
                        "Gravy",
                        "Coffee",
                    }),
                    StarRating = 3,
                    ImageUrl = "/Images/OkayCat.jpg",
                },
            };
        }
    }

}
