using dockerContainer.Context;
using dockerContainer.Model;

namespace dockerContainer.Repository;

public class TesteDockerRepository : ITesteDockerRepository
{
    private TesteDockerContext _context;

    public TesteDockerRepository(TesteDockerContext context)
    {
        _context = context;
    }

    public IEnumerable<TesteDockerDto> TesteDockers => _context.testeDockers;
}