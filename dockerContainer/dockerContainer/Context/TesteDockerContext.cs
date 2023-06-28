using dockerContainer.Model;
using Microsoft.EntityFrameworkCore;

namespace dockerContainer.Context;

public class TesteDockerContext : DbContext
{
    public TesteDockerContext(){}

    public TesteDockerContext(DbContextOptions<TesteDockerContext> options) : base(options)
    {
    }

    public DbSet<TesteDockerDto>? testeDockers { get; set; }
}