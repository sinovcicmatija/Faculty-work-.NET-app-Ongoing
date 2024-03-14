using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    public partial class DatabaseRPP : DbContext
    {
        public DatabaseRPP()
            : base("name=DatabaseRPP")
        {
        }

        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Order_Item> Order_Item { get; set; }
        public virtual DbSet<Order_Status> Order_Status { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Room_Status> Room_Status { get; set; }
        public virtual DbSet<Room_Type> Room_Type { get; set; }
        public virtual DbSet<RoomOrder> RoomOrders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User_Role> User_Role { get; set; }
        public virtual DbSet<OrderItem_RoomOrder> OrderItem_RoomOrder { get; set; }
        public virtual DbSet<Qustennioare> Qustennioares { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.LicensePlate)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.TelNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Guest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order_Item>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Item>()
                .Property(e => e.FoodDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Item>()
                .HasMany(e => e.OrderItem_RoomOrder)
                .WithRequired(e => e.Order_Item)
                .HasForeignKey(e => e.OrderItemIdItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order_Status>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Status>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Status>()
                .HasMany(e => e.RoomOrders)
                .WithRequired(e => e.Order_Status)
                .HasForeignKey(e => e.OrderStatusIdOrderStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservation>()
                .HasOptional(e => e.Qustennioare)
                .WithRequired(e => e.Reservation);

            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.RoomOrders)
                .WithRequired(e => e.Reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room_Status>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Room_Status>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Room_Status)
                .HasForeignKey(e => e.RoomStatusIdRoomStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room_Type>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Room_Type>()
                .Property(e => e.DescriptionOfType)
                .IsUnicode(false);

            modelBuilder.Entity<Room_Type>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Room_Type)
                .HasForeignKey(e => e.RoomTypeIdRoomType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoomOrder>()
                .Property(e => e.Date)
                .IsFixedLength();

            modelBuilder.Entity<RoomOrder>()
                .HasMany(e => e.OrderItem_RoomOrder)
                .WithRequired(e => e.RoomOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserCard)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<User_Role>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<User_Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.User_Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Qustennioare>()
                .Property(e => e.Comment)
                .IsUnicode(false);
        }
    }
}
