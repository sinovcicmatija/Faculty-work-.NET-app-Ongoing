namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Qustennioare")]
    public partial class Qustennioare
    {
        [StringLength(250)]
        public string Comment { get; set; }

        public int? Experience { get; set; }

        public int? FoodGrade { get; set; }

        public int? StaffGrade { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReservationIdReservation { get; set; }

        public int? OverallGrade { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
