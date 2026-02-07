namespace Kruskalov_algoritam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kruskal kruskal = new Kruskal();
            Console.ReadLine();
        }
    }
    public class Grana
    {
        public int od;
        public int ka;
        public int tezina;

        public Grana(int od, int ka, int tezina)
        {
            this.od = od;
            this.ka = ka;
            this.tezina = tezina;
        }

        public override string ToString()
        {
            return $"{od} - {ka}, Težina: {tezina}";
        }
    }
    public class Kruskal
    {
        List<Grana> grane = new List<Grana>();
        List<Grana> izabraneGrane = new List<Grana>();
        int masa = 0;
        public Kruskal()
        {
            Console.Write("Unesite broj grana u grafu: ");
            int broj_grana = Convert.ToInt32(Console.ReadLine());

            Console.Write("Unesite broj cvorova u grafu: ");
            int broj_cvorova = Convert.ToInt32(Console.ReadLine());

            for (int i=0; i < broj_grana; i++)
            {
                Console.WriteLine($"Grana {i}");
                Console.Write("Od cvora: ");
                int od = int.Parse(Console.ReadLine());
                Console.Write("Ka cvoru: ");
                int ka = int.Parse(Console.ReadLine());
                Console.Write("Tezina grane: ");
                int tezina = int.Parse(Console.ReadLine());
                grane.Add(new Grana(od, ka, tezina));
            }
            for(int i = 0; i < broj_grana; i++)
            {
                Grana original = grane[i];
                grane.Add(new Grana(original.ka, original.od, original.tezina));
            }
            grane.Sort((x,y) => x.tezina.CompareTo(y.tezina));
            int[] skup = new int[broj_cvorova];
            int kp = broj_cvorova;

            for (int i = 0; i < broj_cvorova; i++)
            {
                skup[i] = i;
            }

            for(int i=0;i<grane.Count;i++)
            {
                if (skup[grane[i].od] != skup[grane[i].ka])
                {
                    masa += grane[i].tezina;
                    izabraneGrane.Add(grane[i]);
                    kp--;

                    int staro = skup[grane[i].ka];
                    int novo = skup[grane[i].od];

                    for (int j = 0; j < broj_cvorova; j++)
                    {
                        if (skup[j] == staro)
                        {
                            skup[j] = novo;
                        }
                    }
                }
            }
            if (kp == 1)
            {
                Console.WriteLine("Graf je formirao najmanje povezano stablo: ");
            }
            else
            {
                Console.WriteLine("Graf je formirao najmanje povezanu sumu: ");
            }

            Console.WriteLine();
            Console.WriteLine($"Broj komponenti povezanosti: {kp}");
            Console.WriteLine($"Ukupna težina: {masa}");
            Console.WriteLine("\nGrane koje ulaze u sastav:");

            foreach (Grana grana_ispis in izabraneGrane)
            {
                Console.WriteLine(grana_ispis);
            }
        }
    }
}
