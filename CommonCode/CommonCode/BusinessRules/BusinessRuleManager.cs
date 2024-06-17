using System;
using System.Collections.Generic;

namespace CommonCode.BusinessRules
{
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
        public virtual void CheckIsDuplicateGenericly<T>(T targetOfCheck, BusinessRule<TInput, TOutput>.GenerateIdentifierString<IBusinessRuleWithIdentifierString> receivedGetIdentifierStringLogic)
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
}
