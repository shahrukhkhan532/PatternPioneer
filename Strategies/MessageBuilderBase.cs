namespace PatternPioneer.Strategies;
using Rule = Domain.Entities.Rule;

public abstract class MessageBuilderBase
{
    public string BuildMessage()
    {
        var message = InitializeMessage();
        message += AddDetails();
        message += FinalizeMessage();

        return message;
    }
    protected virtual string InitializeMessage()
    {
        return "Starting message: " + Environment.NewLine;
    }

    protected abstract string AddDetails();

    protected virtual string FinalizeMessage()
    {
        return Environment.NewLine + "Message end.";
    }

    public abstract bool CanHandle(Rule rule);

    public override string ToString() => GetType().Name;
}
