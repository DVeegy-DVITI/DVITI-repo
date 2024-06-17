
namespace CommonCode.PersonalCodingStandards
{
    internal class DesignConsiderations
    {
        /*
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
    }

    internal class MethodLevelFlow
    {
        // [Define Segment] Declare and Intialise members
        // [Process Segment] Employ defined members in processes
        // [Conclude Segment] Execute the method's intent

        // [Define Segment] Declare and Intialise members
        // [Action Segment] Employ defined members in actions

        /*
         * Why use backing fields and not use properties in constructors?
         * Answer: Automatic properties hide initialization logic that is exclusively delegated to therefore-intended constructors.

        * Why have a static and instance constructor?
        * Answer: Any architecture is more robust if all initialization logic belongs to respectively a static and instance constructor.
        */
    }

    internal class ClassLevelFlow
    {
        // [Delegate Signatures]

        // [STATIC Backing Fields]
        // [INSTANCE Backing Fields]

        /*
        // [STATIC Constructor member]
            // [Instantiate backing fields]
            // [Instantiate (auto) properties]
        */
        /*
        // [INSTANCE Constructor members]
            // [Instantiate backing fields]
            // [Instantiate (auto) properties]
        */

        // [STATIC Property members]
        // [INSTANCE Property members]

        // [STATIC Method members]
        // [INSTANCE Method members]

        // [STATIC Helper Method members]
        // [INSTANCE Helper Method members]

        // [STATIC Logger Method members]
        // [STATIC ErrorHandler Method members]

        // [Interface Members]
    }
}