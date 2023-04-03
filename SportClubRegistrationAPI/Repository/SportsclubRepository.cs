using Dapper;
using Microsoft.Extensions.Configuration;
using SportClubRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubRegistrationAPI.Repository
{
    public class SportsclubRepository : BaseRepository, ISportsclubRepository
    {
        public SportsclubRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<List<SportsClubEntity>> GetClub()
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Action", "GetClub");
                var lstste = await cn.QueryAsync<SportsClubEntity>("SP_SportsClub", param, commandType: CommandType.StoredProcedure);
                return lstste.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<SportsClubEntity>> GetSports(int club_id)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@club_id", club_id);
                param.Add("@Action", "GetSports");
                var lstste = await cn.QueryAsync<SportsClubEntity>("SP_SportsClub", param, commandType: CommandType.StoredProcedure);
                return lstste.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> InsertOrUpdate(SportsClubEntity SC)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@registration_id", SC.registration_id);
                param.Add("@applicant_name", SC.applicant_name);
                param.Add("@email_id", SC.email_id);
                param.Add("@mobile_no", SC.mobile_no);
                param.Add("@gender", SC.gender);
                param.Add("@dob", SC.dob);
                param.Add("@image_path", SC.image_path);
                param.Add("@club_id", SC.club_id);
                param.Add("@sports_id", SC.sports_id);
                param.Add("@Action", "InsertOrUpdate");
                int x = await cn.ExecuteAsync("SP_SportsClub", param, commandType: CommandType.StoredProcedure);
                cn.Close();
                return x;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<SportsClubEntity>> View()
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Action", "View");
                var lstste = await cn.QueryAsync<SportsClubEntity>("SP_SportsClub", param, commandType: CommandType.StoredProcedure);
                return lstste.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SportsClubEntity> ViewOne(int registration_id)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@registration_id", registration_id);
                param.Add("@Action", "ViewOne");
                var lstste = await cn.QueryAsync<SportsClubEntity>("SP_SportsClub", param, commandType: CommandType.StoredProcedure);
                return lstste.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
