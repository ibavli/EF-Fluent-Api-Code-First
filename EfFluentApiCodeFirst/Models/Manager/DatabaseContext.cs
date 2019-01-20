using EfFluentApiCodeFirst.Models.ManyToMany;
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

        //Many-to-many
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<AuthorsBooksMapping> AuthorsBooksMapping { get; set; }

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


            //Many-to-many
            //Primary keys many-to-many
            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<AuthorsBooksMapping>().HasKey(abm =>
                new {
                    abm.AuthorId,
                    abm.BookId
                });
            //Relationships many-to-many
            modelBuilder.Entity<AuthorsBooksMapping>()
                .HasRequired(t => t.Book)
                .WithMany(t => t.AuthorsBooksMapping)
                .HasForeignKey(t => t.BookId);
            //Relationships many-to-many
            modelBuilder.Entity<AuthorsBooksMapping>()
                 .HasRequired(t => t.Author)
                 .WithMany(t => t.AuthorsBooksMapping)
                 .HasForeignKey(t => t.AuthorId);

           
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


                Book book1 = new Book()
                {
                    Name = "XYZ programlama",
                    NumberOfPages = 401
                };
                
                Book book2 = new Book()
                {
                    Name = "ABC programlama",
                    NumberOfPages = 337
                };

                
                Author author1 = new Author()
                {
                    Name = "hasan",
                    Surname = "hüseyin"
                };
                Author author2 = new Author()
                {
                    Name = "ayşe",
                    Surname = "fatma"
                };
                Author author3 = new Author()
                {
                    Name = "ali",
                    Surname = "veli"
                };
                context.Book.Add(book1);
                context.Book.Add(book2);
                context.Author.Add(author1);
                context.Author.Add(author2);
                context.Author.Add(author3);
                context.SaveChanges();


                var xyzBook = context.Book.Where(b => b.Name == "XYZ programlama").FirstOrDefault();
                var hasan = context.Author.Where(a => a.Name == "hasan").FirstOrDefault();
                var ayse = context.Author.Where(a => a.Name == "ayşe").FirstOrDefault();
                AuthorsBooksMapping authorsBooksMapping1 = new AuthorsBooksMapping()
                {
                    Book = xyzBook,
                    Author = hasan
                };
                AuthorsBooksMapping authorsBooksMapping2 = new AuthorsBooksMapping()
                {
                    Book = xyzBook,
                    Author = ayse
                };
                context.AuthorsBooksMapping.Add(authorsBooksMapping1);
                context.AuthorsBooksMapping.Add(authorsBooksMapping2);
                context.SaveChanges();

                var abcBook = context.Book.Where(b => b.Name == "ABC programlama").FirstOrDefault();
                var hasan_ = context.Author.Where(a => a.Name == "hasan").FirstOrDefault();
                var ayse_ = context.Author.Where(a => a.Name == "ayşe").FirstOrDefault();
                AuthorsBooksMapping authorsBooksMapping3 = new AuthorsBooksMapping()
                {
                    Book = abcBook,
                    Author = hasan
                };
                AuthorsBooksMapping authorsBooksMapping4 = new AuthorsBooksMapping()
                {
                    Book = abcBook,
                    Author = ayse
                };
                context.AuthorsBooksMapping.Add(authorsBooksMapping3);
                context.AuthorsBooksMapping.Add(authorsBooksMapping4);
                context.SaveChanges();

            }
        }
    }
}