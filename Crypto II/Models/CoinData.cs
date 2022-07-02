using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto_II.Models
{
    public class CoinData
    {
        [Key]
        public int Id { get; set; }
        public string Coin { get; set; }
        public decimal Price { get; set; }
        public long TimeStamp { get; set; }
    }
}
