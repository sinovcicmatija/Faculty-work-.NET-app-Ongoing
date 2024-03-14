namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RoomOrder")]
    public partial class RoomOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoomOrder()
        {
            OrderItem_RoomOrder = new HashSet<OrderItem_RoomOrder>();
        }

        [Key]
        public int IdOrder { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Date { get; set; }

        public int ReservationIdReservation { get; set; }

        public int OrderStatusIdOrderStatus { get; set; }

        public double? TotalPrice { get; set; }

        public virtual Order_Status Order_Status { get; set; }

        public virtual Reservation Reservation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem_RoomOrder> OrderItem_RoomOrder { get; set; }
    }
}
