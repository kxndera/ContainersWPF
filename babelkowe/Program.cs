int[] tab = new int[100];
Random random = new Random();
for (int i = 0; i < tab.Length; i++)
{
    tab[i] = random.Next(0,1000);
}

/************************
  nazwa funkcji: Sorting
  parametry wejściowe: int[] a - tablica z losowymi wartościami od 0 do 1000

 wartość zwracana: posortowane wartosci tablicy

 informacje: modyfikuje tablicę i segreguje wartości sortowaniem bąbelkowe

 autor:  早川あき
   ************************/
void Sorting(int[] a)
{
    int number = a.Length;
    do
    {
        for (int i = 0; i < number - 1; i++)
        {
            if (tab[i] > tab[i + 1])
            {
                int tmp = tab[i];
                tab[i] = tab[i + 1];
                tab[i + 1] = tmp;
            }
        }
        number--;
    } while (number > 1);
}

Sorting(tab);
Console.WriteLine("posortowana tablica:");
foreach (int i in tab)
    Console.Write(i + "; ");
    
