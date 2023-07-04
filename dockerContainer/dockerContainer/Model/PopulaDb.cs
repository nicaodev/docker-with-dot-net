using dockerContainer.Context;
using Microsoft.EntityFrameworkCore;

namespace dockerContainer.Model;

public static class PopulaDb
{
    public static void IncluiDadosDb(IApplicationBuilder app)
    {
        //IncluiDadosDb(app.ApplicationServices.GetRequiredService<TesteDockerContext>());

        IncluiDadosDb(app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<TesteDockerContext>());
    }

    private static void IncluiDadosDb(TesteDockerContext context)
    {
        Console.WriteLine("Aplicando Migration");
        var programador = "Nicolas Alexandre";

        context.Database.Migrate();

        if (!context.testeDockers.Any())
        {
            Console.WriteLine("Escrevendo dados no DB");

            context.testeDockers.AddRange(

                new TesteDockerDto("Testando Volumes com Docker", "", $"{programador}"),
                new TesteDockerDto("1 - Criar Volume", "docker volume create dadosdb", $"{programador}"),
                new TesteDockerDto("2 - Cria imagem docker", "docker image pull mysql:5.7", $"{programador}"),
                new TesteDockerDto("3 - Inspeciona (checar qual pasta usa-se para Volume que a imagem do container)", "docker image inspect mysql:5.7", $"{programador}"),
                new TesteDockerDto("4 - Criar Container a partir da imagem", "docker container run -d --name mysql -v dadosdb:/var/lib/mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=159753 -e bind-addres=0.0.0.0 mysql:5.7", $"{programador}"),
                new TesteDockerDto("5 - Inspecionar a rede virtual que o docker deu para conexão (pegar ip e setar em DBHOST)", "docker network inspect bridge", $"{programador}"),
                new TesteDockerDto("6 - Criar container c base na imagem (controller) e start automatico na migration", "docker container run -d --name appmigrations -p 3000:80 -e DBHOST=172.17.0.2 testedockersql", $"{programador}"),
                new TesteDockerDto("7 - Usando Docker Compose", "docker compose", $"{programador}"),
                new TesteDockerDto("8 - Docker compose", "____________", $"{programador}"),
                new TesteDockerDto("9 - Verificando sintaxe do arquivo.yml", "docker-compose build", $"{programador}"),
                new TesteDockerDto("10 - Fazendo teste com arquivo.yml (Processa arquivo e inicia aplicação)", "docker-compose up -d", $"{programador}"),
                new TesteDockerDto("11 - Remove containers e redes descritas no arquivo.yml", "docker-compose down -v", $"{programador}"),
                new TesteDockerDto("12 - Builder final Docker Compose", "docker-compose -f docker-compose.yml build ", $"{programador}"),
                new TesteDockerDto("13 - Builder final Docker Compose - Quando nome não é o padrao (docker-compose.yml)", "docker-compose -f docker-compose-dev.yml -p dev build", $"{programador}"),
                new TesteDockerDto("14 - Fazendo teste com arquivo.yml (Processa arquivo e inicia aplicação)", "docker-compose -f docker-compose-dev.yml -p dev up mvc ", $"{programador}"),
                new TesteDockerDto("15 - Docker file otimizado", "_________________________________________________", $"{programador}"),
                new TesteDockerDto("16 - Docker file otimizado:", "Arquivo Dockerfile.multi | atrelado ao docker-compose-multi.yml", $"{programador}")
                );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Já existem dados inicializados.");
        }
    }
}