namespace TupleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example 1: Returning Multiple Values from a Method
            var result = CalculateSumAndProduct(5, 7);
            Console.WriteLine($"Example 1 - Sum: {result.sum}, Product: {result.product}");

            // Example 2: Iterating Through Collections
            List<(string Name, int Age, bool IsStudent)> people = new List<(string, int, bool)>
            {
                ("Alice", 28, false),
                ("Bob", 35, true),
                ("Carol", 22, false)
            };

            Console.WriteLine("\nExample 2 - People's Info:");
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} is {person.Age} years old. {(person.IsStudent ? "Is a student." : "Is not a student.")}");
            }

            // Example 3: Error Handling with Try-Parse
            bool success;
            int parsedValue;

            Console.Write("\nExample 3 - Enter a number: ");
            string input = Console.ReadLine();

            (success, parsedValue) = TryParseInt(input);

            if (success)
            {
                Console.WriteLine($"Parsed value: {parsedValue}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            // Example 4: Grouping Data
            var groupedData = GroupData();

            Console.WriteLine("\nExample 4 - Grouped Data:");
            foreach (var group in groupedData)
            {
                Console.WriteLine($"Group: {group.Key}");
                foreach (var item in group.Items)
                {
                    Console.WriteLine($"  {item.Name} ({item.Age} years old)");
                }
            }
        }

        // Example 1: Returning Multiple Values from a Method
        public static (int sum, int product) CalculateSumAndProduct(int num1, int num2)
        {
            int sum = num1 + num2;
            int product = num1 * num2;
            return (sum, product);
        }

        // Example 3: Error Handling with Try-Parse
        public static (bool success, int parsedValue) TryParseInt(string input)
        {
            int result;
            bool success = int.TryParse(input, out result);
            return (success, result);
        }

        // Example 4: Grouping Data
        public static List<(string Key, List<(string Name, int Age)> Items)> GroupData()
        {
            var data = new List<(string Group, string Name, int Age)>
            {
                ("Group A", "Alice", 28),
                ("Group B", "Bob", 35),
                ("Group A", "Alex", 22),
                ("Group C", "Charlie", 30),
                ("Group B", "Bill", 45),
            };

            var groupedData = new List<(string Key, List<(string Name, int Age)> Items)>();

            var groups = data.GroupBy(d => d.Group);
            foreach (var group in groups)
            {
                var items = group.Select(item => (item.Name, item.Age)).ToList();
                groupedData.Add((group.Key, items));
            }

            return groupedData;
        }
    }
}
