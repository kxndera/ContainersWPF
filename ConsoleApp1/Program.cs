uint a, b;
Console.WriteLine("Podaj a:");
a = uint.Parse(Console.ReadLine());

Console.WriteLine("Podaj b:");
b = uint.Parse(Console.ReadLine());

/*
***********************************************
nazwa funkcji: NWD
opis funkcji: Oblicza NWD dwóch liczb
parametry: a - liczba pierwsza
b - liczba druga
zwracany typ i opis: uint = obliczone NWD
autor: :3
***********************************************

 */
uint NWD(uint a, uint b)
{
    while(a != b)
    {
        if (a > b)
            a = a - b;
        else
            b = b - a;
    }
    return a;
}