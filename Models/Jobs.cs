using System;

namespace WindowsformsHibernateSql.Models
{
    public class Jobs
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string LocationText { get; set; } = string.Empty;
        public virtual string Requirements { get; set; } = string.Empty;
        public virtual string Salary { get; set; } = string.Empty;
        public virtual DateTime? DateCreated { get; set; }
        public virtual DateTime? DateUpdated { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual int UpdatedBy { get; set; }
    }
}