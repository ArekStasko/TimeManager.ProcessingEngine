﻿using Microsoft.EntityFrameworkCore;

namespace TimeManager.ProcessingEngine.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}
