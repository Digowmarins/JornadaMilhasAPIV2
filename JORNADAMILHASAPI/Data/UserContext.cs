﻿using JORNADAMILHASAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JORNADAMILHASAPI.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opts) : base(opts)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
