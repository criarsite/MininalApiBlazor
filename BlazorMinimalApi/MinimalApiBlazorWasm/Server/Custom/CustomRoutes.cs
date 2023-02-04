using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Custom;

public static class CustomRoutes
{

    public static void ConfigureCustomRoutes(this WebApplication app)
    {
        // Configira a mininal api
        // Listar todos os Posts
        app.MapGet("/Posts", async (Contexto db) =>
        {
            try
            {
                var result = await db.Posts.ToListAsync();
                return Results.Ok(result);
            }
            catch (System.Exception ex)
            {
                return Results.Problem(ex.Message);
            }


        });

        // Cadastrar um Posts
        app.MapPost("/Posts", async (Post post, Contexto db) =>
        {
            try
            {
                db.Posts.Add(post);
                await db.SaveChangesAsync();
                return Results.Created($"/Post/{post.PostId}", post);
            }
            catch (System.Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        });

        //Buscar por ID

        app.MapGet("/Posts/{postId}", async (int postId, Contexto db) =>
        {
            var post = await db.Posts.FindAsync(postId);
            if (post == null)
            {
                return Results.NotFound();

            }
            return Results.Ok(post);


        });

        //Atualizar Post

        app.MapPut("/Posts/{postId}", async (int postId, Post post, Contexto db) =>
        {

            var AtualizarPost = await db.Posts.FindAsync(postId);
            if (post == null)
            {
                return Results.NotFound();

            }

            AtualizarPost.Title = post.Title;
            AtualizarPost.Content = post.Content;


            await db.SaveChangesAsync();


            return Results.Ok(post);

        });


        // Deletar Post

        app.MapDelete("/Posts/{postId}", async (int postId, Contexto db) =>
        {
            var Deletar = await db.Posts.FindAsync(postId);
            if (Deletar == null)
            {
                return Results.NotFound();
            }
            db.Posts.Remove(Deletar);
            await db.SaveChangesAsync();
            return Results.Ok();


        });


    }



}
