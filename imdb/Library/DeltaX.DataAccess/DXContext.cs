namespace DeltaX.DataAccess
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using DeltaX.DataAccess.Entities;
    using DeltaX.Core.POCO;

    public partial class DXContext : DbContext
    {
        public DXContext(DbContextOptions<DXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieActor> MovieActors { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<ProducerPoco> ProducersMini { get; set; }        
        public virtual DbSet<AllMoviesData> AllMoviesData { get; set; }
        public virtual DbSet<ActorMini> ActorMini { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
    
    
}
