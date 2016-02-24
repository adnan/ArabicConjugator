using ArabicConjugator.Enums;
using System.Collections.Generic;

namespace ArabicConjugator
{
    public class Conjugator
    {
        private const string FATHA = "\u064E";
        private const string DHAMMA = "\u064F";
        private const string KASRA = "\u0650";
        private const string SAKTA = "\u0652";
        private const string SHADDA = "\u0651";

        private string _root1;
        private string _root2;
        private string _root3;
        private string _tense;
        private string _type;
        private string _form;
        private string _base;
        private string _opts;
        private string _pronoun;

        public Conjugator()
        {

        }

        public List<Pattern> Conjugate(string root1, string root2, string root3, string tense, string type, string verbType)
        {
            List<Pattern> patterns = null;

            string harakat3 = string.Empty;

            switch (verbType)
            {
                case "I":
                    harakat3 = "";
                    break;
                case "II":
                    harakat3 = SHADDA;
                    break;
                case "III":
                    harakat3 = "ا";
                    break;
                default:
                    break;
            }

            if (tense == "Perfect")
            {
                if (type == "Active")
                {
                    patterns = Perfect(root1, root2, root3, FATHA, FATHA, harakat3);
                }

                if (type == "Passive")
                {
                    patterns = Perfect(root1, root2, root3, DHAMMA, KASRA, harakat3);
                }
            }

            if (tense == "Imperfect")
            {
                if (type == "Active")
                {
                    patterns = Imperfect(root1, root2, root3, FATHA, harakat3);
                }

                if (type == "Passive")
                {
                    patterns = Imperfect(root1, root2, root3, DHAMMA, harakat3);
                }
            }

            return patterns;
        }

        private List<Pattern> Perfect(string root1, string root2, string root3, string harakat1, string harakat2, string harakat3)
        {
            List<Pattern> patterns = new List<Pattern>();

            string he = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + FATHA;
            string they2m = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + FATHA + "ا";
            string they3m = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + DHAMMA + "وا";
            string she = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + FATHA + "ت" + SAKTA;
            string they2f = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + FATHA + "ت" + FATHA + "ا";
            string they3f = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + SAKTA + "ن" + FATHA;
            string you1m = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + SAKTA + "ت" + FATHA;
            string you2m = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + SAKTA + "ت" + DHAMMA + "م" + FATHA + "ا";
            string you3m = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + SAKTA + "ت" + DHAMMA + "م" + SAKTA;
            string you1f = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + SAKTA + "ت" + KASRA;
            string you2f = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + SAKTA + "ت" + DHAMMA + "م" + FATHA + "ا";
            string you3f = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + SAKTA + "ت" + DHAMMA + "ن" + SHADDA + FATHA;
            string i = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + SAKTA + "ت" + DHAMMA;
            string we = root1 + harakat1 + root2 + harakat2 + harakat3 + root3 + SAKTA + "ن" + FATHA + "ا";

            patterns.Add(new Pattern { Number = 1, Person = "3rd", Gender = "M", Plurality = Plurality.Singular, Arabic = "هو", English = "He", Verb = he });
            patterns.Add(new Pattern { Number = 2, Person = "3rd", Gender = "M", Plurality = Plurality.Dual, Arabic = "هما", English = "They (2M)", Verb = they2m });
            patterns.Add(new Pattern { Number = 3, Person = "3rd", Gender = "M", Plurality = Plurality.Plural, Arabic = "هم", English = "They (3+M)", Verb = they3m });
            patterns.Add(new Pattern { Number = 4, Person = "3rd", Gender = "F", Plurality = Plurality.Singular, Arabic = "هي", English = "She", Verb = she });
            patterns.Add(new Pattern { Number = 5, Person = "3rd", Gender = "F", Plurality = Plurality.Dual, Arabic = "هما", English = "They (2F)", Verb = they2f });
            patterns.Add(new Pattern { Number = 6, Person = "3rd", Gender = "F", Plurality = Plurality.Plural, Arabic = "هنّ", English = "They (3+F)", Verb = they3f });
            patterns.Add(new Pattern { Number = 7, Person = "2nd", Gender = "M", Plurality = Plurality.Singular, Arabic = "أنت", English = "You (1M)", Verb = you1m });
            patterns.Add(new Pattern { Number = 8, Person = "2nd", Gender = "M", Plurality = Plurality.Dual, Arabic = "أنتما", English = "You (2M)", Verb = you2m });
            patterns.Add(new Pattern { Number = 9, Person = "2nd", Gender = "M", Plurality = Plurality.Plural, Arabic = "أنتم", English = "You (3+M)", Verb = you3m });
            patterns.Add(new Pattern { Number = 10, Person = "2nd", Gender = "F", Plurality = Plurality.Singular, Arabic = "أنت", English = "You (1F)", Verb = you1f });
            patterns.Add(new Pattern { Number = 11, Person = "2nd", Gender = "F", Plurality = Plurality.Dual, Arabic = "أنتما", English = "You (2F)", Verb = you2f });
            patterns.Add(new Pattern { Number = 12, Person = "2nd", Gender = "F", Plurality = Plurality.Plural, Arabic = "أنتنّ", English = "You (3+F)", Verb = you3f });
            patterns.Add(new Pattern { Number = 13, Person = "1st", Gender = "M/F", Plurality = Plurality.Singular, Arabic = "أنا", English = "I", Verb = i });
            patterns.Add(new Pattern { Number = 14, Person = "1st", Gender = "M/F", Plurality = Plurality.Plural, Arabic = "نحن", English = "We", Verb = we });

            return patterns;
        }

