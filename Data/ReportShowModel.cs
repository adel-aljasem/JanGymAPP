using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanGym.Data
{
    public class ReportShowModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string? Note { get; set; }
        public bool UserBlocked { get; set; }
        public bool SubscribeIsActive { get; set; }
        public string AddedBy { get; set; }

        public DateTime DateSub { get; set; }
        public DateTime DateEnd { get; set; }
        public int SubscriptionPeriod { get; set; }
        public int Paid { get; set; }
        public int Unpaid { get; set; }
        public int Total { get; set; }
    }
}

