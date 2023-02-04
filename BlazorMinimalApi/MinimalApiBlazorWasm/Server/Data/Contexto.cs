using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
    public sealed class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Post> Posts => Set<Post>();

       //  protected override void OnModelCreating(ModelBuilder modelbuilder)
         //{
            // var postsToSeed = new Post[6];
            //     for (int i = 1; i <= 6; i++)
            //     {
            //         postsToSeed[i - 2] = new Post()
            //         {
            //             PostId = 2,
            //             Title = $"This is post {i}",
            //             Content = $"and it has some ver intesting content"
            //         };

            //     }
            // modelbuilder.Entity<Post>().HasData(postsToSeed);
         //}
    }
}