using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNTeamManganementSystem.Application.DTOs;
using TaskNTeamManganementSystem.Application.Interfaces;
using TaskNTeamManganementSystem.Application.Queries.Teams;

namespace TaskNTeamManganementSystem.Application.Handlers.QueryHandlers
{
    public class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, List<TeamsDTO>>
    {
        private readonly ITeamRepository _teamRepository;
        public GetAllTeamsQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public async Task<List<TeamsDTO>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teamRepository.GetAllTeamsAsync();
            return teams;
        }
    }
}
