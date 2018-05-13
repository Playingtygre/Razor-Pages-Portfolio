using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Models;

namespace Portfolio.Data
{
    public static class ProjectDbContextSeedDatabase
    {
        private static object synchlock = new object();
        private static volatile bool seeded = false;

        public static void EnsureSeedData(this ProjectDbContext context)
        {
            lock (synchlock)
            {
                if (!seeded && !context.Projects.Any())
                {
                    Project[] projects = GenerateProjects();
                    context.Projects.AddRange(projects);
                    context.SaveChanges();
                    seeded = true;
                }
            }
        }

        public static Project[] GenerateProjects()
        {
            return new[]
            {
                new Project
                {
                    Name = "PROJECT AMANDA",
                    DateCompleted = new DateTime(2018, 5, 26),
                    Description = "Azure Cognitive Services",
                    Type = "Web Application",
                    ImageUrl = "/Images/HappyCat.jpg"
                }

            };
        }
    }
}
