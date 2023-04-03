using SportClubRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubRegistrationAPI.Services
{
    public interface ISportClubServices
    {
        public Task<int> InsertOrUpdate(SportsClubEntity SC);
        public Task<List<SportsClubEntity>> View();
        public Task<SportsClubEntity> ViewOne(int registration_id);
        public Task<List<SportsClubEntity>> GetClub();
        public Task<List<SportsClubEntity>> GetSports(int club_id);
    }
}
