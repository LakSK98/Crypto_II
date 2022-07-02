#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto_II.Models
{
    public class CoinPrice
    {
            public string? price { get; set; }
            public string? open { get; set; }
            public string? high_24h { get; set; }
            public string? low_24h { get; set; }
            public long last_updated_timestamp { get; set; }
    }
}
