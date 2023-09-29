namespace PatternPioneer.Strategies.MessageBuilders;
using Rule = Domain.Entities.Rule;

public class ProfileUpdateAlertMessageBuilder : MessageBuilderBase
{
    public override bool CanHandle(Rule rule) => rule.EventId == 2;

    protected override string AddDetails()
    {

        return "User profile has been updated.";
    }
}
