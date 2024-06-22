using CommonCode.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberAnalysis
{
    internal class StrategyDoesTargetSubstringEqualPattern : IBusinessRuleEvaluationStrategy<(string target, int targetSubstringStart, int targetSubstringLength, string pattern), bool>
    {
        // [Delegate Signatures]
        //public delegate bool ProduceEvaluatedResult(string target, string pattern);

        // [STATIC Backing Fields]
        // [INSTANCE Backing Fields]
        private string _pattern;
        private string _target;
        private (int targetSubstringStart, int targetSubstringLength) _targetSubstringData;

        // [STATIC Constructor member]
        static StrategyDoesTargetSubstringEqualPattern()
        {
            // [Instantiate backing fields]
            // [Instantiate (auto) properties]
        }
        // [INSTANCE Constructor members]
        public StrategyDoesTargetSubstringEqualPattern(string target, int targetSubstringStart, int targetSubstringLength, string pattern)
        {
            // [Instantiate backing fields]
            _target = target;
            _pattern = pattern;
            _targetSubstringData = (targetSubstringStart, targetSubstringLength);
            // [Instantiate (auto) properties]
        }

        // [STATIC Property members]
        // [INSTANCE Property members]
        public string Pattern { get { return _pattern; } protected set { _pattern = value; } }
        public string Target { get { return _target; } protected set { _target = value; } }
        public (int targetSubstringStart, int targetSubstringLength) TargetSubstringData { get { return _targetSubstringData; } protected set { _targetSubstringData = value; } }

        // [STATIC Method members]
        // [INSTANCE Method members]
        private bool CheckIfTargetSubstringEqualsPattern()
        {
            string substring = _target.Substring(TargetSubstringData.targetSubstringStart, TargetSubstringData.targetSubstringLength);
            return substring.Equals(_pattern);
        }

        // [STATIC Helper Method members]
        // [INSTANCE Helper Method members]

        // [STATIC Logger Method members]
        // [STATIC ErrorHandler Method members]

        // [Interface Members]
        public bool ExecuteStrategy()
        {
            return CheckIfTargetSubstringEqualsPattern();
        }
    }
}
