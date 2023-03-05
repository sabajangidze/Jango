using Web.Domain.Entities;

namespace Web.Infrastructure.Data;

public class DbInitialize
{
    public static void Initialize(WebDbContext context)
    {
        context.Database.EnsureCreated();

        var customers = new Customer[]
        {
            new Customer
            {
                FirstName = "Saba",
                LastName = "Jangidze",
                Email = "jangidzesaba@gmail.com",
                Phone = "568 68 04 68",
                Street = "Gldani",
                City = "Tbilisi",

            }
        };

        foreach (var customer in customers)
        {
            context.customers.Add(customer);
        }

        context.SaveChanges();
    }
}
