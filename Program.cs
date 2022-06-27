const string RDW = "Dienst Wegverkeer";

string json = @"{ 
       'ID'            : '1',
       'Omschrijving'  : 'Sandra\'s auto',
       'Voornaam'      : 'Sandra',
       'Achternaam'    : 'Janssens',
       'Regio'         : 'Noord'
}";
EIGENAAR eigenaar =
JsonConvert.DeserializeObject<EIGENAAR>(json);
Console.WriteLine($"ID: {eigenaar.ID}.");
Console.WriteLine($"Omschrijving: {eigenaar.Omschrijving}");
Console.WriteLine($"Eigenaar: {eigenaar.Voornaam} {eigenaar.Achternaam}");
Console.WriteLine($"Regio: { eigenaar.Regio}\n");

var eigenaarstruct = 
new EIGENAARSTRUCT(2, "Peter's auto", "Peter", "Veermans", "Midden");
Console.WriteLine($"ID: {eigenaarstruct.ID}.");
Console.WriteLine($"Omschrijving: {eigenaarstruct.Omschrijving}");
Console.WriteLine($"Eigenaar: {eigenaarstruct.Voornaam} {eigenaarstruct.Achternaam}");
Console.WriteLine($"Regio: { eigenaarstruct.Regio}\n");

var eigenaarstruct2 = eigenaarstruct with { ID = 3, Omschrijving = "Peter's tweede auto" };
Console.WriteLine($"ID: {eigenaarstruct2.ID}.");
Console.WriteLine($"Eigenaar: {eigenaarstruct2.Voornaam} {eigenaarstruct2.Achternaam}");
Console.WriteLine($"Omschrijving: {eigenaarstruct2.Omschrijving}\n");

Console.WriteLine($"De {RDW} verzorgt de registratie van gemotoriseerde voertuigen en rijbewijzen in Nederland.\n");

EIGENAAR2 eigenaar2 = new EIGENAAR2();
eigenaar2.ID = 3;
eigenaar2.Omschrijving = "Olga's auto";
eigenaar2.Voornaam = "Olga";
eigenaar2.Achternaam = "Mulder";
eigenaar2.Regio = "Zuid";
eigenaar2.betaalgegevens.IBAN = "1234567";
eigenaar2.betaalgegevens.BIC = "BANKNL12ABC";
eigenaar2.betaalgegevens.Tenaamstelling = "O. MULDER";

if(eigenaar2 is { Omschrijving: "Olga's auto", betaalgegevens : { IBAN: "1234567" } } )
{
    Console.WriteLine($"De motorrijtuigenbelasting van {eigenaar2.Omschrijving} wordt betaald door {eigenaar2.betaalgegevens.Tenaamstelling}.");
}

if (eigenaar2 is { Omschrijving: "Olga's auto", betaalgegevens.IBAN: "1234567" })
{
    Console.WriteLine($"De motorrijtuigenbelasting van {eigenaar2.Omschrijving} wordt betaald door {eigenaar2.betaalgegevens.Tenaamstelling}.");
}

public class EIGENAAR
{
    public int ID { get; set; }

    public string Omschrijving { get; set; }

    public string Voornaam { get; set; }

    public string Achternaam { get; set; }

    public string Regio { get; set; }
}

public class EIGENAAR2
{
    public int ID { get; set; }

    public string Omschrijving { get; set; }

    public string Voornaam { get; set; }

    public string Achternaam { get; set; }

    public string Regio { get; set; }

    public BETAALGEGEVENS betaalgegevens { get; set; } = new BETAALGEGEVENS();
}

public class BETAALGEGEVENS
{
    public string Rekeningnummer { get; set; }

    public string IBAN { get; set; }
    public string BIC { get; set; }
    public string Tenaamstelling { get; set; }

}
public readonly record struct EIGENAARSTRUCT(int ID,
                                              string Omschrijving,
                                              string Voornaam,
                                              string Achternaam,
                                              string Regio);