using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WindowsformsHibernateSql.Models
{
    public class UserImages
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual int ImageTypeId { get; set; }
        public virtual byte[] ImageData { get; set; } = null;
        public virtual string ImagePath { get; set; } = null;
        public virtual string Metadata { get; set; } = null;
        public virtual bool Active { get; set; } = true;
        public virtual DateTime DateCreated { get; set; } = DateTime.Now;
        public virtual DateTime? DateUpdated { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual int UpdatedBy { get; set; }
    }
}