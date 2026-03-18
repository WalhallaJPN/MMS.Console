namespace Memos.Console3;

using Memos.Console3.Models;
using System.Collections.Generic;

public static class TestCrewDataset
{
    /// <summary>
    /// Test dataset crew.
    /// </summary>
    /// <returns>Captain of the ship.</returns>
    public static CrewMember GetTestDataCaptain()
    {
        var jeanLucPickard = new CrewMember("Jean-Luc Picard");

        var williamRiker = new CrewMember("William Riker", jeanLucPickard);
        var deanaTroi = new CrewMember("Deana Troi", jeanLucPickard);
        var jordiLaForge = new CrewMember("Jordi La Forge", jeanLucPickard);

        jeanLucPickard.Subordinates.AddRange(williamRiker, deanaTroi, jordiLaForge);

        var worfSonOfMogh = new CrewMember("Worf son of Mogh", williamRiker);
        var guinam = new CrewMember("Guinam", williamRiker);
        var beverlyCrusher = new CrewMember("Beverly Crusher", williamRiker);

        williamRiker.Subordinates.AddRange(worfSonOfMogh, guinam, beverlyCrusher);

        var lwaxanaTroi = new CrewMember("Lwaxana Troi", deanaTroi);
        var reginaldBarclay = new CrewMember("Reginald Barclay", deanaTroi);

        deanaTroi.Subordinates.AddRange(lwaxanaTroi, reginaldBarclay);

        var mrData = new CrewMember("Mr. Data", jordiLaForge);
        var milesOBrien = new CrewMember("Miles O'Brien", jordiLaForge);

        jordiLaForge.Subordinates.AddRange(mrData, milesOBrien);

        var tashaYar = new CrewMember("Tasha Yar", worfSonOfMogh);
        var kehleyr = new CrewMember("K'Ehleyr", worfSonOfMogh);

        worfSonOfMogh.Subordinates.AddRange(tashaYar, kehleyr);

        var wesleyCrusher = new CrewMember("Wesley Crusher", beverlyCrusher);
        var alyssaOgawa = new CrewMember("Alyssa Ogawa", beverlyCrusher);

        beverlyCrusher.Subordinates.AddRange(wesleyCrusher, alyssaOgawa);

        var alexanderRozhenko = new CrewMember("Alexander Rozhenko", kehleyr);
        var julianBashir = new CrewMember("Julian Bashir", alyssaOgawa);

        kehleyr.Subordinates.Add(alexanderRozhenko);
        alyssaOgawa.Subordinates.Add(julianBashir);

        return jeanLucPickard;
    }
}
