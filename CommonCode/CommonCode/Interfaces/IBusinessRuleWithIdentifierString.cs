namespace CommonCode.Interfaces
{

    #region TODO's
    /// TODO: Collection-intent id'ing and DIP rely on abstractions (confusing pair of interfaces justified?)
    #endregion

    /// <summary> Interface-intent: Business-rule-members that enable intent identification/verbosity by delegate-generation, then property-exposition.</summary>
    public interface IBusinessRuleWithIdentifierString
    {
        string IdentifierString { get; }
        delegate string GenerateIdentifierString<T>();
    }
}
