using SportClubRegistrationAPI.Models;
using SportClubRegistrationAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubRegistrationAPI.Services
{
    public class SportClubServices : ISportClubServices
    {
        private readonly ISportsclubRepository _sportsclubRepository;
        public SportClubServices(ISportsclubRepository sportsclubRepository)
        {
            _sportsclubRepository = sportsclubRepository;
        }

        public async Task<List<SportsClubEntity>> GetClub()
        {
            return await _sportsclubRepository.GetClub();
        }

        public async Task<List<SportsClubEntity>> GetSports(int club_id)
        {
            return await _sportsclubRepository.GetSports(club_id);
        }

        public async Task<int> InsertOrUpdate(SportsClubEntity SC)
        {
            return await _sportsclubRepository.InsertOrUpdate(SC);
        }

        public async Task<List<SportsClubEntity>> View()
        {
            return await _sportsclubRepository.View();
        }

        public async Task<SportsClubEntity> ViewOne(int registration_id)
        {
            return await _sportsclubRepository.ViewOne(registration_id);
        }
    }
}
