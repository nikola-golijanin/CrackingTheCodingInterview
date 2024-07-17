using Chapter01_ArraysAndStrings;
using Chapter02_LinkedLists;
using Chapter04_TreesAndGraphs.Question01_RouteBetweenNodes;

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
    case "Chapter02.Q2":
        Question02_ReturnKthToLast.Run();
        break;
    case "Chapter02.Q3":
        Question03_DeleteMiddleNode.Run();
        break;
    case "Chapter02.Q4":
        Question04_Partition.Run();
        break;
    case "Chapter02.Q5":
        Question05_SumLists.Run();
        break;
    case "Chapter02.Q6":
        Question06_IsPalindrome.Run();
        break;
    case "Chapter02.Q7":
        Question07_Intersection.Run();
        break;
    case "Chapter02.Q8":
        Question08_LoopDetection.Run();
        break;
    case "Chapter04.Q1":
        Question01_RouteBetweenNodes.Run();
        break;
    default:
        Console.WriteLine("");
        break;
}