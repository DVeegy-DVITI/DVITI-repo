using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCode.BusinessRules
{
    public class StrategyDoesTargetStringContainPattern : IBusinessRuleEvaluationStrategy<(string target, string pattern), bool>
    {
        // [Delegate Signatures]
        public delegate bool ProduceEvaluatedResult(string target, string pattern);

        // [STATIC Backing Fields]
        // [INSTANCE Backing Fields]
        private string _pattern;
        private string _target;

        // [STATIC Constructor member]
        static StrategyDoesTargetStringContainPattern()
        {
            // [Instantiate backing fields]
            // [Instantiate (auto) properties]
        }
        // [INSTANCE Constructor members]
        public StrategyDoesTargetStringContainPattern(string target, string pattern)
        {
            // [Instantiate backing fields]
            _target = target;
            _pattern = pattern;
            // [Instantiate (auto) properties]
        }

        // [STATIC Property members]
        // [INSTANCE Property members]
        public string Pattern { get { return _pattern; } protected set { _pattern = value; } }
        public string Target { get { return _pattern; } protected set { _pattern = value; } }

        // [STATIC Method members]
        // [INSTANCE Method members]
        private bool CheckIfTargetContainsPattern()
        {
            return _pattern.Contains(_target);
        }

        // [STATIC Helper Method members]
        // [INSTANCE Helper Method members]

        // [STATIC Logger Method members]
        // [STATIC ErrorHandler Method members]

        // [Interface Members]
        public bool ExecuteStrategy((string target, string pattern) input)
        {
            return CheckIfTargetContainsPattern();
        }
        //public object EvaluatedResult { get { return (object)_delProduceEvaluatedResult("",""); } }
    }
}
