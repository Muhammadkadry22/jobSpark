using jobSpark.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantVacancy>()
             .HasKey(av => new { av.ApplicantId, av.VacancyId });

            modelBuilder.Entity<ApplicantVacancy>()
                .HasOne<Applicant>(av => av.Applicant)
                .WithMany(a => a.ApplicantVacancies)
                .HasForeignKey(av => av.ApplicantId);

            modelBuilder.Entity<ApplicantVacancy>()
                .HasOne<Vacancy>(av => av.Vacancy)
                .WithMany(v => v.ApplicantVacancies)
                .HasForeignKey(av => av.VacancyId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Achievement> Achievements { get; set;}
        public DbSet<Certification> Certifications { get; set;}
        public DbSet<WorkingHistory> WorkingHistories { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ApplicantVacancy> ApplicantsVacancies { get; set; }

                                 

    }
}
