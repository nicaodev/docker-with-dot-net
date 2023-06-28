using dockerContainer.Context;
using Microsoft.EntityFrameworkCore;

namespace dockerContainer.Model;

public class PopulaDb
{
    public static void IncluiDadosDb(IApplicationBuilder app)
    {
        IncluiDadosDb(
            app.ApplicationServices.GetRequiredService<TesteDockerContext>());
    }

    private static void IncluiDadosDb(TesteDockerContext context)
    {
        Console.WriteLine("Aplicando Migration");

        context.Database.Migrate();

        if (!context.testeDockers.Any())
        {
            Console.WriteLine("Escrevendo dados no DB");

            context.testeDockers.AddRange(

                new TesteDockerDto("Testando Volumes com Docker", "Docker volume ls", "Nicolas Alexandre"),
                new TesteDockerDto("Primeiro - Realease", "dotnet publish --configuration Release --output dist", "Nicolas Alexandre"),
                new TesteDockerDto("Segundo - Cria imagem docker", "docker build -t testedocker .", "Nicolas Alexandre"),
                new TesteDockerDto("Terceiro - Cria container", "docker container create -p 3000:80 --name dockertest2 testedocker", "Nicolas Alexandre"),
                new TesteDockerDto("Quarto - Start container criado", "docker container start dockertest2", "Nicolas Alexandre")
                );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Já existem dados inicializados.");
        }
    }
}