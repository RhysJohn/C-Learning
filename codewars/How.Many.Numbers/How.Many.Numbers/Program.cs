// See https://aka.ms/new-console-template for more information

// 1. The numbers should have 2 digits at least.
// 2. They should have their respective digits in increasing order from left to right. e.g. 789, 248, 123456789
// 3. They cannot have digits that occurs twice or more.
// 4. The difference between neighbouring pairs of digits cannot exceed certain values, based on d. e.g. if d = 2
//    1456 doesn't belong in the group as the difference between 1 and 4 is 3.

int[] SelNumber(int n, int d)
{
    if (n < 12 || d > 8)
    {
        return Array.Empty<int>();
    }

    var numbersBasedOutFromDifference = Enumerable.Range(12, n - 12).Where(possibleNumber =>
    {
        var possibleNumberAsString = possibleNumber.ToString();
        var possibleNumberSplit = possibleNumberAsString.Select(number => int.Parse(number.ToString())).ToArray();

        // distinct
        var allDistinctNumbers = possibleNumberSplit.Any(p => possibleNumberSplit.Count(o => o == p) > 1);
        if (allDistinctNumbers)
        {
            return false;
        }

        var possibleNumberLength = possibleNumberAsString.Length;

        // consecutive numbers and if they are bigger than the difference.
        for (var i = 0; i < possibleNumberLength - 1; i++)
        {
            if (possibleNumberSplit[i + 1] - possibleNumberSplit[i] > d ||
                possibleNumberSplit[i + 1] - possibleNumberSplit[i] <= 0)
            {
                return false;
            }
        }

        return true;
    });

    return numbersBasedOutFromDifference.ToArray();
}

var test = SelNumber(50, 3);

Console.WriteLine(string.Join(',', test));
Console.WriteLine(test.Count());
Console.ReadKey();