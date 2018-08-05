using System.ComponentModel;

namespace TheBoredGamer.Models.DAL
{
    public enum LanguageDependenceLevel
    {
        [Description("No necessary in-game text")]
        NoNecessaryInGameText = 1,
        [Description("Some necessary text - easily memorized or small crib sheet")]
        SomeNecessaryText = 2,
        [Description("Moderate in-game text - needs crib sheet or paste ups")]
        ModerateInGameText = 3,
        [Description("Extensive use of text - massive conversion needed to be playable")]
        ExtensiveUseOfText = 4,
        [Description("Unplayable in another language")]
        UnplayableInAnotherLanguage = 5
    }
}
