using System;

namespace TrackUrRequest
{
    public class Complaint
    {
        public int ComplaintID { get; set; }
        public string UserName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Priority { get; set; }

        public string Status { get; set; }

        public Complaint(int id, string userName, string category, string description)
        {
            ComplaintID = id;
            UserName = userName;
            Category = category;
            Description = description;
            Priority = id;
            Date = DateTime.Now;
            Status = "Pending";
        }

        public override string ToString()
        {
            return $"{ComplaintID},{UserName},{Category},{Description},{Date},{Priority},{Status}";
        }
    }
}
