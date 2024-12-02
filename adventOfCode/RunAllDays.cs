

// Run all "Day" classes in the project
// There's Day01.cs, Day02.cs, etc.
// Each class has a static method called Run

class RunAll {
  static void Main() {
    var days = typeof(RunAll).Assembly.GetTypes()
      .Where(x => x.Name.StartsWith("Day"))
      .Select(x => (Type: x, Method: x.GetMethod("Run")))
      .Where(x => x.Method != null);

    foreach (var (Type, Method) in days) {
      Console.WriteLine($"Running {Type.Name}...");
      if(Method != null) {
        Method.Invoke(null, null);
      } else {
        Console.WriteLine("No Run method found.");
      }
      Console.WriteLine();
    }
  }
}

