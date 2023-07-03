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

        context.Database.Migrate();

        if (!context.testeDockers.Any())
        {
            Console.WriteLine("Escrevendo dados no DB");

            context.testeDockers.AddRange(

                new TesteDockerDto("Testando Volumes com Docker", "", "Nicolas Alexandre"),
                new TesteDockerDto("1 - Criar Volume", "docker volume create dadosdb", "Nicolas Alexandre"),
                new TesteDockerDto("2 - Cria imagem docker", "docker image pull mysql:5.7", "Nicolas Alexandre"),
                new TesteDockerDto("3 - Inspeciona (checar qual pasta usa-se para Volume que a imagem do container)", "docker image inspect mysql:5.7", "Nicolas Alexandre"),
                new TesteDockerDto("4 - Criar Container a partir da imagem", "docker container run -d --name mysql -v dadosdb:/var/lib/mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=159753 -e bind-addres=0.0.0.0 mysql:5.7", "Nicolas Alexandre"),
                new TesteDockerDto("5 - Inspecionar a rede virtual que o docker deu para conexão (pegar ip e setar em DBHOST)", "docker network inspect bridge", "Nicolas Alexandre"),
                new TesteDockerDto("6 - Criar container c base na imagem (controller) e start automatico na migration", "docker container run -d --name appmigrations -p 3000:80 -e DBHOST=172.17.0.2 testedockersql", "Nicolas Alexandre"),
                new TesteDockerDto("7 - Usando Docker Compose", "docker compose", "Nicolas Alexandre"),
                new TesteDockerDto("8 - Docker compose", "____________", "Nicolas Alexandre"),
                new TesteDockerDto("9 - Verificando sintaxe do arquivo.yml", "docker-compose build", "Nicolas Alexandre"),
                new TesteDockerDto("10 - Fazendo teste com arquivo.yml (Processa arquivo e inicia aplicação)", "docker-compose up -d", "Nicolas Alexandre"),
                new TesteDockerDto("10 - Remove containers e redes descritas no arquivo.yml", "docker-compose down -v", "Nicolas Alexandre"),
                new TesteDockerDto("11 - Builder final Docker Compose", "docker-compose -f docker-compose.yml build ", "Nicolas Alexandre")
                );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Já existem dados inicializados.");
        }
    }
}