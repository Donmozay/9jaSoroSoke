using _9jasorosoke.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace _9jasorosoke.Repositories.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
