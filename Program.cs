using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace test4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            system("chcp 1251");
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    User user1 = new User { Name = "Tom", Age = 33 };
            //    User user2 = new User { Name = "Alice", Age = 26 };

            //    db.Users.AddRange(user1, user2);
            //    db.SaveChanges();
            //}
            //// ��������� ������
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    var users = db.Users.ToList();
            //    Console.WriteLine("������ ��������:");
            //    foreach (User u in users)
            //    {
            //        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            //    }
            //}

        }
    }
    //public class User
    //{
    //    public int Id { get; set; }
    //    public string? Name { get; set; }
    //    public int Age { get; set; }
    //}
    public enum Category
    {
        Mobiles,
        TV,
        Laptops
    }
    public enum Address
    {
        Adres1,
        Adres2,
        Adres3
    }
    /// <summary>
    /// �����
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Category Category { get; set; }
        public int LocationWarehouseNumber { get; set; }// ����� ������

    }
    /// <summary>
    /// ������������
    /// </summary>
    public class Location {
        [Key]
        public int WarehouseNumber { get; set; }//����� ������
        public Address Address { get; set; }
        public int RackNumber { get; set; }//�������
        public int ShelfNumber { get; set; }//�����

        public List<Product> Products { get; set; } = new();//������ ������
    }
    public interface Person
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int Age  { get; set; }
    }
    public class User : Person
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        //POSITION..
    }
    //POSITION

    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext()
        {
            //Database.EnsureCreated();
            //Database.EnsureDeleted();   // ������� �� �� ������ ������
            //Database.EnsureCreated();   // ������� �� � ����� ������
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=dimka_erm;database=test;",
                new MySqlServerVersion(new Version(8, 0, 25)));
        }
        //��������
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasCheckConstraint("Age", "Age > 0 AND Age < 120"); //�������� ����� ���������
            modelBuilder.Entity<User>().HasIndex(u => u.Age).IsUnique();//������������
        }
       
    }
}