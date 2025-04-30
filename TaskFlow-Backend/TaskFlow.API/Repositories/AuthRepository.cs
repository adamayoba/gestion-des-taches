using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskFlow.API.Data;
using TaskFlow.API.Interfaces;
using TaskFlow.API.Models;

namespace TaskFlow.API.Repositories
{
  public class AuthRepository : IAuthRepository
  {

    private readonly AppDbContext _context;
    public AuthRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<User?> Login(string username, string password)
    {
      var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
      if (user == null) return null;

      using var hmac = new HMACSHA512(user.PasswordSalt);
      var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

      if(!computeHash.SequenceEqual(user.PasswordHash)) return null;

      return user;
    }

    public async Task<User?> Register(User user, string password)
    {
      using var hmac = new HMACSHA512();
      user.PasswordSalt = hmac.Key;
      user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
      
      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();

      return user;
    }

    public async Task<bool> UserExists(string username)
    {
      return await _context.Users.AnyAsync(u => u.Username == username);
    }
  }
}