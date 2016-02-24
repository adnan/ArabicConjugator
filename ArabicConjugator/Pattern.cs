using ArabicConjugator.Enums;

namespace ArabicConjugator
{
    public class Pattern
    {
        public string Person { get; set; }
        public string Gender { get; set; }
        public Plurality Plurality { get; set; }
        public string English { get; set; }
        public string Arabic { get; set; }
        public string Verb { get; set; }
        public int Number { get; set; }
    }
}
