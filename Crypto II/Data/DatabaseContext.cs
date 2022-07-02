using Crypto_II.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto_II.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options):base (options) { }
        public DbSet<CoinData> CoinDatas { get; set; }
    }
}
