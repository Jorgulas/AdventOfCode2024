/**
  Tasks:
  1. Read the input from the "input.txt" file
  2. Parse the input into two lists
  3. Sort the lists
  4. Calculate the distance between the two lists by summing the absolute difference between the elements of the two lists
  5. Print the result
*/

// Read the input from the "input.txt" file
string[] lines = System.IO.File.ReadAllLines("./input.txt");

// Parse the input into two lists
List<int> leftList = new List<int>();
List<int> rightList = new List<int>();

foreach (string line in lines)
{
    string[] parts = line.Split("   ");
    leftList.Add(int.Parse(parts[0]));
    rightList.Add(int.Parse(parts[1]));
}

// Sort the lists
leftList.Sort();
rightList.Sort();

// Calculate the distance between the two lists by summing the absolute difference between the elements of the two lists
int distance = 0;
for (int i = 0; i < leftList.Count; i++)
{
    distance += Math.Abs(leftList[i] - rightList[i]);
}

// Print the result
Console.WriteLine(distance);


/**
  Tasks:
  1. Calculate the similarity score by adding up each number in the left list after multiplying it by the number of times that number appears in the right list
  2. Print the result
*/

// Calculate the similarity score by adding up each number in the left list after multiplying it by the number of times that number appears in the right list
int similarityScore = 0;
foreach (int number in leftList) {
    similarityScore += number * rightList.Count(x => x == number);
}

// Print the result
Console.WriteLine(similarityScore);

