using System.Collections.Generic;

public partial class PlayerData
{
    public string AccountId { get; set; }
    public long? FnApiId { get; set; }
    public string EpicName { get; set; }
    public string SeasonWindow { get; set; }
    public string[] Devices { get; set; }
    public Data Data { get; set; }
    public OverallData OverallData { get; set; }
}

public partial class Data
{
    public Keyboardmouse Keyboardmouse { get; set; }
    public Gamepad Gamepad { get; set; }
}

public partial class Gamepad
{
    public Defaultsolo Defaultsolo { get; set; }
}

public partial class Defaultsolo
{
    public SoloClass Default { get; set; }
}

public partial class SoloClass
{
    public long? Matchesplayed { get; set; }
    public long? Placetop25 { get; set; }
    public long? Lastmodified { get; set; }
    public long? Playersoutlived { get; set; }
    public long? Placetop10 { get; set; }
    public long? Minutesplayed { get; set; }
    public long? Score { get; set; }
    public long? Kills { get; set; }
}

public partial class Keyboardmouse
{
    public The33 The33 { get; set; }
    public Showdownalt Showdownalt { get; set; }
    public Defaultduo Defaultduo { get; set; }
    public Respawn Respawn { get; set; }
    public Deimos Deimos { get; set; }
    public Barrier Barrier { get; set; }
    public Defaultduo Trios { get; set; }
    public Classic Classic { get; set; }
    public Snipers Snipers { get; set; }
    public The50_V50 The50V50 { get; set; }
    public Bling Bling { get; set; }
    public Close Close { get; set; }
    public Playgroundv2 Playgroundv2 { get; set; }
    public Defaultduo Defaultsquad { get; set; }
    public Defaultsolo Defaultsolo { get; set; }
    public Solidgold Solidgold { get; set; }
    public Blitz Blitz { get; set; }
    public Final Final { get; set; }
    public The50_V50 The5X20 { get; set; }
    public Close Steady { get; set; }
    public Close Highexplosives { get; set; }
    public Playground Playground { get; set; }
    public Creative Creative { get; set; }
    public Showdown Showdown { get; set; }
    public Soaring Soaring { get; set; }
    public Flyexplosives Flyexplosives { get; set; }
    public Score Score { get; set; }
    public Ground Ground { get; set; }
    public The50V50Sau The50V50Sau { get; set; }
    public Disco Disco { get; set; }
}

public partial class Barrier
{
    public The12_Class The12 { get; set; }
}

public partial class The12_Class
{
    public long? Kills { get; set; }
    public long? Matchesplayed { get; set; }
}

public partial class Bling
{
    public Dictionary<string, long> Squad { get; set; }
}

public partial class Blitz
{
    public Squad Squad { get; set; }
    public The12_Class Duo { get; set; }
    public Solo Solo { get; set; }
}

public partial class Solo
{
    public long? Matchesplayed { get; set; }
    public long? Kills { get; set; }
    public long? Placetop10 { get; set; }
    public long? Placetop25 { get; set; }
}

public partial class Squad
{
    public long? Kills { get; set; }
    public long? Placetop6 { get; set; }
    public long? Matchesplayed { get; set; }
    public long? Placetop3 { get; set; }
    public long? Placetop1 { get; set; }
}

public partial class Classic
{
    public The24_Class Squad { get; set; }
}

public partial class The24_Class
{
    public long? Score { get; set; }
    public long? Kills { get; set; }
    public long? Playersoutlived { get; set; }
    public long? Lastmodified { get; set; }
    public long? Minutesplayed { get; set; }
    public long? Matchesplayed { get; set; }
    public long? Placetop12 { get; set; }
    public long? Placetop5 { get; set; }
}

public partial class Close
{
    public Squad Squad { get; set; }
}

public partial class Creative
{
    public Playonly Playonly { get; set; }
}

public partial class Playonly
{
    public long? Score { get; set; }
    public long? Lastmodified { get; set; }
    public long? Minutesplayed { get; set; }
    public long? Matchesplayed { get; set; }
    public long? Playersoutlived { get; set; }
}

public partial class Defaultduo
{
    public Dictionary<string, long> Default { get; set; }
}

public partial class Deimos
{
    public Dictionary<string, long> Squad { get; set; }
    public DuoClass Duo { get; set; }
    public Solo Solo { get; set; }
}

public partial class DuoClass
{
    public long? Placetop12 { get; set; }
    public long? Kills { get; set; }
    public long? Placetop5 { get; set; }
    public long? Matchesplayed { get; set; }
    public long? Placetop1 { get; set; }
}

public partial class Disco
{
    public LargeTeamModes The32 { get; set; }
}

public partial class LargeTeamModes
{
    public long? Placetop1 { get; set; }
    public long? Matchesplayed { get; set; }
    public long? Kills { get; set; }
    public string[] IncludedPlaylists { get; set; }
}

public partial class Final
{
    public LargeTeamModes The20 { get; set; }
}

public partial class Flyexplosives
{
    public PurpleDuo Duo { get; set; }
}

public partial class PurpleDuo
{
    public long? Matchesplayed { get; set; }
}

public partial class Ground
{
    public PurpleDuo Squad { get; set; }
}

public partial class Playground
{
    public PlaygroundDefault Default { get; set; }
}

public partial class PlaygroundDefault
{
    public long? Placetop1 { get; set; }
    public long? Matchesplayed { get; set; }
}

public partial class Playgroundv2
{
    public Playonly Default { get; set; }
}

public partial class Respawn
{
    public The24_Class The24 { get; set; }
}

public partial class Score
{
    public The12_Class Duo { get; set; }
}

public partial class Showdown
{
    public DuoClass Duo { get; set; }
}

public partial class Showdownalt
{
    public SoloClass Solo { get; set; }
    public The24_Class Duo { get; set; }
}

public partial class Snipers
{
    public PurpleDuo Solo { get; set; }
    public DuoClass Duo { get; set; }
    public The12_Class Squad { get; set; }
}

public partial class Soaring
{
    public LargeTeamModes The50S { get; set; }
}

public partial class Solidgold
{
    public DuoClass Duo { get; set; }
    public Playonly Squad { get; set; }
}

public partial class The33
{
    public The24_Class Default { get; set; }
}

public partial class The50_V50
{
    public LargeTeamModes Default { get; set; }
}

public partial class The50V50Sau
{
    public The12_Class Default { get; set; }
}

public partial class OverallData
{
    public Modes DefaultModes { get; set; }
    public Modes LtmModes { get; set; }
    public LargeTeamModes LargeTeamModes { get; set; }
}

public partial class Modes
{
    public long? Playersoutlived { get; set; }
    public long? Matchesplayed { get; set; }
    public long? Score { get; set; }
    public long? Kills { get; set; }
    public long? Placetop1 { get; set; }
    public string[] IncludedPlaylists { get; set; }
}
