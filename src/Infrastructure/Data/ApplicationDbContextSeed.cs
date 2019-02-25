using AskGoo2.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AskGoo2.ApplicationCore.Entities.QuestionAggregate;

namespace AskGoo2.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            var questionsList = new List<Question>
            {
                new Question
                {
                    Title = "Sample Title 1", Description = "Sample Description 1"
                }
                , new Question
                {
                    Title = "Sample Title 2", Description = "Sample Description 2"
                }
                , new Question
                {
                    Title = "Sample Title 3", Description = "Sample Description 3"
                }

            };

            await context.Questions.AddRangeAsync(questionsList);
            await context.SaveChangesAsync();
        }
    }
}
