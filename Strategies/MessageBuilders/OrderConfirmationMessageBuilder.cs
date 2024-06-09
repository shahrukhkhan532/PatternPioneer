namespace PatternPioneer.Strategies.MessageBuilders;

using Rule = Domain.Entities.Rule;

public class OrderConfirmationMessageBuilder : MessageBuilderBase
{
    private readonly IUserService _userService;

    public OrderConfirmationMessageBuilder(IUserService userService)
    {
        _userService = userService;
    }
    public override bool CanHandle(Rule rule) => rule.EventId == 1;
    protected override string AddDetails()
    {
        var user = _userService.GetById(2); // For Demo purpose this is hard coded.🥲
        return $"{user.FirstName} {user.LastName}, your order has been confirmed successfully.";
    }
}
