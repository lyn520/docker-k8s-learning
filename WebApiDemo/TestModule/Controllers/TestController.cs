using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TestModule.Models;

namespace TestModule.Controllers
{
    [Area("test")]
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class TestController : ControllerBase
    {
        private readonly TestDbContext context;

        public TestController(TestDbContext testDbContext)
        {
            context = testDbContext;
        }

        [HttpGet]
        [ActionName(nameof(TestConCurrencyUpdate))]
        public void TestConCurrencyUpdate()
        {
            // Fetch a person from database and change phone number
            var person = context.Persons.Single(p => p.PersonId == 1);
            person.LastName = "qyc";

            // Change the person's name in the database to simulate a concurrency conflict
            context.Database.ExecuteSqlRaw(
                "UPDATE dbo.Person SET FirstName = 'Jane' WHERE PersonId = 1");

            var saved = false;
            while (!saved)
            {
                try
                {
                    // Attempt to save changes to the database
                    context.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is PersonModel)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];

                                // TODO: decide which value should be written to database
                                // proposedValues[property] = <value to be saved>;
                            }

                            // Refresh original values to bypass next concurrency check
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            throw new NotSupportedException(
                                "Don't know how to handle concurrency conflicts for "
                                + entry.Metadata.Name);
                        }
                    }
                }
            }
        }
    }
}
