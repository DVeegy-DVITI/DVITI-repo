namespace CommonCode.BusinessRules
{
    /// <summary> Type guarantee for having a Business rule Evaluation strategy Exposed result property.</summary>
    public interface IBusinessRuleEvaluationStrategy<TInput, TOutput>
    {
        TOutput ExecuteStrategy(TInput input);
    }
}
