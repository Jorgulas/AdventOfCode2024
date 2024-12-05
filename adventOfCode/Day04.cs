

using adventOfCode;


// Day04.Run();

namespace adventOfCode
{
    public class Day04
    {
        public static void Run()
        {

            string[] input = File.ReadAllLines(@"./input04.txt");
            int result = 0;
            int result2 = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if(j - 3 >= 0) { 
                        result += checkXmas(input, i, j, 0, -1);
                    }

                    if(j + 3 < input[i].Length) { 
                        result += checkXmas(input, i, j, 0, 1);
                    }

                    if(i - 3 >= 0) { 
                        result += checkXmas(input, i, j, -1, 0);
                        if (j + 3 < input[i].Length)
                            result += checkXmas(input, i, j, -1, 1);
                        if (j - 3 >= 0)
                            result += checkXmas(input, i, j, -1, -1);
                    }

                    if(i + 3 < input.Length) { 
                        result += checkXmas(input, i, j, 1, 0);
                        if (j + 3 < input[i].Length)
                            result += checkXmas(input, i, j, 1, 1);
                        if (j - 3 >= 0)
                            result += checkXmas(input, i, j, 1, -1);
                    }

                    // - part 2
                    if(j - 1 >= 0 && j + 1 < input[i].Length && i - 1 >= 0 && i + 1 < input.Length) 
                    { 
                        if( checkMas(input, i, j, 1, 1) + checkMas(input, i, j, -1, -1) + checkMas(input, i, j, 1, -1) + checkMas(input, i, j, -1, 1) > 1) 
                        {
                            result2++;
                        }
                    }
                }
            }

            Console.WriteLine($"The word XMAS appears {result} times.");
            Console.WriteLine($"The word MAS appears {result2} times.");

        }

        private static int checkMas(string[] input, int i, int j, int h, int v)
        {
            if (input[i][j] == 'A' && input[i + h][j + v] == 'M' && input[i - h][j - v] == 'S') 
                return 1;
            return 0;
        }

        private static int checkXmas(string[] input, int i, int j, int h, int v)
        {
            if (input[i][j] == 'X' && input[i + h][j + v] == 'M' && input[i + 2 * h][j + 2 * v] == 'A' && input[i + 3 * h][j + 3 * v] == 'S') 
                return 1;
            return 0;
        }
    }
}