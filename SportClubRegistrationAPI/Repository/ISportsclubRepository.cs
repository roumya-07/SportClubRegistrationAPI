using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportClubRegistrationAPI.Models;

namespace SportClubRegistrationAPI.Repository
{
    public interface ISportsclubRepository
    {
        public Task<int> InsertOrUpdate(SportsClubEntity SC);
        public Task<List<SportsClubEntity>> View();
        public Task<SportsClubEntity> ViewOne(int registration_id);
        public Task<List<SportsClubEntity>> GetClub();
        public Task<List<SportsClubEntity>> GetSports(int club_id);
    }
}
