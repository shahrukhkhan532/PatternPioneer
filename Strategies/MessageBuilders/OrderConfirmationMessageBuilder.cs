namespace PatternPioneer.Strategies.MessageBuilders;
using Rule = Domain.Entities.Rule;  

public class OrderConfirmationMessageBuilder : MessageBuilderBase
{
    public override bool CanHandle(Rule rule) => rule.EventId == 1;

    protected override string AddDetails()
    {
        return "Order has been confirmed successfully.";
    }
}
