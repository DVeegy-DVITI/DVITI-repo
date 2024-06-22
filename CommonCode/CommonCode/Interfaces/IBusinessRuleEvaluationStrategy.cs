namespace CommonCode.Interfaces
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
    /// TODO: Re-implement this interface: I need bot input and output to be decoupled from the execute method. (SRP: only concerned with concluding, not typings)
    /// TODO: Re-implement this interface: Ideally (research): I need this interface to enforce both I/O types to be used in a standardized manner.
    #endregion

    /// <summary> Interface-intent: Business-rule-members that enable strategy-pattern implementations with a generic signature.</summary>
    public interface IBusinessRuleEvaluationStrategy<EvaluationInputType, EvaluationOutputType>
    {
        /*Old signature*/ /*EvaluationOutputType ExecuteStrategy();*/
        /*New signature*/ void ExecuteStrategy();
    }
}
