using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Threading.Channels;

namespace Coding.Exercise
{
    class Pokemon
    {
        public string Name { get; }
        public int Hp { get; private set; }
        public string Type { get; }
        public string Type2 { get; }
        public string TipoMossa { get; private set; }
        public static int counter = 0;
        private static Random rng = new Random();
        

        public Pokemon(string name,int hp,string type)
        {
            this.Name = name;
            this.Hp = hp;
            this.Type = type;
            counter++;
        }
        public Pokemon(string name,int hp,string type,string type2)
        {
            this.Name = name;
            this.Hp = hp;
            this.Type = type;
            this.Type2 = type2;
            counter++;
        }
        public int Attacco(Pokemon opponent, string nomeMossa, int damage, string tipoMossa)
{
    Console.WriteLine($"{Name} usa {nomeMossa} su {opponent.Name}");

    // Verifica superefficacia
    if ((tipoMossa == "Elettro" && (opponent.Type == "Volante" || opponent.Type2 == "Volante" ||
                                    opponent.Type == "Acqua" || opponent.Type2 == "Acqua")) ||
        (tipoMossa == "Erba" && (opponent.Type == "Acqua" || opponent.Type2 == "Acqua" ||
                                 opponent.Type == "Terra" || opponent.Type2 == "Terra" ||
                                 opponent.Type == "Roccia" || opponent.Type2 == "Roccia")) ||
        (tipoMossa == "Drago" && (opponent.Type == "Drago" || opponent.Type2 == "Drago")) ||
        (tipoMossa == "Volante" && (opponent.Type == "Erba" || opponent.Type2 == "Erba")) ||
        (tipoMossa == "Fuoco" && (opponent.Type == "Erba" || opponent.Type2 == "Erba" ||
                                  opponent.Type == "Acciaio" || opponent.Type2 == "Acciaio")) ||
        (tipoMossa == "Acqua" && (opponent.Type == "Roccia" || opponent.Type2 == "Roccia" ||
                                  opponent.Type == "Terra" || opponent.Type2 == "Terra")) ||
        (tipoMossa == "Acciaio" && (opponent.Type == "Roccia" || opponent.Type2 == "Roccia")) ||
        (tipoMossa == "Roccia" && (opponent.Type == "Volante" || opponent.Type2 == "Volante" ||
                                   opponent.Type == "Fuoco" || opponent.Type2 == "Fuoco")))
    {
        damage *= 2;
        Console.WriteLine("È superefficace!");
    }
    // Verifica inefficacia
    else if ((tipoMossa == "Elettro" && (opponent.Type == "Elettro" || opponent.Type2 == "Elettro")) ||
             (tipoMossa == "Normale" && (opponent.Type == "Roccia" || opponent.Type2 == "Roccia" ||
                                         opponent.Type == "Acciaio" || opponent.Type2 == "Acciaio")) ||
             (tipoMossa == "Volante" && (opponent.Type == "Acciaio" || opponent.Type2 == "Acciaio" ||
                                         opponent.Type == "Elettro" || opponent.Type2 == "Elettro" ||
                                         opponent.Type == "Roccia" || opponent.Type2 == "Roccia")) ||
             (tipoMossa == "Fuoco" && (opponent.Type == "Fuoco" || opponent.Type2 == "Fuoco" ||
                                       opponent.Type == "Acqua" || opponent.Type2 == "Acqua" ||
                                       opponent.Type == "Roccia" || opponent.Type2 == "Roccia" ||
                                       opponent.Type == "Drago" || opponent.Type2 == "Drago")) ||
             (tipoMossa == "Erba" && (opponent.Type == "Volante" || opponent.Type2 == "Volante")) ||
             (tipoMossa == "Roccia" && (opponent.Type == "Acciaio" || opponent.Type2 == "Acciaio" ||
                                        opponent.Type == "Terra" || opponent.Type2 == "Terra")))
    {
        damage /= 2;
        Console.WriteLine("Non è molto efficace...");
    }
    // Verifica nessun effetto
    else if ((tipoMossa == "Elettro" && (opponent.Type == "Terra" || opponent.Type2 == "Terra")) ||
             (tipoMossa == "Normale" && (opponent.Type == "Spettro" || opponent.Type2 == "Spettro")))
    {
        damage = 0;
        Console.WriteLine($"Non ha effetto su {opponent.Name}!");
    }

    // Applica il danno
    opponent.Hp -= damage;
    int HpRimasti = opponent.Hp;

    Console.WriteLine($"{Name} infligge {damage} danni a {opponent.Name}!");

    // Controlla se l'avversario è K.O.
    CheckDeathOpponent(opponent, HpRimasti);
    

    return HpRimasti;
}

        private bool Paralisi(Pokemon Opponent, string tipoMossa)
        {
            bool status = false;
            if (tipoMossa == "Elettro" && Opponent.Type != "Terra" && (Opponent.Type2 == null || Opponent.Type2 != "Terra"))
            {
                
                int paralisi = rng.Next(1,10);
                if (paralisi >0 && paralisi <=3)
                { 
                    status = true;
                    
                }
            }

            return status;
        }//Da applicare

        private int UsaRandomMove(Pokemon opponent, string nomeMossa, int damage)
        {
            int danno = damage;
            Console.WriteLine($"{Name} usa {nomeMossa} su {opponent.Name}");
            int HpRimasti = opponent.Hp -= damage;
            CheckDeathOpponent(opponent,HpRimasti);
            return HpRimasti;
        }
        private void CheckDeathOpponent(Pokemon opponent,int hpRimasti)
        {
            if (hpRimasti > 0)
            {
                Console.WriteLine($"{opponent.Name} ha {opponent.Hp} punti Vita");
            }
            else
            {
                Console.WriteLine($"{opponent.Name} è KO");
                
            }
            
                
        }

        public int StrumentoCuraHp (Pokemon pkmDaCurare,int hpDaRecuperare,string nomeStrumento)
        {
            pkmDaCurare.Hp += hpDaRecuperare;
            Console.WriteLine($"Usa {nomeStrumento} per recuperare {hpDaRecuperare}Hp\n{Name} ora ha {pkmDaCurare.Hp} hp");

            int hpRimasti = pkmDaCurare.Hp;
            
            return hpRimasti;

        }
        

        
        
        
        
    }
 
    
    
    
    
}
