using CommonCode.Interfaces;

namespace CommonCode.BusinessRules
{
    /// <summary> Enables polymorphism and Mounting point for shared ISP interfaces.</summary>
    public abstract class BusinessRuleBase<EvaluationInputType, EvaluationOutputType> : IBusinessRule<EvaluationInputType, EvaluationOutputType>
    {
        #region Personal notes
        #region Intent
        /// Intent: This sectional structure of the implied logical flow assures SRP-governed coverage of the entire paradigm of C# application development.
        #endregion
        #region Notes
        /// Note: How to collapse all of these regions properly:
        /// * Go to Tools > Options > Text Editor > C# > Advanced > Outlining and check "Collapse #regions when collapsing to definitions".
        /// * Perform "collapsing to definitions" by pressing [CTRL + M] and [CTRL + O] to collapse, replace [O] by [P] to expand.

        /// Note: This sectional structure assures that any developer is able to match a specific coding task to any reasonable area of this class.
        /// Note: This sectional structure also assures that any developer is able to implement any coding task in accordance to a guiding, and verbose structure.
        /// Note: This sectional structure finally assures me that all existing, and future, development is compliant with my holistic SRP-central coding creed.
        #endregion

        #region Rules
        /// Rule: Check the PersonalCodingStandards file whenever possible.
        /// Reason: There is no back-propagation from the original file to all copy-paste's in all classes.
        /// 
        /// Rule: Use explicit interface implementation syntax.
        /// Reason: Explicit interface implementations cannot be inherited (prevents dependencies), and clearly differ from non-interface members.
        /// 
        /// Rule: Avoid using automatic properties.
        /// Reason: They hide initialization logic that belongs to constructors, and has to be rewritten whenever logic alteration is necessary.
        /// 
        /// Rule: Delegate any static and instance variable initialization to the respective constructors.
        /// Reason: Any architecture is more robust if one scope handles one responsibility; especially because that's a constructor's literal job.
        #endregion
        #endregion
        #region TODO's
        /// TODO: Decide on a line between governance of general properties (or other members) and responsibility-specific members (f.e. MVC members).
        #endregion

        #region Backing field members
        /// <structure-section> Centralization of all foundational data-encapsulating declarations; a sole address for any data-related development.</structure-section>
        // [STATIC BACKING FIELD MEMBERS]

        // [INSTANCE BACKING FIELD MEMBERS]
        #endregion

        #region Default static constructor member
        /// <structure-section> Encapsulation of all foundational static member initializations via this default static constructor.</structure-section>

        // [STATIC CONSTRUCTOR MEMBER]
        // [Instantiate backing fields]

        // [Instantiate (auto) properties]
        #endregion

        #region Argumented instance constructor members
        /// <structure-section> Encapsulation of all core instance member initializations via this argumented instance constructor.</structure-section>
        // [INSTANCE CONSTRUCTOR MEMBERS]
        // [Instantiate backing fields]

        // [Instantiate (auto) properties]
        #endregion

        #region General property members
        /// <structure-section> Centralization of all core general data-exposing properties; a sole address for any related development.</structure-section>
        // [STATIC GENERAL PROPERTY MEMBERS]

        // [INSTANCE GENERAL PROPERTY MEMBERS]
        /// <summary> Exposes the IdentifierString property of this class. Override for inheritors who'd alter the processing logic.</summary>
        string IBusinessRuleWithIdentifierString.IdentifierString { get; }
        /// <summary> Exposes the strategy-pattern-instance property of this class. Override for inheritors who'd alter the processing logic.</summary>
        IBusinessRuleEvaluationStrategy<EvaluationInputType, EvaluationOutputType> IBusinessRule<EvaluationInputType, EvaluationOutputType>.EvaluationStrategy { get; }

        #endregion

        #region Implementing business logic
        #region Business Logic members
        /// <structure-section> Centralization of all core business-logic-encapsulating methods; a sole address for any related development.</structure-section>
        // [STATIC MAIN BUSINESS-LOGIC MEMBERS]

        // [INSTANCE MAIN BUSINESS-LOGIC MEMBERS]
        #endregion

        #region Utility members
        /// <structure-section> Centralization of all core utility-therefore-business-logic-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC UTILITY MEMBERS]

        // [INSTANCE UTILITY MEMBERS]
        #endregion

        #region Delegate members
        /// <code-structure-section> Centralization of all foundational logic-delegating signatures; a sole address for any delegate-related development.</structure-section>
        // [ DELEGATE MEMBERS]
        /// <summary> Encapsulates any signature for generating an identifier-string under a sole name.</summary>
        public delegate string GenerateIdentifierString<IdStringGenerationInputType>(IdStringGenerationInputType item);
        #endregion
        #endregion

        #region Practical nice to have functionality
        #region Exception Handling members
        /// <structure-section> Centralization of all core exception-handling-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC EXCEPTION-HANDLING MEMBERS]

        // [INSTANCE EXCEPTION-HANDLING MEMBERS]
        #endregion

        #region Business rule and Validation members
        /// <structure-section> Centralization of all core business-rule/validation-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC BUSINESS-RULE/VALIDATION MEMBERS]

        // [INSTANCE BUSINESS-RULE/VALIDATION MEMBERS]
        #endregion
        #endregion

        #region Technical nice to have functionality
        #region Logging members
        /// <structure-section> Centralization of all core logging-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC LOGGING MEMBERS]

        // [INSTANCE LOGGING MEMBERS]
        #endregion
        #endregion

        #region Probably not in scope
        #region Presentation Layer members
        /// <structure-section> Centralization of all core presentation-layer-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC PRESENTATION LAYER: MVC-CONTROLLER/MVVM-VIEWMODEL MEMBERS]

        // [INSTANCE PRESENTATION LAYER: MVC-CONTROLLER/MVVM-VIEWMODEL MEMBERS]
        #endregion

        #region Data Access Layer members
        /// <structure-section> Centralization of all core data-access-layer-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC DATA ACCESS LAYER: PERSISTENCE/REPOSITORY/DATACONTEXT/ENTITY MEMBERS]

        // [INSTANCE DATA ACCESS LAYER: PERSISTENCE/REPOSITORY/DATACONTEXT/ENTITY MEMBERS]
        #endregion
        #endregion

        #region Most definately not in scope
        #region Security members
        /// <structure-section> Centralization of all core security-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC SECURITY MEMBERS]

        // [INSTANCE SECURITY MEMBERS]
        #endregion

        #region Configuration management members
        /// <structure-section> Centralization of all core configuration-management-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC CONFIGURATION-MANAGEMENT MEMBERS]

        // [INSTANCE CONFIGURATION-MANAGEMENT MEMBERS]
        #endregion

        #region Extension-method members
        /// <structure-section> Centralization of all core extension-method-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC EXTENSION MEMBERS]

        // [INSTANCE EXTENSION MEMBERS]
        #endregion
        #endregion
    }
}