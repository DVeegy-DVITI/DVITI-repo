using CommonCode.BusinessRules;
using CommonCode.Interfaces;
using System;
using System.Collections.Generic;

namespace CommonCode.Utility
{
    /// <summary> [Public] class for [business rule manager] as [utility] entity; this encapsulates [The post-creation management of a product, in this case a business rule].</summary>
    public class BusinessRuleManager
    {
        /// Explore the Documentation folder for: todo's, rules, concepts, notes and standards.

        #region Backing field members
        /// <structure-section> Centralization of all foundational data-encapsulating declarations; a sole address for any data-related development.</structure-section>
        // [STATIC BACKING FIELD MEMBERS]
        /// <summary> [Private] static backing field for [business rule manager] internal state; Enabling [this] to [read the manager instance].</summary>
        private static BusinessRuleManager _businessRuleManagerInstance;

        /// <summary> [private] static backing field for [business rule exhaustive collection] internal state; Enabling [this] to [read the collection instance].</summary>
        private static HashSet<IBusinessRuleWithIdentifierString> _businessRules;

        // [INSTANCE BACKING FIELD MEMBERS]
        /// <summary> [_private_public_protected_] instance backing field for [_member_good_title_] internal state; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>

        #endregion

        #region Constructors
        #region Static-data constructor member
        /// <structure-section> Encapsulation of all foundational static member initializations via this default static constructor.</structure-section>
        // [STATIC CONSTRUCTOR MEMBER]
        /// <summary> default static constructor handling all static member initializations.</summary>
        static BusinessRuleManager()
        {
            // [Initialize backing fields: only initialization, no declaration or processing!]
            _businessRuleManagerInstance = default;
            _businessRules = new HashSet<IBusinessRuleWithIdentifierString>();
        }

        #endregion

        #region Instance-data constructor members
        /// <structure-section> Encapsulation of all core instance member initializations via this argumented instance constructor.</structure-section>
        // [INSTANCE CONSTRUCTOR MEMBERS]
        /// <summary> argumented instance constructor handling (collectively) all instance member initializations.</summary>
        private BusinessRuleManager()
        {
            // [Initialize backing fields: only initialization, no declaration or processing!]
        }

        #endregion
        #endregion

        #region General property members
        /// <structure-section> Centralization of all core general data-exposing properties; a sole address for any related development.</structure-section>
        // [STATIC GENERAL PROPERTY MEMBERS]
        /// <summary> [Public] static property for [business rule manager] exposed state; Enabling [others] to [read the manager instance].</summary>
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

        /// <summary> [Public] static property for [business rule exhaustive collection] exposed state; Enabling [others] to [read the collection instance].</summary>
        /// <summary> Exposes the uniques-only set of all instances.</summary>
        public static HashSet<IBusinessRuleWithIdentifierString> BusinessRules { get { return _businessRules; } }

        // [INSTANCE GENERAL PROPERTY MEMBERS]
        /// <summary> [_private_public_protected_] instance property for [_member_good_title_] exposed state; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        #endregion

        #region Implementing business logic
        #region Business Logic members
        /// <structure-section> Centralization of all core business-logic-encapsulating member; a sole address for any related development.</structure-section>
        // [STATIC MAIN BUSINESS-LOGIC MEMBERS]
        /// <summary> [_private_public_protected_] static member for [_member_good_title_] feature; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        // [INSTANCE MAIN BUSINESS-LOGIC MEMBERS]
        /// <summary> [Public] instance member for [Checking collection-entry Uniqueness] feature; Enabling [others] to [provide a target, upon which uniqueness to the exhaustive collection is checked].</summary>
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

        #endregion

        #region Utility members
        /// <structure-section> Centralization of all core utility-therefore-business-logic-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC UTILITY MEMBERS]
        /// <summary> [_private_public_protected_] static utility member for [_member_good_title_] utility feature; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        // [INSTANCE UTILITY MEMBERS]
        /// <summary> [_private_public_protected_] instance utility member for [_member_good_title_] utility feature; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        #endregion

