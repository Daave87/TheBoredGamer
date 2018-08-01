using System.ComponentModel;

namespace TheBoredGamer.Models
{
    public enum LanguageDependenceLevel
    {
        [Description("No necessary in-game text")]
        NoNecessaryInGameText,
        [Description("Some necessary text - easily memorized or small crib sheet")]
        SomeNecessaryText,
        [Description("Moderate in-game text - needs crib sheet or paste ups")]
        ModerateInGameText,
        [Description("Extensive use of text - massive conversion needed to be playable")]
        ExtensiveUseOfText,
        [Description("Unplayable in another language")]
        UnplayableInAnotherLanguage
    }
}
