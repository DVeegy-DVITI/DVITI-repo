namespace CommonCode.BusinessRules
{
    /// <summary> Type guarantee for having a Business rule Evaluation strategy and Mounting point for ISP interfaces.</summary>
    public interface IBusinessRule : IBusinessRuleWithIdentifierString
    {
        IBusinessRuleEvaluationStrategy<dynamic, dynamic> EvaluationStrategy { get; }
    }
}
