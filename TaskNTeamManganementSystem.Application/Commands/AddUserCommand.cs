using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNTeamManganementSystem.Application.Commands
{
    public record AddUserCommand(string FullName, string Email, string Role) : IRequest<bool>;
}
