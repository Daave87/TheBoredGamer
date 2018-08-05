namespace TheBoredGamer.Models.DAL
{
    public class PlayerNumber
    {
        public int Number { get; set; }
        public int BestVotes { get; set; }
        public int RecommendedVotes { get; set; }
        public int NotRecommendedVotes { get; set; }
        public bool AndUp { get; set; }
    }
}