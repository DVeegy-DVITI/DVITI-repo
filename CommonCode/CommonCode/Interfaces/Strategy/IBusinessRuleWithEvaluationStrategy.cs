using CommonCode.Interfaces.Strategy;

namespace CommonCode.Interfaces
{
    /// <summary> Interface-intent: Business-rule-members that enable strategy-pattern implementations with a generic signature.</summary>
    public interface IBusinessRuleWithEvaluationStrategy<EvaluationInputType, EvaluationOutputType>
    {
        IBusinessRuleEvaluationStrategy<EvaluationInputType, EvaluationOutputType> EvaluationStrategy { get; }
        EvaluationOutputType ExecuteStrategyLogicWrapper(EvaluationInputType evaluationInput);
    }
}
