using Memos.Console3;
using Memos.Console3.Models;

var testCrew = TestCrewDataset.GetTestDataCaptain();
var subordinates = CrewMember.GetAllSubordinates(testCrew);

var random = new Random();
var index = random.Next(0, subordinates.Count);
var randomSubordinate = subordinates[index];

Console.WriteLine($"Random crew member (captain excluded): {randomSubordinate.Name}");
Console.WriteLine($"Subordinates:");
foreach (var subordinate in CrewMember.GetAllSubordinates(randomSubordinate))
{
    Console.WriteLine($"- {subordinate.Name}");
}

Console.WriteLine($"\nInfected: {randomSubordinate.Name}");
foreach (var infected in CrewMember.GetInfectedBeforeCaptain(randomSubordinate))
{
    Console.WriteLine($"- {infected.Name}");
}

Console.ReadLine();