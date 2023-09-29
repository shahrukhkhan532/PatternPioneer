namespace PatternPioneer.Strategies.MessageBuilders
{
    public class DefaultMessageBuilder : MessageBuilderBase
    {
        public override bool CanHandle(Domain.Entities.Rule rule) => true;

        protected override string AddDetails()
        {
            return "We were unable to find a suitable strategy for you.";
        }
    }
}
