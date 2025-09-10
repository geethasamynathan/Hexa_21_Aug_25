﻿using Microsoft.EntityFrameworkCore;

namespace DTO_Demo1.Models
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
