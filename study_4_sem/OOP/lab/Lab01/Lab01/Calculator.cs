using System;
using System.Linq;

namespace TextCalculator
{
    public delegate void CalculationPerformedHandler(string result);

    public class Calculator
    {
        public event CalculationPerformedHandler OnCalculationPerformed;

        public void ReplaceSubstring(string input, string oldSubstring, string newSubstring)
        {
            string result = input.Replace(oldSubstring, newSubstring);
            OnCalculationPerformed?.Invoke(result);
        }

        public void RemoveSubstring(string input, string substringToRemove)
        {
            string result = input.Replace(substringToRemove, string.Empty);
            OnCalculationPerformed?.Invoke(result);
        }

        public void GetCharAtIndex(string input, int index)
        {
            if (index < 0 || index >= input.Length)
                throw new IndexOutOfRangeException("Индекс выходит за пределы строки.");

            string result = input[index].ToString();
            OnCalculationPerformed?.Invoke(result);
        }


        public void GetLength(string input)
        {
            string result = input.Length.ToString();
            OnCalculationPerformed?.Invoke(result);
        }

        public void GetWordCount(string input)
        {
            string result = input.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
            OnCalculationPerformed?.Invoke(result);
        }

        public void GetSentenceCount(string input)
        {
            char[] sentenceEndings = { '.', '!', '?' };
            string result = input.Split(sentenceEndings, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
            OnCalculationPerformed?.Invoke(result);
        }

        public void GetVowelsCount(string input)
        {
            string vowels = "aeiouаеёиоуыэюяAEIOUАЕЁИОУЫЭЮЯ";
            string result = input.Count(c => vowels.Contains(c)).ToString();
            OnCalculationPerformed?.Invoke(result);
        }

        public void GetConsonantsCount(string input)
        {
            string vowels = "aeiouаеёиоуыэюяAEIOUАЕЁИОУЫЭЮЯ";
            string result = input.Count(c => char.IsLetter(c) && !vowels.Contains(c)).ToString();
            OnCalculationPerformed?.Invoke(result);
        }
    }
}
