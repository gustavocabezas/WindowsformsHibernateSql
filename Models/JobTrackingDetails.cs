using System;
using System.Web.UI.WebControls;

namespace WindowsformsHibernateSql.Models
{
    public class JobTrackingDetails
    {
        public virtual int Id { get; set; }
        public virtual string CandidateName { get; set; }
        public virtual DateTime? ApplicationDate { get; set; }
        public virtual string JobTitle { get; set; } = string.Empty;
        public virtual string CandidateDocumentId { get; set; } = string.Empty;
    }
}