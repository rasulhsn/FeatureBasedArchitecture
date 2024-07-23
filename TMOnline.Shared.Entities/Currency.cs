using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMOnline.Shared.Entities
{
    public class Currency
    {
        [Column("CurrencyKey")]
        public int Id { get; set; }

        [Column("CurrencyCode")]
        [StringLength(6)]
        public string Code { get; set; }

        [Column("CurrencyName")]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
