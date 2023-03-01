Console.OutputEncoding = System.Text.Encoding.Default;
Console.WriteLine("Welcome to \"Find my rover\".");
CalculateAndPrintCoordinates();

string AskUserForInput()
{
    bool inputIsValid = true;

    do
    {
        if (!inputIsValid) { Console.WriteLine("Invalid Input. 😭 Please try again."); }
        Console.WriteLine("Where did the rover go? 🤖");
        string input = Console.ReadLine()!.Replace(" ", "");

        if (input == "") { inputIsValid = false; }
        else if ((input.Contains('<') || input.Contains('>') || input.Contains('V') || input.Contains('^')) && (input.Contains('0') || input.Contains('1') || input.Contains('2') || input.Contains('3') || input.Contains('4') || input.Contains('5') || input.Contains('6') || input.Contains('7') || input.Contains('8') || input.Contains('9')))
        {
            inputIsValid = true;
            return input;
        }
        else if ((input.Contains('<') || input.Contains('>') || input.Contains('V') || input.Contains('^')) && !(input.Contains('0') || input.Contains('1') || input.Contains('2') || input.Contains('3') || input.Contains('4') || input.Contains('5') || input.Contains('6') || input.Contains('7') || input.Contains('8') || input.Contains('9')))
        {
            inputIsValid = false;
        }
        else if (!(input.Contains('<') || input.Contains('>') || input.Contains('V') || input.Contains('^')) && (input.Contains('0') || input.Contains('1') || input.Contains('2') || input.Contains('3') || input.Contains('4') || input.Contains('5') || input.Contains('6') || input.Contains('7') || input.Contains('8') || input.Contains('9')))
        {
            inputIsValid = false;
        }

    } while (!inputIsValid);
    return "";
}

// string CreateSubstring(string input)
// {
//     int indexOfChar = 0;
//     char firstCharacter = input[0];

//     if (input.StartsWith(firstCharacter))
//     {
//         for (int i = 0; i < input.Length; i++)
//         {
//             if (input[i] == firstCharacter)
//             {
//                 indexOfChar++;
//             }
//             else { i = input.Length; }
//         }
//     }
//     return input.Substring(0, indexOfChar);
// }

void CalculateAndPrintCoordinates()
{
    int north = 0, west = 0, south = 0, east = 0;
    int vertical = 0, horizontal = 0;
    string verticalDirection = "", horizontalDirection = "";
    string input = AskUserForInput();

    while (input != "")
    {
        int movement = int.Parse(input[1].ToString());
        char direction = input[0];

        switch (direction)
        {
            case '^':
                north += movement;
                break;

            case '>':
                east += movement;
                break;

            case 'V':
                south += movement;
                break;

            case '<':
                west += movement;
                break;
        }
        input = input.Substring(2);
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
