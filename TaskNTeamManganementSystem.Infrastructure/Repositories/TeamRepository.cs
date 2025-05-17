using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNTeamManganementSystem.Application.DTOs;
using TaskNTeamManganementSystem.Application.Interfaces;
using TaskNTeamManganementSystem.Infrastructure.Persistent.Data;

namespace TaskNTeamManganementSystem.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddTeamAsync(TeamsDTO team)
        {
            var newTeam = new Domain.Entities.Team
            {
                Name = team.Name,
                Description = team.Description,
            };
            _context.Teams.Add(newTeam);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return false;
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TeamsDTO>> GetAllTeamsAsync()
        {
            return await Task.FromResult(_context.Teams
                .Select(team => new TeamsDTO
                {
                    Id = team.Id,
                    Name = team.Name,
                    Description = team.Description,
                }).ToList());
        }

        public Task<TeamsDTO> GetTeamByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTeamAsync(TeamsDTO team)
        {
            throw new NotImplementedException();
        }
    }
}
