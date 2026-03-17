using Memos.Console.Models;

// Simple console app to generate rand numbers of the range and get duplicities.
var intArray = new IntegerArray(1_000_000, 1, 100_000);

intArray.FindDuplicitiesInArray();
Console.WriteLine(intArray.ToString());
Console.ReadLine();
