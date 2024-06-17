namespace CommonCode.BusinessRules
{
    /// <summary> Custom Type for Systematic Business Rules.</summary>
    // TODO: Edit summaries in order to convey the strategy pattern intergration
    public class BusinessRule<TInput, TOutput> : BusinessRuleBase
    {
        // [INSTANCE Backing Fields]
        private string _identifierString;
        private IBusinessRuleEvaluationStrategy<TInput, TOutput> _evaluationStrategy;
        // [STATIC Backing Fields]
        /// <summary> Private backing field for the Singleton Manager instance.</summary>
        private static BusinessRuleManager _businessRuleManagerInstance;
        // [INSTANCE Backing Fields]

        // [STATIC Constructor member]
        /// <summary> Static constructor encapsulating all static initializations.</summary>
        static BusinessRule()
        {
            // [Instantiate backing fields]
            _businessRuleManagerInstance = BusinessRuleManager.BusinessRuleManagerInstance;
            // [Instantiate (auto) properties]
        }
        // [INSTANCE Constructor members]
        /// <summary> Argumented constructor requiring rule identification sentence and conditional logic.</summary>
        /// TODO: The implied Func argument should be dynamic, but maybe all br-signatures share common aspects (restrict?)
        public BusinessRule(string identifierString, IBusinessRuleEvaluationStrategy<TInput, TOutput> evaluationStrategy)
        {
            _identifierString = identifierString;
            _evaluationStrategy = evaluationStrategy;
        }

        // [STATIC Property members]
        // [INSTANCE Property members]
        /// <summary> Exposes the identifier sentence for this business rule. Inherit for subtypes.</summary>
        public override string IdentifierString { get { return _identifierString; } protected set { _identifierString = value; } }
        public override IBusinessRuleEvaluationStrategy<TInput, TOutput> EvaluationStrategy { get { return _evaluationStrategy; } protected set { _evaluationStrategy = value; } }

        // [STATIC Helper Method members]
        // [INSTANCE Helper Method members]

        // [STATIC Logger Method members]
        // [STATIC ErrorHandler Method members]
    }
}