        #region Delegate members
        /// <code-structure-section> Centralization of all foundational logic-delegating signatures; a sole address for any delegate-related development.</structure-section>
        // [ DELEGATE MEMBERS]
        /// <summary> [_private_public_protected_] delegate for [_member_good_title_] delegate; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        #endregion
        #endregion

        #region Practical nice to have functionality
        #region Exception Handling members
        /// <structure-section> Centralization of all core exception-handling-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC EXCEPTION-HANDLING MEMBERS]
        /// <summary> [_private_public_protected_] static exception-handling member for [_member_good_title_] exception logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        // [INSTANCE EXCEPTION-HANDLING MEMBERS]
        /// <summary> [_private_public_protected_] instance exception-handling member for [_member_good_title_] exception logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        #endregion

        #region Business rule and Validation members
        /// <structure-section> Centralization of all core business-rule/validation-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC BUSINESS-RULE/VALIDATION MEMBERS]
        /// <summary> [_private_public_protected_] static business-rule/validation member for [_member_good_title_] validation logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        // [INSTANCE BUSINESS-RULE/VALIDATION MEMBERS]
        /// <summary> [_private_public_protected_] instance business-rule/validation member for [_member_good_title_] validation logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        #endregion
        #endregion

        #region Technical nice to have functionality
        #region Logging members
        /// <structure-section> Centralization of all core logging-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC LOGGING MEMBERS]
        /// <summary> [_private_public_protected_] static logging member for [_member_good_title_] logging logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        // [INSTANCE LOGGING MEMBERS]
        /// <summary> [_private_public_protected_] instance logging member for [_member_good_title_] logging logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        #endregion
        #endregion

        #region Probably not in scope
        #region Presentation Layer members
        /// <structure-section> Centralization of all core presentation-layer-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC PRESENTATION LAYER: MVC-CONTROLLER/MVVM-VIEWMODEL MEMBERS]
        /// <summary> [_private_public_protected_] static presentation-layer member for [_member_good_title_] presentation logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        // [INSTANCE PRESENTATION LAYER: MVC-CONTROLLER/MVVM-VIEWMODEL MEMBERS]
        /// <summary> [_private_public_protected_] instance presentation-layer member for [_member_good_title_] presentation logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        #endregion

        #region Data Access Layer members
        /// <structure-section> Centralization of all core data-access-layer-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC DATA ACCESS LAYER: PERSISTENCE/REPOSITORY/DATACONTEXT/ENTITY MEMBERS]
        /// <summary> [_private_public_protected_] static data-access-layer member for [_member_good_title_] data-access logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        // [INSTANCE DATA ACCESS LAYER: PERSISTENCE/REPOSITORY/DATACONTEXT/ENTITY MEMBERS]
        /// <summary> [_private_public_protected_] instance data-access-layer member for [_member_good_title_] data-access logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        #endregion
        #endregion

        #region Most definately not in scope
        #region Security members
        /// <structure-section> Centralization of all core security-layer-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC SECURITY MEMBERS]
        /// <summary> [_private_public_protected_] static security-layer member for [_member_good_title_] security logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        // [INSTANCE SECURITY MEMBERS]
        /// <summary> [_private_public_protected_] instance security-layer member for [_member_good_title_] security logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        #endregion

        #region Configuration management members
        /// <structure-section> Centralization of all core configuration-management-layer-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC CONFIGURATION-MANAGEMENT MEMBERS]
        /// <summary> [_private_public_protected_] static configuration-management-layer member for [_member_good_title_] configuration-management logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        // [INSTANCE CONFIGURATION-MANAGEMENT MEMBERS]
        /// <summary> [_private_public_protected_] instance configuration-management-layer member for [_member_good_title_] configuration-management logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        #endregion

        #region Extension-method members
        /// <structure-section> Centralization of all core extension-method-encapsulating members; a sole address for any related development.</structure-section>
        // [STATIC EXTENSION MEMBERS]
        /// <summary> [_private_public_protected_] static extension-method member for [_member_good_title_] extension-method logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        // [INSTANCE EXTENSION MEMBERS]
        /// <summary> [_private_public_protected_] instance extension-method member for [_member_good_title_] extension-method logic; Enabling [_others_anyone_inheritors_this] to [_CRUD_ _member_intent_].</summary>


        #endregion
        #endregion
    }
}