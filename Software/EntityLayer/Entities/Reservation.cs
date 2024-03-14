namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Reservation")]
    public partial class Reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservation()
        {
            RoomOrders = new HashSet<RoomOrder>();
        }

        [Key]
        public int IdReservation { get; set; }

        public TimeSpan Date { get; set; }

        public DateTime DateFrom { get; set; }

        public int GuestIdGuest { get; set; }

        public DateTime DateTo { get; set; }

        public double PriceTotal { get; set; }

        public int RoomIdRoom { get; set; }

        public int UserIdUser { get; set; }

        public virtual Guest Guest { get; set; }

        public virtual Qustennioare Qustennioare { get; set; }

        public virtual Room Room { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoomOrder> RoomOrders { get; set; }
    }
}
