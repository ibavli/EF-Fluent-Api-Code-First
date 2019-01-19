using EfFluentApiCodeFirst.Models.OneToOneOrZero;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EfFluentApiCodeFirst.Models.Manager
{
    public class DatabaseContext : DbContext
    {
        //One-to-one or zero
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentAddress> StudentAddress { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //One-to-one or zero
            modelBuilder.Entity<Student>()
                .HasOptional(s => s.StudentAddress) //Student için isteğe bağlı StudentAddress özelliği
                .WithRequired(sa => sa.Student); //Student oluşturmadan StudentAddress oluşturulamaz olarak atadık.

         
            Database.SetInitializer(new VeritabaniOlusurkenTablolaraBaslangicKayitlariEkleme());
        }

        public class VeritabaniOlusurkenTablolaraBaslangicKayitlariEkleme : CreateDatabaseIfNotExists<DatabaseContext>
        {
            protected override void Seed(DatabaseContext context)
            {
                Student student = new Student()
                {
                    StudentName = "ali",
                    StudentSurname = "veli"
                };
                context.Student.Add(student);
                context.SaveChanges();

                StudentAddress studentAddress = new StudentAddress()
                {
                    Address1 = "xx mahallesi yy sokak no 33",
                    City = "izmir",
                    Country = "Türkiye"
                };
                Student student2 = new Student()
                {
                    StudentName = "Hasan",
                    StudentSurname = "Hüseyin",
                    StudentAddress = studentAddress
                };
                context.Student.Add(student2);
                context.SaveChanges();


              

            }
        }
    }
}