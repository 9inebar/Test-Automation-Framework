using TechTalk.SpecFlow;

namespace BDD.Steps;
[Binding]
public class CalculatorSteps
{
    private CalculatorSteps calculator = new();
    //[Given()]

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(int p0)
    {
        ScenarioContext.StepIsPending();
    }
}