using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderwaterBot.Modules;
using Microsoft.EntityFrameworkCore;

namespace UnderwaterBot.DAL
{

    public interface IFishRepository
    {
        Task<Fish> GetFishByName(string fishName);
        Task<List<Fish>> GetAllFish();
    }

    public class FishRepository : IFishRepository
    {
        private readonly FishContext _db;
        public FishRepository(FishContext db)   
        {
            _db = db;
        }

        public async Task<Fish> GetFishByName(string fishName)
        {
            fishName = fishName.ToLower();
            return await _db.FishCollection.AsQueryable().FirstOrDefaultAsync(f => f.Fishes.ToLower() == fishName).ConfigureAwait(false);
        }

        public async Task<List<Fish>> GetAllFish()
        {
        /*    Random rnd = new Random();
            rnd.Next(); */
            List<Fish> fish = await _db.FishCollection.AsQueryable().Select(f => new Fish
            {
                Fishes = f.Fishes,
            }).ToListAsync();
            return fish;

            
        }

    }
}

