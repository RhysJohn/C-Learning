namespace Katas._4kyu.RomanNumeralsHelper;

public class Solution : ISolution
{
    private IDictionary<int, char> _valueToSymbol;
    private IDictionary<char, int> _symbolToValue;

    public Solution()
    {
        _valueToSymbol = new Dictionary<int, char>()
        {
            { 1, 'I' },
            { 5, 'V' },
            { 10, 'X' },
            { 50, 'L' },
            { 100, 'C' },
            { 500, 'D' },
            { 1000, 'M' }
        };

        _symbolToValue = _valueToSymbol.ToDictionary(pair => pair.Value, pair => pair.Key);
    }

    /// <summary>
    /// Input range : 1 <= n < 4000
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public string ToRoman(int numberToCheck)
    {
        // either 4 or 9 needs to be the V/D -> minus the lowest degree
        // check how many digits - if the first is 9 get the next biggest and 1 version of the digit. 900 -> 1000-100
        var numberAsString = numberToCheck.ToString();
        var numberAsStringLength = numberToCheck.ToString().Length;

        var numbers = numberToCheck.ToString().Select((num, index) =>
            int.Parse(num.ToString())).Select((num, index) =>
            (int)(num * Math.Pow(10, (numberToCheck.ToString().Length - 1) - index)));

        var testNumbers = numbers
            .Select(fullNumber =>
            {
                if (fullNumber == 0)
                {
                    return "";
                }
                // does fullNumber === anything in the _valueToSymbol dictionary.
                var check = _valueToSymbol.ContainsKey(fullNumber);

                if (check)
                {
                    return _valueToSymbol[fullNumber].ToString();
                }
                
                // check if the start number is either 4/9...
                var highestNumberThatFits = _valueToSymbol.ElementAt(0);

                for (int i = 0; i < _valueToSymbol.Count; i++)
                {
                    var currentPair = _valueToSymbol.ElementAt(i);
                    var nextPair = _valueToSymbol.ElementAt(i + 1);

                    if (fullNumber > currentPair.Key && nextPair.Key > fullNumber)
                    {
                        highestNumberThatFits = currentPair;
                        break;
                    }
                }

                // highest number that fits in, fullNumber / high number that fits this is the amount of times which we need the symbol
                var numberOfTimesHighestFitsIn = fullNumber / highestNumberThatFits.Key;
                return new string(highestNumberThatFits.Value, numberOfTimesHighestFitsIn);
            });


        return string.Join("", testNumbers);
    }

    public int FromRoman(string romanNumeral)
    {
        return 0;
    }

    public bool Test()
    {
        // var cTest = ToRoman(100);
        // var twoCTestTest = ToRoman(200);
        var rand = ToRoman(556);

        // Console.WriteLine(cTest);
        // Console.WriteLine(twoCTestTest);
        Console.WriteLine(rand);

        return rand == "DLVI";
    }
}