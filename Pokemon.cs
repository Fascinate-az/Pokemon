namespace Pokemon;

 using System.Threading.Channels;

class Program
{
    static void Main()
    {
        Pokemon pikachu = new Pokemon("Pikachu", "Elettro", 60);
        Pokemon Bulbasaur = new Pokemon("Bulbasaur", "Erba", 75);
        Pokemon Squirtle = new Pokemon("Squirtle", "Acqua", 70);
        Pokemon Onix = new Pokemon("Onix", "Roccia", "Terra", 80);

        SceltaPokemon();

        Pokemon SceltaPokemon()
        {
            Console.WriteLine(
                "Benvenuto per incominciare scegli uno di questi tre Pokemon\n1.Pikachu\n2.Bulbasaur\n3.Squirtle\n4.Esci");
            bool tryScelta = int.TryParse(Console.ReadLine(), out int sceltaPkm);
            bool loop = true;
            Pokemon pkmScelto = null;
            while (loop)
            {
                switch (sceltaPkm)
                {
                    case 1:
                        pkmScelto = pikachu;
                        Console.WriteLine($"Hai scelto {pikachu.nome} il pokemon di tipo elettro");
                        break;
                    case 2:
                        pkmScelto = Bulbasaur;
                        Console.WriteLine($"Hai scelto {Bulbasaur.nome} il pokemon di tipo erba");
                        break;
                    case 3:
                        pkmScelto = Squirtle;
                        Console.WriteLine($"Hai scelto {Squirtle.nome} il pokemon di tipo acqua");
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("errore nella scelta");
                        tryScelta = int.TryParse(Console.ReadLine(), out sceltaPkm);
                        break;
                }

                Avventura(pkmScelto);
                return pkmScelto;
                loop = false;
            }

            return null;
        }

        void Avventura(Pokemon pkmScelto)
        {
            Console.WriteLine(
                $"\"Ora che hai scelto il tuo primo Pokemon puoi incominciare la tua avventura,entrando nell'erba alta appare un {Onix.nome}\nVai {pkmScelto.nome}");
            BattagliaOFuga(pkmScelto);
        }

        void BattagliaOFuga(Pokemon pkmScelto)
        {
            Console.WriteLine("Cosa vuoi fare?\n1.Battaglia\n2.Fuga");
            bool tryBattaglia = int.TryParse(Console.ReadLine(), out int decisione);

            if (!tryBattaglia)
            {
                while (!tryBattaglia)
                {
                    Console.WriteLine("Errore nella scelta");
                    Console.WriteLine("Cosa vuoi fare?\n1.Battaglia\n2.Fuga");
                    tryBattaglia = int.TryParse(Console.ReadLine(), out decisione);
                }
            }

            if (decisione == 1)
            {
                Battaglia(pkmScelto);
            }
            else
            {
                Console.WriteLine("fuga veloce");
            }
        }

        void Battaglia(Pokemon pkmScelto)
        {
            while (Onix.hp > 0 && pkmScelto.hp > 0)
            {
                SceltaMosse(pkmScelto);
                if (Onix.hp > 0)
                {
                    EnemyAttack(pkmScelto);
                }
            }

            if (pkmScelto.hp > 0)
            {
                Console.WriteLine("hai vinto la battaglia");
            }
            else
            {
                Console.WriteLine("hai perso la battaglia");
            }
        }

        void ExitGame()
        {
            Environment.Exit(0);
        }

        void SceltaMosse(Pokemon pkmScelto)
        {
            if (pkmScelto == pikachu)
            {
                Console.WriteLine("sceglia la mossa da usare\n1.Fulmine\n2.Codacciao");
                bool scelta = int.TryParse(Console.ReadLine(), out int mossa);
                if (!scelta)
                {
                    while (!scelta)
                    {
                        Console.WriteLine("Errore nella scelta");
                        scelta = int.TryParse(Console.ReadLine(), out mossa);
                    }
                }

                switch (mossa)
                {
                    case 1:
                        pkmScelto.Fulmine(Onix);
                        break;
                    case 2:
                        pkmScelto.Codacciaio(Onix);
                        break;
                    default:
                        Console.WriteLine("scegliere una mossa");
                        break;
                }
            }
            else if (pkmScelto == Bulbasaur)
            {
                Console.WriteLine("sceglia la mossa da usare\n1.Semitraglia\n2.FoglieLama");
                bool scelta = int.TryParse(Console.ReadLine(), out int mossa);
                if (!scelta)
                {
                    while (!scelta)
                    {
                        Console.WriteLine("Errore nella scelta");
                        scelta = int.TryParse(Console.ReadLine(), out mossa);
                    }
                }

                switch (mossa)
                {
                    case 1:
                        Bulbasaur.Semitraglia(Onix);
                        break;
                    case 2:
                        Bulbasaur.FoglieLama(Onix);
                        break;
                    default:
                        Console.WriteLine("scegliere una mossa");
                        break;
                }
            }
            else if (pkmScelto == Squirtle)
            {
                Console.WriteLine("sceglia la mossa da usare\n1.Idropompa\n2.Azione");
                bool scelta = int.TryParse(Console.ReadLine(), out int mossa);
                if (!scelta)
                {
                    while (!scelta)
                    {
                        Console.WriteLine("Errore nella scelta");
                        scelta = int.TryParse(Console.ReadLine(), out mossa);
                    }
                }

                switch (mossa)
                {
                    case 1:
                        Squirtle.BasicAttackWater(Onix,80,"Acqua","Idropompa");
                        break;
                    case 2:
                        Squirtle.BasicAttackNormal(Onix,20,"Normale","Azione");
                        break;
                    default:
                        Console.WriteLine("scegliere una mossa");
                        break;
                }
            }
        }

        void EnemyAttack(Pokemon pkmScelto)
        {
            Onix.Sassata(pkmScelto);
        }

        
    }
}
 
