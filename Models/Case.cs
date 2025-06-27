namespace Realestate_ERP_Dashboard.Models
{
    public class Case
    {
        public int Id { get; set; }
        public string CaseNumber { get; set; }
        public DateTime Date { get; set; }
        public string AppealNumber { get; set; }

        public string FirstNumber { get; set; }
        public string DistinctionNumber { get; set; }
    }
}
