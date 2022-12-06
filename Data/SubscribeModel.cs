using System.ComponentModel.DataAnnotations.Schema;

namespace JanGym.Data
{
    public class SubscribeModel
    {
        public int IdParent { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateEnd { get; set; }
        public int SubscriptionPeriod { get; set; }
        public int? Paid { get; set; }
        public int Unpaid { get; set; }
        public int? Total { get; set; }
        [ForeignKey("IdParent")]
        public virtual TraineeInfoModel RegisterNewTraineemodel { get; set; }
    }
}
