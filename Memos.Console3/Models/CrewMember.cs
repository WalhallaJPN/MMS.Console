namespace Memos.Console3.Models;

using System.Collections.Generic;

/// <summary>
/// ST Crew Member model.
/// </summary>
public class CrewMember
{
    #region Properties
    /// <summary>
    /// Crew Member name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// One's superior.
    /// </summary>
    public CrewMember? Superior { get; set; }

    /// <summary>
    /// Subordinates.
    /// </summary>
    public List<CrewMember> Subordinates { get; set; } = [];

    #endregion

    #region Constructors 

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="name">Name of crew member.</param>
    /// <param name="superior">Superior.</param>
    /// <param name="subordinates"></param>
    public CrewMember(string name, CrewMember? superior = null, List<CrewMember>? subordinates = null)
    {
        Name = name;
        Superior = superior ?? null;
        Subordinates = subordinates ?? [];
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Method to recursivelly get all subordinates of a crew member.
    /// </summary>
    /// <param name="crewMember">Crew Member.</param>
    /// <returns>List of subordinates.</returns>
    public static List<CrewMember> GetAllSubordinates(CrewMember crewMember)
    {
        var result = new List<CrewMember>();

        if (crewMember.Subordinates is not null)
        {
            foreach (var subordinate in crewMember.Subordinates)
            {
                result.Add(subordinate);
                result.AddRange(GetAllSubordinates(subordinate));
            }
        }

        return result;
    }

    /// <summary>
    /// Method to return infected members until captain is reached.
    /// </summary>
    /// <param name="infected"></param>
    /// <returns></returns>
    public static List<CrewMember> GetInfectedBeforeCaptain(CrewMember infected)
    {
        var result = new HashSet<CrewMember>();
        var current = infected;

        while (current.Superior is not null)
        {
            var superior = current.Superior;

            if (superior.Superior is null)
            {
                break;
            }

            foreach (var sibling in superior.Subordinates)
            {
                if (sibling == current)
                {
                    continue;
                }

                result.Add(sibling);

                foreach(var subordinate in GetAllSubordinates(sibling))
                {
                    result.Add(subordinate);
                }
            }

            result.Add(superior);
            current = superior;
        }

        result.Remove(infected);
        return [.. result];
    }

    #endregion
}
