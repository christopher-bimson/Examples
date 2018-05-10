using TechTalk.SpecFlow;

namespace Google.Specflow.Steps
{
    /// <remarks>
    /// Idea borrowed from https://stackoverflow.com/a/13971643.
    /// Makes simple use of Scenario Context much less ugly.
    /// </remarks>
    internal static class Current<T> where T : class
    {
        internal static T Value
        {
            get => ScenarioContext.Current.Get<T>();
            set => ScenarioContext.Current.Set(value); 
        }
    }
}
