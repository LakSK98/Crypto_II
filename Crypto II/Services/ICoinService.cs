using Crypto_II.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto_II.Services
{
    public interface ICoinService
    {
        public Task getCoinData(DatabaseContext context);
        public Task saveCoinData(DatabaseContext context, long timestamp, string coin, decimal price);
    }
}
