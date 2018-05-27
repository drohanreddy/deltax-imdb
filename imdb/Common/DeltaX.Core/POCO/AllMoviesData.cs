using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeltaX.Core.POCO
{
    public class AllMoviesData
    {
        [Key]
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public int YearOfRelease { get; set; }
        public string MoviePoster { get; set; }
        public int ProducerID { get; set; }
        public string ProducerName { get; set; }
        public string Plot { get; set; }
        public virtual List<ActorPoco> Actors { get; set; }
    }

    public class SaveMoviesData
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public int YearOfRelease { get; set; }
        public string MoviePoster { get; set; }
        public int ProducerID { get; set; }
        public string ProducerName { get; set; }
        public string Plot { get; set; }
        public virtual List<ActorPoco> Actors { get; set; }
        public IFormFile poster { get; set; }
    }

    public class ActorPoco
    {
        [Key]
        public int ActorID { get; set; }
        public string ActorName { get; set; }
    }

    public class MovieAndActor
    {
        public int MovieID { get; set; }
        public int ActorID { get; set; }
        public string ActorName { get; set; }
    }

    public class ActorMini
    {
        [Key]
        public int ActorID { get; set; }
        public string ActorName { get; set; }
    }
}
