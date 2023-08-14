using System;

namespace WindowsformsHibernateSql.Models
{
    public class Persons
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual int BalanceId { get; set; }
        public virtual string Identification { get; set; } = null;
        public virtual string FirstName { get; set; } = null;
        public virtual string LastName { get; set; } = null;
        public virtual string PrimaryPhoneNumber { get; set; } = null;
        public virtual string SecondaryPhoneNumber { get; set; } = null;
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime? DateUpdated { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual int UpdatedBy { get; set; }
    }
}