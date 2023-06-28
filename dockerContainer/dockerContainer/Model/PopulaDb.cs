﻿using dockerContainer.Context;
using Microsoft.EntityFrameworkCore;

namespace dockerContainer.Model;

public class PopulaDb
{
    public static void IncluiDadosDb(IApplicationBuilder app)
    {
        IncluiDadosDb(app.ApplicationServices.GetRequiredService<TesteDockerContext>());
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
                new TesteDockerDto("Primeiro - Criar Volume", "docker volume create dadosdb", "Nicolas Alexandre"),
                new TesteDockerDto("Segundo - Cria imagem docker", "docker image pull mysql:5.7", "Nicolas Alexandre"),
                new TesteDockerDto("Terceiro - Inspeciona (checar qual pasta usa-se para Volume que a imagem do container)", "docker image inspect mysql:5.7", "Nicolas Alexandre"),
                new TesteDockerDto("Quarto - Criar Container a partir da imagem", "docker container run -d --name mysql -v dadosdb:/var/lib/mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=159753 -e bind-addres=0.0.0.0 mysql:5.7", "Nicolas Alexandre"),
                new TesteDockerDto("Quinta - Inspecionar a rede virtual que o docker deu para conexão (pegar ip e setar em DBHOST)", "docker network inspect bridge", "Nicolas Alexandre"),
                new TesteDockerDto("Sexto - Criar container c base na imagem (controller) e start automatico na migration", "docker container run -d --name appmigrations -p 3000:80 -e DBHOST=172.17.0.2 testedockersql", "Nicolas Alexandre")
                );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Já existem dados inicializados.");
        }
    }
}