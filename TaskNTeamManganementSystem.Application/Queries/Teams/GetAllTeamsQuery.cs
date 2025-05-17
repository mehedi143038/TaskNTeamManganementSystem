using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNTeamManganementSystem.Application.DTOs;

namespace TaskNTeamManganementSystem.Application.Queries.Teams
{
    public record GetAllTeamsQuery : IRequest<List<TeamsDTO>>;
}
