using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Reflection;
using CommonCode.BusinessRules;
using PhoneNumberAnalysis;

public static class PhoneNumber
{
    const string PHONENUMBER_FORMAT = "NNN-NNN-NNNN";
    const string PHONENUMBER_ISNEWYORK_DIALCODEPREFIX = "212";
    private readonly static (int newYorkNumberStartPosition, int newYorkNumberLength) PHONENUMBER_ISNEWYORK_TARGETSUBSTRINGSTARTANDLENGTH = (0, 3);
    private readonly static (int fakeNumberStartPosition, int fakeNumberLength) PHONENUMBER_ISFAKE_TARGETSUBSTRINGSTARTANDLENGTH = (4, 3);
    private readonly static string PHONENUMBER_ISFAKE_TARGET_DIALCODECOMPONENT = "555";
    const int PHONENUMBER_GETLOCALNUMBER_AMOUNTOFLASTDIGITSFORLOCALNUMBER= 4;
    const string PHONENUMBER_ISFAKE_STRATEGY_IDENTIFIER = "Do positions 5 to 7 contain 555 for fake number";
    const string PHONENUMBER_NEWYORK_STRATEGY_IDENTIFIER = "Is Dialing Code New York 212";
    const string PHONENUMBER_GETLOCALNUMBER_STRATEGY_IDENTIFIER = "Get the local number, which are the last 4 digits";

    private readonly static BusinessRuleFactory BUSINESSRULE_FACTORY = BusinessRuleFactory.BusinessRuleFactoryInstance;

    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        // [Define Segment] Declare and Intialise members
        (bool IsNewYork, bool IsFake, string LocalNumber) output = default;

        output.IsNewYork = DefineBusinessRuleIsNewYork(phoneNumber).EvaluationStrategy.ExecuteStrategy();
        output.IsFake = DefineBusinessRuleIsFakeNumber(phoneNumber).EvaluationStrategy.ExecuteStrategy();
        output.LocalNumber = DefineBusinessRuleGetLocalNumber(phoneNumber).EvaluationStrategy.ExecuteStrategy();

        // [Process Segment] Employ defined members in processes

        // [Conclude Segment] Execute the method's intent
        return output;
    }
    public delegate bool BusinessRuleIsNewYorkSignature((string, string) input);
    private static BusinessRule<(string, int, int, string), bool> DefineBusinessRuleIsNewYork(string phoneNumber)
    {
        BusinessRule<(string,int, int, string), bool> businessRule = default;
        IBusinessRuleEvaluationStrategy<(string, int, int, string), bool> createdStrategy = new StrategyDoesTargetSubstringEqualPattern(
            phoneNumber,
            PHONENUMBER_ISNEWYORK_TARGETSUBSTRINGSTARTANDLENGTH.newYorkNumberStartPosition,
            PHONENUMBER_ISNEWYORK_TARGETSUBSTRINGSTARTANDLENGTH.newYorkNumberLength, 
            PHONENUMBER_ISNEWYORK_DIALCODEPREFIX
            );
        businessRule = BUSINESSRULE_FACTORY.CreateBusinessRule(PHONENUMBER_NEWYORK_STRATEGY_IDENTIFIER, createdStrategy);
        return businessRule;
    }
    private static BusinessRule<(string, int, int, string), bool> DefineBusinessRuleIsFakeNumber(string phoneNumber)
    {
        BusinessRule<(string, int ,int, string), bool> businessRule = default;
        IBusinessRuleEvaluationStrategy<(string, int, int, string), bool> strategy = new StrategyDoesTargetSubstringEqualPattern(
            phoneNumber,
            PHONENUMBER_ISFAKE_TARGETSUBSTRINGSTARTANDLENGTH.fakeNumberStartPosition,
            PHONENUMBER_ISFAKE_TARGETSUBSTRINGSTARTANDLENGTH.fakeNumberLength, 
            PHONENUMBER_ISFAKE_TARGET_DIALCODECOMPONENT
            );
        businessRule = BUSINESSRULE_FACTORY.CreateBusinessRule(PHONENUMBER_ISFAKE_STRATEGY_IDENTIFIER, strategy);
        //TODO: Move strategy implem to this project (specific ones belong in impl side vs .dll side)
        return businessRule;
    }
    private static BusinessRule<string, string> DefineBusinessRuleGetLocalNumber(string phoneNumber)
    {
        BusinessRule<string, string> businessRule = default;
        IBusinessRuleEvaluationStrategy<string, string> strategy = new StrategyGetLocalNumber(phoneNumber);
        businessRule = BUSINESSRULE_FACTORY.CreateBusinessRule(PHONENUMBER_GETLOCALNUMBER_STRATEGY_IDENTIFIER, strategy);
        //TODO: Move strategy implem to this project (specific ones belong in impl side vs .dll side)
        return businessRule;
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}


