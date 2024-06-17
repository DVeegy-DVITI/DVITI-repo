namespace CommonCode.BusinessRules
{
    /// <summary> Enables polymorphism and Mounting point for shared ISP interfaces.</summary>
    public abstract class BusinessRuleBase<TInput, TOutput> : IBusinessRule
    {
        // [INSTANCE Backing Fields]
        // Note: Allows anyone to define an acceptable process for the implied purpose
        public delegate string GenerateIdentifierString<T>(T item);

        // [STATIC Property members]
        // [INSTANCE Property members]
        virtual public string IdentifierString { get; protected set; }
        virtual public IBusinessRuleEvaluationStrategy<TInput, TOutput> EvaluationStrategy { get; protected set; }

        // [STATIC Method members]
        // [INSTANCE Method members]
    }
}
