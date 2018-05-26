namespace DeltaX.DataAccess.Entities
{   

    public partial class MovieActor : Entity<int>
    {

        public int ActorID { get; set; }

        public int MovieID { get; set; }
    }
}
