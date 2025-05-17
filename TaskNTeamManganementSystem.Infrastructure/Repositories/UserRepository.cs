using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNTeamManganementSystem.Application.DTOs;
using TaskNTeamManganementSystem.Application.Interfaces;
using TaskNTeamManganementSystem.Domain.Entities;
using TaskNTeamManganementSystem.Infrastructure.Persistent.Data;

namespace TaskNTeamManganementSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return await _context.Users
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role,
                }).ToListAsync();
        }
        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"User with ID {id} not found.");
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
            };
        }
        public async Task<bool> AddUserAsync(UserDto user)
        {
            _context.Users.Add(new User
            {
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
            });
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateUserAsync(UserDto user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                _logger.LogWarning($"User with ID {user.Id} not found.");
                throw new KeyNotFoundException($"User with ID {user.Id} not found.");
            }
            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            existingUser.Role = user.Role;
            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"User with ID {id} not found.");
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