/*General notes:
 * Product-Factory-Manager concept: The creation and governance of a class (product) are separate (SoC) and thereby dependency-inversed (DIP)
    * Note: The Factory instantiates the Manager, of which the Manager makes sure this is done correctly.
 * Standalone methods encapsulate & insulate singular intentions (SRP & Pure functions).
 */

///// <summary> Singleton Factory responsible for creating Products and their Singleton Manager.</summary>
//public class BusinessRuleFactory
//{
//    // [STATIC Delegate Signatures]

//    // [STATIC Backing Fields]
//    /// <summary> Private backing field for the Singleton Factory instance.</summary>
//    private static BusinessRuleFactory _businessRuleFactoryInstance;
//    /// <summary> Private backing field for the Singleton Manager instance.</summary>
//    private static BusinessRuleManager _businessRuleManagerInstance;
//    // [INSTANCE Backing Fields]

//    // [STATIC Constructor member]
//    /// <summary> Static constructor encapsulating all static initializations.</summary>
//    static BusinessRuleFactory()
//    {
//        // [Instantiate backing fields]
//        _businessRuleManagerInstance = default;
//        _businessRuleManagerInstance = BusinessRuleManager.BusinessRuleManagerInstance;
//        // [Instantiate (auto) properties]
//    }
//    // [INSTANCE Constructor members]
//    /// <summary> Private constructor enforcing the Singleton pattern.</summary>
//    private BusinessRuleFactory() { }

//    // [STATIC Property members]
//    /// <summary> Exposes retrieval/creation of the Factory instance.</summary>
//    public static BusinessRuleFactory BusinessRuleFactoryInstance
//    {
//        get
//        {
//            if (_businessRuleFactoryInstance == null)
//            {
//                _businessRuleFactoryInstance = new BusinessRuleFactory();
//            }
//            return _businessRuleFactoryInstance;
//        }
//    }
//    // [INSTANCE Property members]

//    // [STATIC Method members]
//    // [INSTANCE Method members]
//    /// <summary> Exposes a Manufacture method with datachecks for Business Rules.</summary>
//    public BusinessRule CreateBusinessRule(string identifier, IBusinessRuleEvaluationStrategy evaluationStrategy/*, Func<dynamic, dynamic> evaluationLogic*/)
//    {
//        // [Define Segment] Declare and Intialise members
//        BusinessRule newBusinessRule = default;

//        // [Process Segment] Employ defined members in processes
//        try
//        {
//            newBusinessRule = new BusinessRule(identifier, evaluationStrategy/*, evaluationLogic*/);
//        }
//        catch (Exception)
//        {
//            throw new NotImplementedException("Something went wrong during a business rule constructor call");
//        }

//        try
//        {
//            ProcessDataChecksOnInput(newBusinessRule);
//        }
//        catch (Exception)
//        {
//            throw new NotImplementedException("Something went wrong during a business rule datachecks call");
//        }

//        // [Conclude Segment] Execute the method's intent
//        return newBusinessRule;
//    }

//    // [STATIC Helper Method members]
//    // [INSTANCE Helper Method members]
//    /// <summary> Abstracts the Orchestration of [Input Data Checks] of Business Rule manufacturing. Override for substypes.</summary>
//    protected virtual void ProcessDataChecksOnInput(BusinessRule newBusinessRule)
//    {
//        // [Conclude Segment] Execute the method's intent
//        PerformIsDuplicateInRepositoryCheck(newBusinessRule);
//    }
//    /// <summary> Abstracts the [Duplicate Check] of [Input Data Checks] of Business Rule manufacturing. Override for substypes.</summary>
//    protected virtual void PerformIsDuplicateInRepositoryCheck(BusinessRule newBusinessRule)
//    {
//        // [Define Segment] Declare and Intialise members
//        /// <summary> Local member defining the process of aqcuiring the Identifier string.</summary>
//        BusinessRuleBase.GenerateIdentifierString<IBusinessRuleWithIdentifierString> providedGetIdentifierStringLogic = (businessRule) => businessRule.IdentifierString;

//        // [Conclude Segment] Execute the method's intent
//        _businessRuleManagerInstance.CheckIsDuplicateGenericly(newBusinessRule, providedGetIdentifierStringLogic);
//    }

//    // [STATIC Logger Method members]
//    // [STATIC ErrorHandler Method members]
//}

///// <summary> Singleton Manager responsible for collectively managing Factory-created Products.</summary>
//public class BusinessRuleManager
//{
//    // [STATIC Delegate Signatures]

//    // [STATIC Backing Fields]
//    /// <summary> Private backing field for the Singleton Manager instance.</summary>
//    private static BusinessRuleManager _businessRuleManagerInstance;
//    private static HashSet<IBusinessRuleWithIdentifierString> _businessRules;
//    // [INSTANCE Backing Fields]

