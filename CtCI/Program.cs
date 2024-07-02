using Chapter01_ArraysAndStrings;

var cliArgs = Environment.GetCommandLineArgs();

switch (cliArgs[1])
{
    case "Chapter01.Q1":
        Question01_IsUnique.Run();
        break;
    default:
        Console.WriteLine("");
        break;
}