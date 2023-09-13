using Microsoft.EntityFrameworkCore;
using SoulCoderzAPI.Models;

namespace SoulCoderzAPI.Data;

public class MySQLContext : DbContext
{
  public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
  {}

  public DbSet<User> Users { get; set; }
  public DbSet<Message> Messages { get; set; }
}