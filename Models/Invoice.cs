namespace Realestate_ERP_Dashboard.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Name_Build { get; set; }

        //max lenght <= 12
        public int Monuth { get; set; }

        //acecpt only four of chaar 2024
        public string Year { get; set; }

        public string  Unit_In_Build { get; set; }

        //grater than 0
        public int Electricity  { get; set; }

        //greater than 0
        public int Water  { get; set; }
    }
}
