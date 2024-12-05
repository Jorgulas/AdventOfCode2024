
using System.Text.RegularExpressions;

//Day03.Run();

class Day03 {
  public static void Run() {

    var input = File.ReadAllText("./input03.txt");
    
    /**
        --Part One--
        Tasks:
        1. Read the input from the "input03.txt" file
        2. Parse the input into a list of strings
        3. Filter out the invalid characters through regex
        4. Parse the strings into a list of tuples
        5. Calculate the result by multiplying the two numbers in each tuple
        6. Print the result
    */
    var mulSearch = @"mul\((\d+),(\d+)\)";
    
    var result = Regex.Matches(input, mulSearch)
      .Select(x => (int.Parse(x.Groups[1].Value), int.Parse(x.Groups[2].Value)))
      .Select(x => x.Item1 * x.Item2)
      .Sum();

    Console.WriteLine(result);

    /**
        --Part Two--
        Tasks:
        1. Read the input from the "input03.txt" file
        2. Parse the input into a list of strings
        3. Filter out the invalid characters through regex
        4. Parse the strings into a list of tuples
        5. Calculate the result by multiplying the two numbers in each tuple
        6. Print the result
    */
    var matches2 = Regex.Matches(input, @"(do\(\)|don't\(\)|"+mulSearch+")")
      .Select(x => x.Groups[1].Value)
      .Aggregate((Result: 0, Enabled: true), (acc, x) => {
        if (x.StartsWith("mul")) {
            if (acc.Enabled) {
                var match = Regex.Match(x, mulSearch);
                return (acc.Result + int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value), acc.Enabled);
            }
            return acc;
        } else if (x == "do()") {
            return (acc.Result, true);
        } else {
            return (acc.Result, false);
        }
    });

    Console.WriteLine(matches2.Result);

  }
}