using System;

namespace WindowsformsHibernateSql.Models
{
    public class Candidates
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual DateTime? DateCreated { get; set; }
        public virtual DateTime? DateUpdated { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual int UpdatedBy { get; set; }
    }
}