//    // [STATIC Constructor member]
//    /// <summary> Static constructor encapsulating all static initializations.</summary>
//    static BusinessRuleManager()
//    {
//        // [Instantiate backing fields]
//        _businessRuleManagerInstance = default;
//        _businessRules = new HashSet<IBusinessRuleWithIdentifierString>();
//        // [Instantiate (auto) properties]
//    }
//    // [INSTANCE Constructor members]
//    /// <summary> Private constructor enforcing the Singleton pattern.</summary>
//    private BusinessRuleManager()
//    {
//        /// TODO: There's no code restriction codeifying the 1:1 relation between Manager and Factory. (anyone could instantiate a Manager; No solution found.)
//    }

//    // [STATIC Property members]
//    /// <summary> Exposes the uniques-only set of all instances.</summary>
//    /// TODO: Mount a repository pattern here
//    public static HashSet<IBusinessRuleWithIdentifierString> BusinessRules { get { return _businessRules; } }
//    /// <summary> Exposes retrieval/creation of the Factory instance.</summary>
//    public static BusinessRuleManager BusinessRuleManagerInstance
//    {
//        get
//        {
//            if (_businessRuleManagerInstance == null)
//            {
//                _businessRuleManagerInstance = new BusinessRuleManager();
//            }
//            return _businessRuleManagerInstance;
//        }
//    }
//    // [INSTANCE Property members]

//    // [STATIC Method members]
//    // [INSTANCE Method members]
//    /// <summary> Checks if a generic business rule is a duplicate in the all-instances-set and throws an error if so.</summary>
//    public virtual void CheckIsDuplicateGenericly<T>(T targetOfCheck, BusinessRule.GenerateIdentifierString<IBusinessRuleWithIdentifierString> receivedGetIdentifierStringLogic)
//    where T : IBusinessRuleWithIdentifierString
//    {
//        bool wasItemAdded = BusinessRules.Add(targetOfCheck);
//        if (!wasItemAdded)
//        {
//            string identifierString = receivedGetIdentifierStringLogic(targetOfCheck);
//            throw new InvalidOperationException($"The creation of a duplicate element is prohibited. Identifier:\n'{identifierString}'.");
//        }
//    }

//    // [STATIC Helper Method members]
//    // [INSTANCE Helper Method members]

//    // [STATIC Logger Method members]
//    // [STATIC ErrorHandler Method members]
//}

///// <summary> Enables polymorphism across types equipped to produce an identifier string.</summary>
///// TODO: Collection-intent id'ing and DIP rely on abstractions (confusing pair of interfaces justified?)
//public interface IBusinessRuleWithIdentifierString
//{
//    public string IdentifierString { get; }
//    public delegate string GenerateIdentifierString<T>();
//}
//public interface IBusinessRule : IBusinessRuleWithIdentifierString
//{
//    public IBusinessRuleEvaluationStrategy EvaluationStrategy { get; }
//}

///// <summary> Enables polymorphism and Centralizes common interface implentation.</summary>
//public abstract class BusinessRuleBase : IBusinessRule, IBusinessRuleWithIdentifierString
//{
//    // [INSTANCE Backing Fields]
//    // Note: Allows anyone to define an acceptable process for the implied purpose
//    public delegate string GenerateIdentifierString<T>(T item);

//    // [STATIC Property members]
//    // [INSTANCE Property members]
//    virtual public string IdentifierString { get; protected set; }
//    virtual public IBusinessRuleEvaluationStrategy EvaluationStrategy { get; protected set; }

//    // [STATIC Method members]
//    // [INSTANCE Method members]
//}

///// <summary> Entity for condition(s) related to business processes.</summary>
//// TODO: Edit summaries in order to convey the strategy pattern intergration
//public class BusinessRule : BusinessRuleBase
//{
//    // [INSTANCE Backing Fields]
//    private IBusinessRuleEvaluationStrategy _evaluationStrategy;
//    // [STATIC Backing Fields]
//    /// <summary> Private backing field for the Singleton Manager instance.</summary>
//    private static BusinessRuleManager _businessRuleManagerInstance;
//    // [INSTANCE Backing Fields]

//    // [STATIC Constructor member]
//    /// <summary> Static constructor encapsulating all static initializations.</summary>
//    static BusinessRule()
//    {
//        // [Instantiate backing fields]
//        _businessRuleManagerInstance = BusinessRuleManager.BusinessRuleManagerInstance;
//        // [Instantiate (auto) properties]
//    }
//    // [INSTANCE Constructor members]
//    /// <summary> Argumented constructor requiring rule identification sentence and conditional logic.</summary>
//    /// TODO: The implied Func argument should be dynamic, but maybe all br-signatures share common aspects (restrict?)
//    public BusinessRule(string identifierString, IBusinessRuleEvaluationStrategy evaluationStrategy)
//    {
//        IdentifierString = identifierString;
//        EvaluationStrategy = evaluationStrategy;
//    }

