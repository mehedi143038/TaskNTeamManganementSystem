using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNTeamManganementSystem.Application.DTOs;

namespace TaskNTeamManganementSystem.Application.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<TeamsDTO>> GetAllTeamsAsync();
        Task<TeamsDTO> GetTeamByIdAsync(int id);
        Task<bool> AddTeamAsync(TeamsDTO team);
        Task<bool> UpdateTeamAsync(TeamsDTO team);
        Task<bool> DeleteTeamAsync(int id);
    }
}
