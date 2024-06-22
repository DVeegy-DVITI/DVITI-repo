using System;
using System.Collections.Generic;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        string output = default;
        string whiteSpacesRemovedFromText = plaintext.Replace(" ", "");
        string lowercaseAppliedFromText = whiteSpacesRemovedFromText.ToLower();
        output = lowercaseAppliedFromText;
        return output;
    }

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public static string Encoded(string plaintext)
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public static string Ciphertext(string plaintext)
    {
        throw new NotImplementedException("You need to implement this method.");
    }
}

namespace CommonCode.BusinessRules
{
    /// <summary> Custom Type for Systematic Business Rules.</summary>
    // TODO: Edit summaries in order to convey the strategy pattern intergration
    public class BusinessRule<EvaluationInputType, EvaluationOutputType> : BusinessRuleBase<EvaluationInputType, EvaluationOutputType>
    {
        // [INSTANCE Backing Fields]
        private string _identifierString;
        private IBusinessRuleEvaluationStrategy<EvaluationInputType, EvaluationOutputType> _evaluationStrategy;
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
        public BusinessRule(string identifierString, IBusinessRuleEvaluationStrategy<EvaluationInputType, EvaluationOutputType> evaluationStrategy)
        {
            _identifierString = identifierString;
            _evaluationStrategy = evaluationStrategy;
        }

        // [STATIC Property members]
        // [INSTANCE Property members]
        /// <summary> Exposes the identifier sentence for this business rule. Inherit for subtypes.</summary>
        public override string IdentifierString { get { return _identifierString; } protected set { _identifierString = value; } }
        public override IBusinessRuleEvaluationStrategy<EvaluationInputType, EvaluationOutputType> EvaluationStrategy { get { return _evaluationStrategy; } protected set { _evaluationStrategy = value; } }

        // [STATIC Helper Method members]
        // [INSTANCE Helper Method members]

        // [STATIC Logger Method members]
        // [STATIC ErrorHandler Method members]
    }

    /// <summary> Enables polymorphism and Mounting point for shared ISP interfaces.</summary>
    public abstract class BusinessRuleBase<EvaluationInputType, EvaluationOutputType> : IBusinessRule<EvaluationInputType, EvaluationOutputType>
    {
        // [INSTANCE Backing Fields]
        // Note: Allows anyone to define an acceptable process for the implied purpose
        public delegate string GenerateIdentifierString<T>(T item);

        // [STATIC Property members]
        // [INSTANCE Property members]
        virtual public string IdentifierString { get; protected set; }
        virtual public IBusinessRuleEvaluationStrategy<EvaluationInputType, EvaluationOutputType> EvaluationStrategy { get; protected set; }

        // [STATIC Method members]
        // [INSTANCE Method members]
    }

    /// <summary> Singleton Factory responsible for manufacturing instances and initializing their Singleton Manager.</summary>
    public class BusinessRuleFactory
    {
        // [STATIC Delegate Signatures]

        // [STATIC Backing Fields]
        /// <summary> Private backing field for the Singleton Factory instance.</summary>
        private static BusinessRuleFactory _businessRuleFactoryInstance;
        /// <summary> Private backing field for the Singleton Manager instance.</summary>
        private static BusinessRuleManager _businessRuleManagerInstance;
        // [INSTANCE Backing Fields]

        // [STATIC Constructor member]
        /// <summary> Static constructor encapsulating all static initializations.</summary>
        static BusinessRuleFactory()
        {
            // [Instantiate backing fields]
            _businessRuleManagerInstance = default;
            _businessRuleManagerInstance = BusinessRuleManager.BusinessRuleManagerInstance;
            // [Instantiate (auto) properties]
        }
        // [INSTANCE Constructor members]
        /// <summary> Private constructor enforcing the Singleton pattern.</summary>
        private BusinessRuleFactory() { }

        // [STATIC Property members]
        /// <summary> Exposes retrieval/creation of the Factory instance.</summary>
        public static BusinessRuleFactory BusinessRuleFactoryInstance
        {
            get
            {
                if (_businessRuleFactoryInstance == null)
                {
                    _businessRuleFactoryInstance = new BusinessRuleFactory();
                }
                return _businessRuleFactoryInstance;
            }
        }
        // [INSTANCE Property members]

        // [STATIC Method members]
        // [INSTANCE Method members]
        /// <summary> Exposes a Manufacture method with datachecks for Business Rules.</summary>
        public BusinessRule<EvaluationInputType, EvaluationOutputType> CreateBusinessRule<EvaluationInputType, EvaluationOutputType>(string identifier, IBusinessRuleEvaluationStrategy<EvaluationInputType, EvaluationOutputType> evaluationStrategy)
        {
            // [Define Segment] Declare and Intialise members
            BusinessRule<EvaluationInputType, EvaluationOutputType> newBusinessRule = default;

            // [Process Segment] Employ defined members in processes
            try
            {
                newBusinessRule = new BusinessRule<EvaluationInputType, EvaluationOutputType>(identifier, evaluationStrategy);
            }
            catch (Exception)
            {
                throw new NotImplementedException("Something went wrong during a business rule constructor call");
            }

            try
            {
                ProcessDataChecksOnInput(newBusinessRule);
            }
            catch (Exception)
            {
                throw new NotImplementedException("Something went wrong during a business rule datachecks call");
            }

            // [Conclude Segment] Execute the method's intent
            return newBusinessRule;
        }

