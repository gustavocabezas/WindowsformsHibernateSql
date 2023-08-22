using System;

namespace WindowsformsHibernateSql.Models
{
    public class JobsCandidates
    {
        public virtual int Id { get; set; }
        public virtual int JobId { get; set; }
        public virtual int CandidateId { get; set; }
        public virtual String CandidateDocumentId { get; set; }
        public virtual DateTime? DateCreated { get; set; }
        public virtual DateTime? DateUpdated { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual int UpdatedBy { get; set; }
    }
}