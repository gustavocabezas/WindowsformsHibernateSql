using System;

namespace WindowsformsHibernateSql.Models
{
    public class Users
    {
        public virtual int Id { get; set; }
        public virtual int ProfileId { get; set; }
        public virtual int UserImageId { get; set; }
        public virtual string Username { get; set; } = string.Empty;
        public virtual string PrimaryEmail { get; set; } = string.Empty;
        public virtual string SecondaryEmail { get; set; } = string.Empty;
        public virtual string Password { get; set; } = string.Empty;
        public virtual string TempPassword { get; set; } = string.Empty;
        public virtual int StatusId { get; set; }
        public virtual DateTime? LastLogin { get; set; }
        public virtual DateTime? DateCreated { get; set; }
        public virtual DateTime? DateUpdated { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual int UpdatedBy { get; set; }
    }
}