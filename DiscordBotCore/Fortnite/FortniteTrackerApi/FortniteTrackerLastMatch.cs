using System;


namespace DiscordBotCore.Fortnite.FortniteTrackerApi
{

    public class FortniteTrackerLastMatch
    {
        public int id { get; set; }
        public DateTime dateCollected { get; set; }
        public int kills { get; set; }
        public int matches { get; set; }
        public string playlist { get; set; }
        public int score { get; set; }
        public int top1 { get; set; }
        public int top10 { get; set; }
        public int top12 { get; set; }
        public int top25 { get; set; }
        public int top3 { get; set; }
        public int top5 { get; set; }
        public int top6 { get; set; }
        public double trnRating { get; set; }
    }
}
