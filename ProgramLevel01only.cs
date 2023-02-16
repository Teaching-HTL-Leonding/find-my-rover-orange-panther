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
    int manhattanDistance;
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

    #region linearDistance
    int vertical = north - south;
    if (vertical < 0 ) { vertical *= -1; }

    int horizontal = east - west;
    if (horizontal < 0 ) { horizontal *= -1; }

    double linearDistance = Math.Sqrt((Math.Pow(vertical, 2) + Math.Pow(horizontal, 2)));
    linearDistance = Math.Round(linearDistance, 2);
    Console.Write($"Linear distance = {linearDistance}m, ");
    #endregion

    #region manhattanDistance
    if (east > west) { horizontal = east - west; }
    else if (west > east) {horizontal = west - east; }

    if (north > south) { vertical = north - south; }
    else if (south > north) { vertical = south - north; }

    if (north == south && east == west) { manhattanDistance = 0;}
    else { manhattanDistance = horizontal + vertical; }
    Console.WriteLine($"Manhattan distance = {manhattanDistance}m ");
    # endregion
}
