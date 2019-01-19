using EfFluentApiCodeFirst.Models.OneToMany;
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

        //One-to-many
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Lessons> Lessons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //One-to-one or zero
            modelBuilder.Entity<Student>()
                .HasOptional(s => s.StudentAddress) //Student için isteğe bağlı StudentAddress özelliği
                .WithRequired(sa => sa.Student); //Student oluşturmadan StudentAddress oluşturulamaz olarak atadık.

            //One-to-many
            modelBuilder.Entity<Lessons>()
                .HasRequired(l => l.Teacher)
                .WithMany(t => t.Lessons)
                .HasForeignKey<int>(t => t.TeacherId);

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



                List<Lessons> listLessons = new List<Lessons>()
                {
                    new Lessons()
                    {
                        LessonName = "matematik"
                    },
                    new Lessons()
                    {
                        LessonName = "fizik"
                    },
                };
                Teacher teacher = new Teacher()
                {
                    Name = "aysel",
                    Surname = "maysel",
                    Lessons = listLessons
                };

                context.Teacher.Add(teacher);
                context.SaveChanges();


            }
        }
    }
}