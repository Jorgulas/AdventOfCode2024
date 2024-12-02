
class Day02 {
    public static void Run() {

        var file = File.ReadAllLines("./input02.txt")
            .Select(x => x.Split(" ").Select(int.Parse).ToList());

        /**
            --Part One--
            Tasks:
            1. Parse the input into a list of lists
            2. Check each list to see if it is safe
            3. Print the number of safe lists
        */
        var safeCount = file
            .Count(IsSafe);

        Console.WriteLine(safeCount);

        /**
            --Part Two--
            Tasks:
            1. Check each list to see if it is safe with the Problem Dampener
            2. Print the number of safe lists
        */
        var safeCount2 = file
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
        return IsMonotonic(levels);
    }

    static bool IsMonotonic(List<int> levels) {
        if (levels.Count < 2) return true;

        bool isIncreasing = true;
        bool isDecreasing = true;

        for (int i = 1; i < levels.Count; i++) {
            if (Comparator(levels[i], levels[i - 1])) {
                isIncreasing = false;
            }
            if (Comparator(levels[i - 1], levels[i])) {
                isDecreasing = false;
            }

            // Early exit
            if (!isIncreasing && !isDecreasing) {
                return false;
            }
        }

        return isIncreasing || isDecreasing;
}

    static bool Comparator(int a, int b) {
        var sub = a-b;
        return sub < 1 || sub > 3;
    }
}