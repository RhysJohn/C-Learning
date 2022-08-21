namespace Katas._6kyu.Tribonacci;

public class Solution : ISolution
{
    // 1. Get passed in a starting sequence, use the starting sequence to start off the sequence.
    public double[] Tribonacci(double[] signature, int n)
    {
        if (n is 0)
        {
            return Array.Empty<double>();
        }

        var answer = signature.ToList();
        if (n < 4)
        {
            return answer.Take(n).ToArray();
        }

        for (var i = 0; i < n - 3; i++)
        {
            // Calculate the next element in the sequence.
            var previouslyThreeSummed = answer.Skip(i).Take(3).Sum();

            answer.Add(previouslyThreeSummed);
        }

        return answer.ToArray();
    }


    public bool Test()
    {
        var testArray = new double[] { 1, 1, 1 };
        var test = Tribonacci(testArray, 10);

        Console.WriteLine(string.Join(',', test));
        
        return false;
    }
}