        // [STATIC Helper Method members]
        // [INSTANCE Helper Method members]
        /// <summary> Abstracts the Orchestration of [Input Data Checks] of Business Rule manufacturing. Override for substypes.</summary>
        protected virtual void ProcessDataChecksOnInput<EvaluationInputType, EvaluationOutputType>(BusinessRule<EvaluationInputType, EvaluationOutputType> newBusinessRule)
        {
            // [Conclude Segment] Execute the method's intent
            PerformIsDuplicateInRepositoryCheck(newBusinessRule);
        }
        /// <summary> Abstracts the [Duplicate Check] of [Input Data Checks] of Business Rule manufacturing. Override for substypes.</summary>
        protected virtual void PerformIsDuplicateInRepositoryCheck<EvaluationInputType, EvaluationOutputType>(BusinessRule<EvaluationInputType, EvaluationOutputType> newBusinessRule)
        {
            // [Define Segment] Declare and Intialise members
            /// <summary> Local member defining the process of aqcuiring the Identifier string.</summary>
            BusinessRuleBase<EvaluationInputType, EvaluationOutputType>.GenerateIdentifierString<IBusinessRuleWithIdentifierString> providedGetIdentifierStringLogic = (businessRule) => businessRule.IdentifierString;

            // [Conclude Segment] Execute the method's intent
            _businessRuleManagerInstance.CheckIsDuplicateGenericly(newBusinessRule, providedGetIdentifierStringLogic);
        }

        // [STATIC Logger Method members]
        // [STATIC ErrorHandler Method members]
    }

    /// <summary> Singleton Manager responsible for managing instances after creation.</summary>
    public class BusinessRuleManager
    {
        // [STATIC Delegate Signatures]

        // [STATIC Backing Fields]
        /// <summary> Private backing field for the Singleton Manager instance.</summary>
        private static BusinessRuleManager _businessRuleManagerInstance;
        private static HashSet<IBusinessRuleWithIdentifierString> _businessRules;
        // [INSTANCE Backing Fields]

        // [STATIC Constructor member]
        /// <summary> Static constructor encapsulating all static initializations.</summary>
        static BusinessRuleManager()
        {
            // [Instantiate backing fields]
            _businessRuleManagerInstance = default;
            _businessRules = new HashSet<IBusinessRuleWithIdentifierString>();
            // [Instantiate (auto) properties]
        }
        // [INSTANCE Constructor members]
        /// <summary> Private constructor enforcing the Singleton pattern.</summary>
        private BusinessRuleManager()
        {
            /// TODO: There's no code restriction codeifying the 1:1 relation between Manager and Factory. (anyone could instantiate a Manager; No solution found.)
        }

        // [STATIC Property members]
        /// <summary> Exposes the uniques-only set of all instances.</summary>
        /// TODO: Mount a repository pattern here
        public static HashSet<IBusinessRuleWithIdentifierString> BusinessRules { get { return _businessRules; } }
        /// <summary> Exposes retrieval/creation of the Factory instance.</summary>
        public static BusinessRuleManager BusinessRuleManagerInstance
        {
            get
            {
                if (_businessRuleManagerInstance == null)
                {
                    _businessRuleManagerInstance = new BusinessRuleManager();
                }
                return _businessRuleManagerInstance;
            }
        }
        // [INSTANCE Property members]

        // [STATIC Method members]
        // [INSTANCE Method members]
        /// <summary> Checks if a generic business rule is a duplicate in the all-instances-set and throws an error if so.</summary>
        public virtual void CheckIsDuplicateGenericly<T, EvaluationInputType, EvaluationOutputType>(T targetOfCheck, BusinessRule<EvaluationInputType, EvaluationOutputType>.GenerateIdentifierString<IBusinessRuleWithIdentifierString> receivedGetIdentifierStringLogic)
        where T : IBusinessRuleWithIdentifierString
        {
            bool wasItemAdded = BusinessRules.Add(targetOfCheck);
            if (!wasItemAdded)
            {
                string identifierString = receivedGetIdentifierStringLogic(targetOfCheck);
                throw new InvalidOperationException($"The creation of a duplicate element is prohibited. Identifier:\n'{identifierString}'.");
            }
        }

        // [STATIC Helper Method members]
        // [INSTANCE Helper Method members]

        // [STATIC Logger Method members]
        // [STATIC ErrorHandler Method members]
    }

    /// <summary> Type guarantee for having a Business rule Evaluation strategy and Mounting point for ISP interfaces.</summary>
    public interface IBusinessRule<EvaluationInputType, EvaluationOutputType> : IBusinessRuleWithIdentifierString
    {
        IBusinessRuleEvaluationStrategy<EvaluationInputType, EvaluationOutputType> EvaluationStrategy { get; }
    }
    public interface IBusinessRuleEvaluationStrategy<EvaluationInputType, EvaluationOutputType>
    {
        EvaluationOutputType ExecuteStrategy();
    }
    /// <summary> Type guarantee for capacity to produce a business rule identifying string.</summary>
    /// TODO: Collection-intent id'ing and DIP rely on abstractions (confusing pair of interfaces justified?)
    public interface IBusinessRuleWithIdentifierString
    {
        string IdentifierString { get; }
        delegate string GenerateIdentifierString<T>();
    }
}