using System;
using System.Collections.Generic;

namespace DiscordBotCore.Fortnite.FortniteTrackerApi
{
    public class TrnRating
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public int valueInt { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public double percentile { get; set; }
        public string displayValue { get; set; }
    }

    public class Score
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public int valueInt { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public double percentile { get; set; }
        public string displayValue { get; set; }
    }

    public class Top1
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public int valueInt { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public string displayValue { get; set; }
    }

    public class Top3
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public int valueInt { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public string displayValue { get; set; }
    }

    public class Top5
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public int valueInt { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public string displayValue { get; set; }
    }

    public class Top6
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public int valueInt { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public string displayValue { get; set; }
    }

    public class Top10
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public int valueInt { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public double percentile { get; set; }
        public string displayValue { get; set; }
    }

    public class Top12
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public int valueInt { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public string displayValue { get; set; }
    }

    public class Top25
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public int valueInt { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public double percentile { get; set; }
        public string displayValue { get; set; }
    }

    public class Kd
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public double valueDec { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public double percentile { get; set; }
        public string displayValue { get; set; }
    }

    public class WinRatio
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public double valueDec { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public string displayValue { get; set; }
    }

    public class Matches
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public int valueInt { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public double percentile { get; set; }
        public string displayValue { get; set; }
    }

    public class Kills
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public int valueInt { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public double percentile { get; set; }
        public string displayValue { get; set; }
    }

    public class Kpg
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public double valueDec { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public double percentile { get; set; }
        public string displayValue { get; set; }
    }

    public class ScorePerMatch
    {
        public string label { get; set; }
        public string field { get; set; }
        public string category { get; set; }
        public double valueDec { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public double percentile { get; set; }
        public string displayValue { get; set; }
    }

    public class P2
    {
        public TrnRating trnRating { get; set; }
        public Score score { get; set; }
        public Top1 top1 { get; set; }
        public Top3 top3 { get; set; }
        public Top5 top5 { get; set; }
        public Top6 top6 { get; set; }
        public Top10 top10 { get; set; }
        public Top12 top12 { get; set; }
        public Top25 top25 { get; set; }
        public Kd kd { get; set; }
        public WinRatio winRatio { get; set; }
        public Matches matches { get; set; }
        public Kills kills { get; set; }
        public Kpg kpg { get; set; }
        public ScorePerMatch scorePerMatch { get; set; }
    }

    public class P10
    {
        public TrnRating trnRating { get; set; }
        public Score score { get; set; }
        public Top1 top1 { get; set; }
        public Top3 top3 { get; set; }
        public Top5 top5 { get; set; }
        public Top6 top6 { get; set; }
        public Top10 top10 { get; set; }
        public Top12 top12 { get; set; }
        public Top25 top25 { get; set; }
        public Kd kd { get; set; }
        public WinRatio winRatio { get; set; }
        public Matches matches { get; set; }
        public Kills kills { get; set; }
        public Kpg kpg { get; set; }
        public ScorePerMatch scorePerMatch { get; set; }
    }

    public class P9
    {
        public TrnRating trnRating { get; set; }
        public Score score { get; set; }
        public Top1 top1 { get; set; }
        public Top3 top3 { get; set; }
        public Top5 top5 { get; set; }
        public Top6 top6 { get; set; }
        public Top10 top10 { get; set; }
        public Top12 top12 { get; set; }
        public Top25 top25 { get; set; }
        public Kd kd { get; set; }
        public WinRatio winRatio { get; set; }
        public Matches matches { get; set; }
        public Kills kills { get; set; }
        public Kpg kpg { get; set; }
        public ScorePerMatch scorePerMatch { get; set; }
    }

    public class CurrP2
    {
        public TrnRating trnRating { get; set; }
        public Score score { get; set; }
        public Top1 top1 { get; set; }
        public Top3 top3 { get; set; }
        public Top5 top5 { get; set; }
        public Top6 top6 { get; set; }
        public Top10 top10 { get; set; }
        public Top12 top12 { get; set; }
        public Top25 top25 { get; set; }
        public Kd kd { get; set; }
        public WinRatio winRatio { get; set; }
        public Matches matches { get; set; }
        public Kills kills { get; set; }
        public Kpg kpg { get; set; }
        public ScorePerMatch scorePerMatch { get; set; }
    }

    public class CurrP10
    {
        public TrnRating trnRating { get; set; }
        public Score score { get; set; }
        public Top1 top1 { get; set; }
        public Top3 top3 { get; set; }
        public Top5 top5 { get; set; }
        public Top6 top6 { get; set; }
        public Top10 top10 { get; set; }
        public Top12 top12 { get; set; }
        public Top25 top25 { get; set; }
        public Kd kd { get; set; }
        public WinRatio winRatio { get; set; }
        public Matches matches { get; set; }
        public Kills kills { get; set; }
        public Kpg kpg { get; set; }
        public ScorePerMatch scorePerMatch { get; set; }
    }

    public class CurrP9
    {
        public TrnRating trnRating { get; set; }
        public Score score { get; set; }
        public Top1 top1 { get; set; }
        public Top3 top3 { get; set; }
        public Top5 top5 { get; set; }
        public Top6 top6 { get; set; }
        public Top10 top10 { get; set; }
        public Top12 top12 { get; set; }
        public Top25 top25 { get; set; }
        public Kd kd { get; set; }
        public WinRatio winRatio { get; set; }
        public Matches matches { get; set; }
        public Kills kills { get; set; }
        public Kpg kpg { get; set; }
        public ScorePerMatch scorePerMatch { get; set; }
    }

    public class Stats
    {
        public P2 p2 { get; set; }
        public P10 p10 { get; set; }
        public P9 p9 { get; set; }
        public CurrP2 curr_p2 { get; set; }
        public CurrP10 curr_p10 { get; set; }
        public CurrP9 curr_p9 { get; set; }
    }

    public class LifeTimeStat
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class RecentMatch
    {
        public int id { get; set; }
        public string accountId { get; set; }
        public string playlist { get; set; }
        public int kills { get; set; }
        public int minutesPlayed { get; set; }
        public int top1 { get; set; }
        public int top5 { get; set; }
        public int top6 { get; set; }
        public int top10 { get; set; }
        public int top12 { get; set; }
        public int top25 { get; set; }
        public int matches { get; set; }
        public int top3 { get; set; }
        public DateTime dateCollected { get; set; }
        public int score { get; set; }
        public int platform { get; set; }
        public double trnRating { get; set; }
        public double trnRatingChange { get; set; }
    }

    public class FortniteTrackerData
    {
        public string accountId { get; set; }
        public int platformId { get; set; }
        public string platformName { get; set; }
        public string platformNameLong { get; set; }
        public string epicUserHandle { get; set; }
        public Stats stats { get; set; }
        public IList<LifeTimeStat> lifeTimeStats { get; set; }

        //public IEnumerable<IDictionary<string, string>> LifeTimeStat { get; set; }
        public IList<RecentMatch> recentMatches { get; set; }
    }
}
