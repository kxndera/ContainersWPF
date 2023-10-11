int[] a = new int[100];
Random r = new Random();
for (int i = 0; i < a.Length; i++)
{
    a[i] = r.Next(0,100);
}
void Sortowanie(int[] a)
{
    int tmp = a.Length;
    do
    {
        for (int i = 0; i < tmp - 1; i++)
        {
            if (a[i] > a[i + 1])
            {
                int b = a[i];
                a[i] = a[i + 1];
                a[i + 1] = b;
            }
        }
        tmp--;
    } while (tmp > 1);
}

Sortowanie(a);
Console.WriteLine("posortowana tablica:");
foreach (int i in a)
    Console.Write(i + "; ");
    
