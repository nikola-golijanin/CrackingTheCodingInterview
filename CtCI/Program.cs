using Chapter01_ArraysAndStrings;

var cliArgs = Environment.GetCommandLineArgs();

switch (cliArgs[1])
{
    case "Chapter01.Q1":
        Question01_IsUnique.Run();
        break;
    case "Chapter01.Q2":
        Question02_CheckPermutation.Run();
        break;
    case "Chapter01.Q3":
        Question03_URLify.Run();
        break;
    default:
        Console.WriteLine("");
        break;
}