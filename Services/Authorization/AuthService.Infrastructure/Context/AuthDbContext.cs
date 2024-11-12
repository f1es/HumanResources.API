using AuthService.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace AuthService.Infrastructure.Context;

public class AuthDbContext : IdentityDbContext<User>
{
    public AuthDbContext()
    { }
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {

    }
}
