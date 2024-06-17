namespace CommonCode.BusinessRules
{
    /// <summary> Type guarantee for capacity to produce a business rule identifying string.</summary>
    /// TODO: Collection-intent id'ing and DIP rely on abstractions (confusing pair of interfaces justified?)
    public interface IBusinessRuleWithIdentifierString
    {
        string IdentifierString { get; }
        delegate string GenerateIdentifierString<T>();
    }
}
