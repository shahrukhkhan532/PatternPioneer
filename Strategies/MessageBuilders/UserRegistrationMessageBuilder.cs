namespace PatternPioneer.Strategies.MessageBuilders;
using Rule = Domain.Entities.Rule;

public class UserRegistrationMessageBuilder : MessageBuilderBase
{
    public override bool CanHandle(Rule rule) => rule.EventId == 3;

    protected override string AddDetails()
    {
        return "A new user has registered successfully.";
    }
}
