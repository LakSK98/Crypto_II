using Crypto_II.Data;
using Crypto_II.Models;
using Crypto_II.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto_II.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinDataController : ControllerBase
    {
        private readonly ICoinService coinService;
        private readonly DatabaseContext _context;

        public CoinDataController(DatabaseContext context,ICoinService coinService)
        {
            _context = context;
            this.coinService = coinService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoinData>>> GetCoinData()
        {
            await coinService.getCoinData(_context);
            return await _context.CoinDatas.ToListAsync();
        }
    }
}
