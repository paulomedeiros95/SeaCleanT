using Microsoft.EntityFrameworkCore;
using SeaCleanSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaCleanSolutions.Areas.Application.Data
{
    public class ApplicationDBContext : DbContext
    {

        #region Public Properties DbSet
        public DbSet<Course> Courses { get; set; }
        public DbSet<ImageDoc> ImageDocs { get; set; }
        public DbSet<QuestionnarieM> Questionnaries { get; set; }
        public DbSet<QuestionnarieGroupID> QuestionnarieGroupIDs { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Dev_SeaCleanSolutions;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageDoc>()
                .HasKey(o => new { o.PhotoName, o.PhotoGroup });
            modelBuilder.Entity<QuestionnarieM>()
               .HasKey(o => new { o.QuestionnarieID, o.QuestionNumber });
        }



    }

}