//    // [STATIC Property members]
//    // [INSTANCE Property members]
//    /// <summary> Exposes the identifier sentence for this business rule. Inherit for subtypes.</summary>
//    public override string IdentifierString { get; protected set; }
//    public override IBusinessRuleEvaluationStrategy EvaluationStrategy { get; protected set; }

//    // [STATIC Helper Method members]
//    // [INSTANCE Helper Method members]

//    // [STATIC Logger Method members]
//    // [STATIC ErrorHandler Method members]
//}

//public interface IBusinessRuleEvaluationStrategy
//{
//    public object EvaluatedResult { get; }
//}

//public class IsNewYorkPhoneNumberBusinessRuleStrategy : IBusinessRuleEvaluationStrategy
//{
//    private string _firstThreeCharacters;
//    public string FirstThreeCharacters
//    {
//        get { return _firstThreeCharacters; }
//        private set { _firstThreeCharacters = value; }
//    }

//    private string _phoneNumber;
//    public string PhoneNumber
//    {
//        get { return _phoneNumber; }
//        private set { _phoneNumber = value; }
//    }

//    private const string _newYorkDialingCode = "212";
//    public string NewYorkDialingCode
//    {
//        get { return _newYorkDialingCode; }
//    }

//    public IsNewYorkPhoneNumberBusinessRuleStrategy(string phoneNumber)
//    {
//        PhoneNumber = phoneNumber;
//    }

//    public object EvaluatedResult
//    {
//        get { return ProcessCompareSubStringResultToNewYorkCode(); }
//    }

//    private bool ProcessCompareSubStringResultToNewYorkCode()
//    {
//        int substringStart = 0;
//        int substringLength = 3;
//        string substringSource = PhoneNumber;
//        string compareTarget = _newYorkDialingCode;

//        // [Define Segment] Declare and Intialise members
//        string SubProcessExtractSubstring(int substringStart, int substringLength, string substringSource)
//        {
//            // [Define Segment] Declare and Intialise members
//            string output = default;

//            // [Process Segment] Employ defined members in processes
//            output = substringSource.Substring(substringStart, substringLength);

//            // [Conclude Segment] Execute the method's intent
//            return output;
//        }
//        string subStringResult = default;
//        bool output = default;

//        // [Process Segment] Employ defined members in processes
//        subStringResult = SubProcessExtractSubstring(substringStart, substringLength, substringSource);
//        output = (subStringResult.Equals(compareTarget));

//        // [Conclude Segment] Execute the method's intent
//        return output;
//    }
//}




/*
 * Design considerations:
    * Pure functions -> Solely returns a value, no side effects or scope breaches
    * Insulate code -> Any member's scope should be limited to their needs solely
    * Mark-up intent -> There's orchestration, defining, process, conclude etc.
    * Data Grouping -> They exist, flow and process the same? -> group together!
    * Reusability -> Something useable for subtypes? Enable overriding.
    * Testing -> Every standalone function with prefix "process" -> test.
    * SOLID
        * Single Responsibility Principle: Every module should have only one reason to change.
        * Open/closed Principle: A software module is open for extension and closed for modification
        * Liskov Substitution Principle: A derived module must be substitutable by its base one
        * Interface Segregation Principle: Clients should not be forced to implement what they don't need.
        * Dependency Inversion Principle: High-lvl shouldn't depend on low-lvl, and both on abstractions.
        * DRY, DIE and KISS. Dont repeat yourself, Duplication is evil and Keep it simple stupid.
        * Code verbosity: The best code can speak for itself using variable names, structure and flow.
        * DI: Any dependency that isn't a constant, should be placed where it could be injected.
 */

/*
// [Define Segment] Declare and Intialise members
// [Process Segment] Employ defined members in processes
// [Conclude Segment] Execute the method's intent

// [Define Segment] Declare and Intialise members
// [Action Segment] Employ defined members in actions
 */

/*
// [INSTANCE Backing Fields]

// [STATIC Backing Fields]
// [INSTANCE Backing Fields]
    
// [STATIC Constructor member]
    // [Instantiate backing fields]
    // [Instantiate (auto) properties]
// [INSTANCE Constructor members]
    
// [STATIC Property members]
// [INSTANCE Property members]
    
// [STATIC Method members]
// [INSTANCE Method members]
    
// [STATIC Helper Method members]
// [INSTANCE Helper Method members]

// [STATIC Logger Method members]
// [STATIC ErrorHandler Method members]
 */