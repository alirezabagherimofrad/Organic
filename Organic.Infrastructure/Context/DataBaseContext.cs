using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(){}

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

    }
}
