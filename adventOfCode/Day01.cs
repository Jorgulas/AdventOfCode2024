
// Day01.Run();

class Day01 {
   public static void Run() {
    /**
      --Part One--
      Tasks:
      1. Read the input from the "input.txt" file
      2. Parse the input into two lists
      3. Sort the lists
      4. Calculate the distance between the two lists by summing the absolute difference between the elements of the two lists
      5. Print the result
    */
    var (left, right) = File.ReadAllLines("./input.txt")
      .Select(x => x.Split(["   "], StringSplitOptions.RemoveEmptyEntries))
      .Select(x => (Left: int.Parse(x[0]), Right: int.Parse(x[1])))
      .OrderBy(x => x.Left)
      .ToList()
      .Unzip();
    
    left.Sort();
    right.Sort();

    int distance1 = left.Zip(right, (l, r) => Math.Abs(l - r)).Sum();
    Console.WriteLine(distance1);

    /**
      --Part Two--
      Tasks:
      1. Calculate the similarity score by adding up each number in the left list after multiplying it by the number of times that number appears in the right list
      2. Print the result
    */
    int similarity = right.Sum(x => left.Count(y => y == x) * x);
    Console.WriteLine(similarity);
  }
}

static class Extensions
{
  public static (List<T1>, List<T2>) Unzip<T1, T2>(this List<(T1, T2)> source)
  {
    return (
      source.Select(x => x.Item1).ToList(),
      source.Select(x => x.Item2).ToList()
    );
  }
}