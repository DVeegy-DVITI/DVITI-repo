using System;

namespace CommonCode.BusinessRules
{
    /*General notes:
 * Product-Factory-Manager concept: The creation and governance of a class (product) are separate (SoC) and thereby dependency-inversed (DIP)
    * Note: The Factory instantiates the Manager, of which the Manager makes sure this is done correctly.
 * Standalone methods encapsulate & insulate singular intentions (SRP & Pure functions).
 */

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
        public BusinessRule CreateBusinessRule(string identifier, IBusinessRuleEvaluationStrategy evaluationStrategy/*, Func<dynamic, dynamic> evaluationLogic*/)
        {
            // [Define Segment] Declare and Intialise members
            BusinessRule newBusinessRule = default;

            // [Process Segment] Employ defined members in processes
            try
            {
                newBusinessRule = new BusinessRule(identifier, evaluationStrategy/*, evaluationLogic*/);
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
        protected virtual void ProcessDataChecksOnInput(BusinessRule newBusinessRule)
        {
            // [Conclude Segment] Execute the method's intent
            PerformIsDuplicateInRepositoryCheck(newBusinessRule);
        }
        /// <summary> Abstracts the [Duplicate Check] of [Input Data Checks] of Business Rule manufacturing. Override for substypes.</summary>
        protected virtual void PerformIsDuplicateInRepositoryCheck(BusinessRule newBusinessRule)
        {
            // [Define Segment] Declare and Intialise members
            /// <summary> Local member defining the process of aqcuiring the Identifier string.</summary>
            BusinessRuleBase.GenerateIdentifierString<IBusinessRuleWithIdentifierString> providedGetIdentifierStringLogic = (businessRule) => businessRule.IdentifierString;

            // [Conclude Segment] Execute the method's intent
            _businessRuleManagerInstance.CheckIsDuplicateGenericly(newBusinessRule, providedGetIdentifierStringLogic);
        }

        // [STATIC Logger Method members]
        // [STATIC ErrorHandler Method members]
    }
}
