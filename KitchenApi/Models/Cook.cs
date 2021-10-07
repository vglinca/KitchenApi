using System;

namespace KitchenApi.Models
{
    public class Cook
    {
        public Guid Id { get; }
        public int Proficiency { get; set; }
        public string Name { get; set; }
        public CookRank Rank { get; set; }
        public string CatchPhrase { get; set; }

        public Cook()
        {
            Id = Guid.NewGuid();
        }
    }
}