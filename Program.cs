Console.OutputEncoding = System.Text.Encoding.Default;
CalculateAndPrintCoordinates();

string AskUserForInput()
{
    string input = "<";
    do
    {
        if (!input.Contains('<') && !input.Contains('>') && !input.Contains('V') && !input.Contains('^'))
        {
            Console.WriteLine("Invalid Input. 😭 Please try again.");
        }
        Console.WriteLine("Where did the rover go? 🤖");
        input = Console.ReadLine()!;
    } while (input == "" || !input.Contains('<') && !input.Contains('>') && !input.Contains('V') && !input.Contains('^'));
    return input;
}

string CreateSubstring(string input)
{
    int indexOfChar = 0;
    char firstCharacter = input[0];

    if (input.StartsWith(firstCharacter))
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == firstCharacter)
            {
                indexOfChar++;
            }
            else { i = input.Length; }
        }
    }
    return input.Substring(0, indexOfChar);
}

void CalculateAndPrintCoordinates()
{
    int north = 0, west = 0, south = 0, east = 0;
    int vertical = 0, horizontal = 0;
    string verticalDirection = "", horizontalDirection = "";
    string input = AskUserForInput();

    while (input != "")
    {
        string substring = CreateSubstring(input);
        char Character = substring[0];

        switch (Character)
        {
            case '^':
                north += substring.Length;
                break;

            case '>':
                east += substring.Length;
                break;

            case 'V':
                south += substring.Length;
                break;

            case '<':
                west += substring.Length;
                break;
        }
        input = input.Substring(substring.Length);
    }

    Console.Write("The rover is ");

    if (east > west)
    {
        horizontal = east - west;
        horizontalDirection = "East";
    }
    else if (west > east)
    {
        horizontal = west - east;
        horizontalDirection = "West";
    }

    if (north > south)
    {
        vertical = north - south;
        verticalDirection = "North";
    }
    else if (south > north)
    {
        vertical = south - north;
        verticalDirection = "South";
    }

    if (north == south && east == west) { Console.WriteLine("in the base station. 👽 "); }
    if (horizontal != 0) { Console.Write($"{horizontal}m to the {horizontalDirection} "); }
    if (vertical != 0 && horizontal != 0) { Console.Write("and "); }
    if (vertical != 0) { Console.Write($"{vertical}m to the {verticalDirection} "); }

}

