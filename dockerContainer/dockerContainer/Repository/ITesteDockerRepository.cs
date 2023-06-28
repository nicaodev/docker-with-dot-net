using dockerContainer.Model;

namespace dockerContainer.Repository;

public interface ITesteDockerRepository
{
    IEnumerable<TesteDockerDto> TesteDockers { get; }
}