int n = 100;
bool[] A = new bool[101];
        

  void FillTable(bool []a)
{
    for (int i = 2; i < 101; i++)

    {
        a[i] = true;
    }
}
 /************************
  nazwa funkcji: IsPrimeNumber
  parametry wejściowe: bool [a] - tablica z wartościami do 101

 wartość zwracana: w tablicy jest zwracana wartość, czy liczba jest pierwsza czy nie

 informacje: modyfikuje tablicę i wybiera liczby pierwszę metodą sita Erastotenesa

 autor:  早川あき
   ************************/

void IsPrimeNumber(bool[] a)
{
    for (int i = 2; Math.Sqrt(n) > i; i++)
    {
        if (a[i] == true)
        {

            for (int j = 2; j * i < 101; j++)
            {
                a[j * i] = false;
            }
        }
    }
}
    FillTable(A);
   IsPrimeNumber(A);


for (int i = 2; i < 101; i++)
{
    if (A[i])Console.Write(i + "; ");
}



