
using Rule = PatternPioneer.Domain.Entities.Rule;

namespace PatternPioneer.Factories;

public class MessageBuilderEngine
{
    private readonly IEnumerable<MessageBuilderBase> _strategies;

    public MessageBuilderEngine(IEnumerable<MessageBuilderBase> strategies)
    {
        _strategies = strategies ?? throw new ArgumentNullException(nameof(strategies));
        #region If you don't want to use DI 🙂
        //_strategies = new List<IMessageBuilder>
        //{
        //    new OrderConfirmationMessageBuilder(),
        //    new ProfileUpdateAlertMessageBuilder(),
        //    new UserRegistrationMessageBuilder()
        //};
        #endregion
    }
    public MessageBuilderBase GetStrategy(Rule rule)
    {
        return _strategies.First(s => s.CanHandle(rule));
    }
}
