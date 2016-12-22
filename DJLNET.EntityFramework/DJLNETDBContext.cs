﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.EntityFramework
{
    public class DJLNETDBContext : DbContext, IDbContext
    {
        private static readonly string _conn = "Default";

        static DJLNETDBContext()
        {
            Database.SetInitializer<DJLNETDBContext>(new CreateDatabaseIfNotExists<DJLNETDBContext>());
        }

        public DJLNETDBContext() : base($"name={_conn}")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}