using System;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
                
            {
                // Look for any Authors.
                if (context.Authors.Any() && context.Books.Any() &&
                    context.Comments.Any() && context.Languages.Any() && context.Publishers.Any())
                {
                    return;   // DB has been seeded
                }

                context.Authors.AddRange(
                    new Author()
                    {
                        AuthorId = 1,
                        FirstName = "Fathin",
                        LastName = "Dosunmu",
                        YearOfBirth = DateTime.Parse("2-10-2000")
                    }
                );
                
                context.Books.AddRange(
                    new Book()
                    {
                        Title = "My Book",
                        Summary = "Book explaining some details personality",
                        PublishingYear = 2007,
                        AuthoredYear = 2006,
                        WordCount = 5000,
                    }
                );
                
                context.Comments.AddRange(
                    new Comment()
                    {
                        CommentText = "Nice"
                    }
                );
                
                context.Languages.AddRange(
                    new Language()
                    {
                        LanguageName = "English"
                    }
                );
                
                context.Publishers.AddRange(
                    new Publisher()
                    {
                        PublisherName = "O'reily"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}