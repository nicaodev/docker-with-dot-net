using Microsoft.AspNetCore.Mvc;

namespace dockerContainer.Controllers;

[ApiController]
[Route("[controller]")]
public class DockerTestController : ControllerBase
{
    private Dictionary<string, string> meuDicionario = new Dictionary<string, string>
            {
                { "Testando", "Docker" },
                { "Primeiro - Realease",  "dotnet publish --configuration Release --output dist" },
                { "Segundo - Cria imagem docker", "docker build -t testedocker ." },
                {"Terceiro - Cria container","docker container create -p 3000:80 --name dockertest2 testedocker"},
                {"Quarto - Start container criado","docker container start dockertest2"}
            };

    [HttpGet]
    public ActionResult<Dictionary<string, string>> Get()
    {
        return Ok(meuDicionario);
    }
}