using System;
using System.Globalization;
using System.IO;

namespace TriangleAreaApp
{
    class Program
    {
        static void Main()
        {
            // Укажите полный путь для input.txt и output.txt
            string inputFile = @"C:\Users\P C\source\repos\TriangleAreaApp\TriangleAreaApp\input.txt";
            string outputFile = @"C:\Users\P C\source\repos\TriangleAreaApp\TriangleAreaApp\output.txt";

            // Логирование пути, где будет создан файл
            Console.WriteLine($"Attempting to write to: {Path.GetFullPath(outputFile)}");

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            string[] lines = File.ReadAllLines(inputFile);
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    foreach (string line in lines)
                    {
                        string result = ProcessLine(line);
                        writer.WriteLine(result);
                    }
                    writer.Flush(); // Принудительный сброс данных в файл
                }

                Console.WriteLine($"Results written to {outputFile}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        static string ProcessLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return "Invalid input";

            string[] parts = line.Split();
            double area;

            try
            {
                if (parts.Length == 3 && double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double a) &&
                                      double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double b) &&
                                      double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double c))
                {
                    area = Triangle.CalculateArea(a, b, c);
                }
                else if (parts.Length == 6)
                {
                    var p1 = (double.Parse(parts[0], CultureInfo.InvariantCulture), double.Parse(parts[1], CultureInfo.InvariantCulture));
                    var p2 = (double.Parse(parts[2], CultureInfo.InvariantCulture), double.Parse(parts[3], CultureInfo.InvariantCulture));
                    var p3 = (double.Parse(parts[4], CultureInfo.InvariantCulture), double.Parse(parts[5], CultureInfo.InvariantCulture));
                    area = Triangle.CalculateArea(p1, p2, p3);
                }
                else
                {
                    return line + " => Invalid format";
                }

                return line + $" => {area:F3}";
            }
            catch
            {
                return line + " => Error";
            }
        }
    }

    
}
