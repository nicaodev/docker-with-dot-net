using dockerContainer.Model;
using dockerContainer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dockerContainer.Controllers;

[ApiController]
[Route("[controller]")]
public class DockerTestController : ControllerBase
{

    private readonly ITesteDockerRepository _testeDockerRepository;
    private Dictionary<string, string> meuDicionario = new Dictionary<string, string>
            {
                { "Testando", "Docker" },
                { "Primeiro - Realease",  "dotnet publish --configuration Release --output dist" },
                { "Segundo - Cria imagem docker", "docker build -t testedocker ." }, // Com base no Dockerfile
                {"Terceiro - Cria container","docker container create -p 3000:80 --name dockertest2 testedocker"},
                {"Quarto - Start container criado","docker container start dockertest2"}
            };

    public DockerTestController(ITesteDockerRepository testeDockerRepository)
    {
        _testeDockerRepository = testeDockerRepository;
    }

    [HttpGet]
    public ActionResult<Dictionary<string, string>> FirstCommands()
    {
        return Ok(meuDicionario);
    }

    [HttpGet("scriptVolume")]
    public ActionResult<TesteDockerDto> scriptVolume()
    {
        return Ok(_testeDockerRepository.TesteDockers);
    }
}