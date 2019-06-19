namespace OSSGolfLeagueManager.Functions.Models
{
    public class Player
    {
        public Player()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Preferred { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }

        public PlayerOrSub PlayerOrSub { get; set; }

        public string Phone { get; set; }

    }

    public enum PlayerOrSub
    {
        Player,
        Sub

    }
}