        private List<Pattern> Imperfect(string root1, string root2, string root3, string harakat1, string harakat3)
        {
            List<Pattern> patterns = new List<Pattern>();

            string he = "ي" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + DHAMMA;
            string they2m = "ي" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + FATHA + "ا" + "ن" + KASRA;
            string they3m = "ي" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + DHAMMA + "و" + "ن" + FATHA;
            string she = "ت" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + DHAMMA;
            string they2f = "ت" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + FATHA + "ا" + "ن" + KASRA;
            string they3f = "ي" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + SAKTA + "ن" + FATHA;
            string you1m = "ت" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + DHAMMA;
            string you2m = "ت" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + FATHA + "ا" + "ن" + KASRA;
            string you3m = "ت" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + DHAMMA + "و" + "ن" + FATHA;
            string you1f = "ت" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + KASRA + "ي" + "ن" + FATHA;
            string you2f = "ت" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + FATHA + "ا" + "ن" + KASRA;
            string you3f = "ت" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + SAKTA + "ن" + FATHA;
            string i = "أ" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + DHAMMA;
            string we = "ن" + harakat1 + root1 + SAKTA + root2 + FATHA + harakat3 + root3 + DHAMMA;

            patterns.Add(new Pattern { Number = 1, Person = "3rd", Gender = "M", Plurality = Plurality.Singular, Arabic = "هو", English = "He", Verb = he });
            patterns.Add(new Pattern { Number = 2, Person = "3rd", Gender = "M", Plurality = Plurality.Dual, Arabic = "هما", English = "They (2M)", Verb = they2m });
            patterns.Add(new Pattern { Number = 3, Person = "3rd", Gender = "M", Plurality = Plurality.Plural, Arabic = "هم", English = "They (3+M)", Verb = they3m });
            patterns.Add(new Pattern { Number = 4, Person = "3rd", Gender = "F", Plurality = Plurality.Singular , Arabic = "هي", English = "She", Verb = she });
            patterns.Add(new Pattern { Number = 5, Person = "3rd", Gender = "F", Plurality = Plurality.Dual, Arabic = "هما", English = "They (2F)", Verb = they2f });
            patterns.Add(new Pattern { Number = 6, Person = "3rd", Gender = "F", Plurality = Plurality.Plural, Arabic = "هنّ", English = "They (3+F)", Verb = they3f });
            patterns.Add(new Pattern { Number = 7, Person = "2nd", Gender = "M", Plurality = Plurality.Singular, Arabic = "أنت", English = "You (1M)", Verb = you1m });
            patterns.Add(new Pattern { Number = 8, Person = "2nd", Gender = "M", Plurality = Plurality.Dual, Arabic = "أنتما", English = "You (2M)", Verb = you2m });
            patterns.Add(new Pattern { Number = 9, Person = "2nd", Gender = "M", Plurality = Plurality.Plural, Arabic = "أنتم", English = "You (3+M)", Verb = you3m });
            patterns.Add(new Pattern { Number = 10, Person = "2nd", Gender = "F", Plurality = Plurality.Singular, Arabic = "أنت", English = "You (1F)", Verb = you1f });
            patterns.Add(new Pattern { Number = 11, Person = "2nd", Gender = "F", Plurality = Plurality.Dual, Arabic = "أنتما", English = "You (2F)", Verb = you2f });
            patterns.Add(new Pattern { Number = 12, Person = "2nd", Gender = "F", Plurality = Plurality.Plural, Arabic = "أنتنّ", English = "You (3+F)", Verb = you3f });
            patterns.Add(new Pattern { Number = 13, Person = "1st", Gender = "M/F", Plurality = Plurality.Singular, Arabic = "أنا", English = "I", Verb = i });
            patterns.Add(new Pattern { Number = 14, Person = "1st", Gender = "M/F", Plurality = Plurality.Plural, Arabic = "نحن", English = "We", Verb = we });

            return patterns;
        }

        
    }
}
