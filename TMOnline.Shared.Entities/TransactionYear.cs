namespace TMOnline.Shared.Entities
{
    public class TransactionYear
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int? GroupCurrencyId { get; set; }
        public virtual Currency GroupCurrency { get; set; }
    }
}
