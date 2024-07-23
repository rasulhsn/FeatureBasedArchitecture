using System.ComponentModel.DataAnnotations.Schema;

namespace TMOnline.Shared.Entities
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TransactionYearId { get; set; }
        public virtual TransactionYear TransactionYear { get; set; }
    }
}
