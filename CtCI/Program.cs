using Chapter01_ArraysAndStrings;
using Chapter02_LinkedLists;

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
    case "Chapter01.Q4":
        Question04_IsPermutationOfPalindrome.Run();
        break;
    case "Chapter01.Q5":
        Question05_OneAway.Run();
        break;
    case "Chapter01.Q6":
        Question06_StringCompression.Run();
        break;
    case "Chapter01.Q7":
        Question07_RotateMatrixFor90.Run();
        break;
    case "Chapter01.Q8":
        Question08_ZeroMatrix.Run();
        break;
    case "Chapter01.Q9":
        Question09_StringRotation.Run();
        break;
    case "Chapter02.Q1":
        Question01_RemoveDups.Run();
        break;
    default:
        Console.WriteLine("");
        break;
}