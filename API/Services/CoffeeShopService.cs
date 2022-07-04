using API.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CoffeeShopService : ICoffeeShopService
    {
        private readonly ApplicationDbContext _dbContext;

        public CoffeeShopService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CoffeeShopDto>> List()
        {
            var coffeeShops = await (from shop in _dbContext.CoffeeShops
                                     select new CoffeeShopDto()
                                     {
                                         Id = shop.Id,
                                         Name = shop.Name,
                                         OpeningHours = shop.OpeningHours,
                                         Address = shop.Address
                                     }).ToListAsync();
            return coffeeShops;
        }
    }
}
