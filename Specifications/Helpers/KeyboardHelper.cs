namespace Specifications.Helpers;

public static class KeyboardHelper
{
    public static T Choose<T>(this List<T> items, string message)
    {
        Console.WriteLine(message);

        var selectedIndex = 0;
        ConsoleKeyInfo keyInfo;

        do
        {
            Console.Clear();
            DisplayList(items, selectedIndex);
            keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = selectedIndex == 0 ? items.Count - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = selectedIndex == items.Count - 1 ? 0 : selectedIndex + 1;
                    break;
            }

        } while (keyInfo.Key != ConsoleKey.Enter);

        Console.Clear();
        return items[selectedIndex];
    }


    static void DisplayList<T>(List<T> items, int selectedIndex)
    {
        for (var i = 0; i < items.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("> " + items[i]);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("  " + items[i]);
            }
        }
    }
}
