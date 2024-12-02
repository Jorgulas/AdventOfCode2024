
// Day02.Run();

class Day02 {
  public static void Run() {
    /**
      --Part One--
      Tasks:
      1. Read the input from the "input02.txt" file
      2. Parse the input into a list of lists
      3. Check each list to see if it is safe
      4. Print the number of safe lists
    */
    var safeCount = File.ReadAllLines("./input02.txt")
      .Select(x => x.Split(" ").Select(int.Parse).ToList())
      .Count(IsSafe);
    
    Console.WriteLine(safeCount);

    /**
      --Part Two--
      Tasks:
      1. Check each list to see if it is safe with the Problem Dampener
      2. Print the number of safe lists
    */

    var safeCount2 = File.ReadAllLines("./input02.txt")
      .Select(x => x.Split(" ").Select(int.Parse).ToList())
      .Count(IsSafeWithDampener);

    Console.WriteLine(safeCount2);

  }

    static bool IsSafeWithDampener(List<int> levels) {
        for (int i = 0; i < levels.Count; i++) {
            var copy = new List<int>(levels);
            copy.RemoveAt(i);
            if (IsSafe(copy)) {
                return true;
            }
        }
        return false;
    }

  static bool IsSafe(List<int> levels) {
    return IsIncreasing(levels) || IsDecreasing(levels);
  }

  static bool IsIncreasing(List<int> levels) {
    for (int i = 1; i < levels.Count; i++) {
      if (levels[i] - levels[i - 1] < 1 || levels[i] - levels[i - 1] > 3) {
        return false;
      }
    }
    return true;
  }

  static bool IsDecreasing(List<int> levels) {
    for (int i = 1; i < levels.Count; i++) {
      if (levels[i - 1] - levels[i] < 1 || levels[i - 1] - levels[i] > 3) {
        return false;
      }
    }
    return true;
  }
}