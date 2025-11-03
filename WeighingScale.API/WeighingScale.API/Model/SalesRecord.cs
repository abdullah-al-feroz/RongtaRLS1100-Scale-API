using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WeighingScale.API.Model
{
    public class SalesRecord
    {

        [Column("id")]
        [JsonIgnore]
        public int Id { get; set; }

        [Column("weight")]
        public double Weight { get; set; }

        [Column("plu_name")]
        public string PluName { get; set; } = string.Empty;

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("unit_price")]
        public double UnitPrice { get; set; }

        [Column("total_price")]
        public double TotalPrice { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
