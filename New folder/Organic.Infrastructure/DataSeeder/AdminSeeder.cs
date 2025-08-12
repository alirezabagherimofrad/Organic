using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Organic.Domain.Model.User;
using Organic.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.DataSeeder
{
    public class AdminSeeder
    {
        public static async Task SeedUserAsync(DataBaseContext context)
        {
            var AdminExists = await context.User.AnyAsync(u => u.PhoneNumber == "09397438089");

            if (!AdminExists)
            {
                var admin = new UserModel(first_Name: "Alireza", last_Name: "Bagheri", phoneNumber: "09397438089", email: "alirezabagherimofrad@gmail.com", password: "Alireza138327445", SelectGender.Man);

                await context.AddAsync(admin);

                await context.SaveChangesAsync();
            }
        }
    }
}
