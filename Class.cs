namespace Pokemon;

class Pokemon
{
    public  string nome ;
    public string tipo ;
    public string tipo2;
    public int hp ;
    
    public Pokemon(string nome, string tipo, int hp)
    {
     this.nome = nome;
     this.tipo = tipo; 
     this.hp = hp;
    }
    
    public Pokemon(string nome, string tipo,string tipo2, int hp)
    {
        this.nome = nome;
        this.tipo = tipo; 
        this.tipo2 = tipo2;
        this.hp = hp;
    }
    

    public int Fulmine(Pokemon opponent)
    {
        Console.WriteLine($"{nome} lancia fulmine");
        string tipoMoves = "Elettro";
        int damage = 70;
        if (opponent.tipo == "Acqua" || opponent.tipo2 == "Acqua")
        {
            damage = damage * 2;
            
        }
        else if (opponent.tipo == "Terra"|| opponent.tipo2 == "Terra")
        {
            damage = damage * 0;
            Console.WriteLine("Non ha effetto");
        }
        opponent.hp -= damage;
        StatBattaglia(opponent, damage, opponent.hp);

        opponent.hp -= damage;
        return  opponent.hp ;
    }

    public int Semitraglia(Pokemon opponent)
    {
        Console.WriteLine($"{nome} lancia semitraglia");
        Random tiri = new Random();
        string tipoMoves = "Erba";
        int BaseDamage = 15;
        int damage = 0;
        int counter = 0;
        int lancio = tiri.Next(1, 10); Console.WriteLine($"lancio {counter}");
        if (opponent.tipo == "Roccia" || opponent.tipo2 == "Terra")
        {
            BaseDamage *=2;


        }
        do
        {
            counter++;
            lancio = tiri.Next(1, 10);
            Console.WriteLine($"lancio {counter}");

            damage += BaseDamage;
            opponent.hp -= damage;

        } while (counter <4 && lancio >= 4 );
        opponent.hp -= damage;
        StatBattaglia(opponent, damage, opponent.hp);
        return opponent.hp;
    }

    public int Codacciaio(Pokemon opponent)
    {
        Console.WriteLine($"{nome} usa codacciaio");
        string tipoMoves = "Acciaio";
        int damage = 70;
        

        if (opponent.tipo == "Roccia")
        {
            damage = damage * 2;
            
        }
        
        opponent.hp -= damage;
        StatBattaglia(opponent, damage, opponent.hp);

        return opponent.hp;
    }

    public int FoglieLama(Pokemon opponent)
    {
        int damage = 50;
        string tipoMoves = "Erba";
        Console.WriteLine($"{nome} usa foglieLama");

        if (opponent.tipo == "Roccia" || opponent.tipo2 == "Terra")
        {
            damage = damage * 2;
        }
        opponent.hp -= damage;
        StatBattaglia(opponent,damage,opponent.hp);
        return opponent.hp;
    }

    public int Sassata(Pokemon opponent)
    {
        int damage = 70;
        string tipoMoves = "Roccia";
        Console.WriteLine($"{nome} usa Sassata");
        
        opponent.hp -= damage;
        StatBattaglia(opponent, damage, opponent.hp);
        return opponent.hp;
        
    }

    public int BasicAttackWater(Pokemon opponent, int danni,string tipoMossa,string nomeMossa )
    {
        int damage = danni;
        string tipoMoves = tipoMossa;
        Console.WriteLine($"{nome} usa {nomeMossa}");
        if (opponent.tipo == "Roccia" || opponent.tipo2 == "Terra")
        {
            damage = damage * 2;
        }
        opponent.hp -= damage;
        StatBattaglia(opponent, damage, opponent.hp);
        return opponent.hp;
    }

    public int BasicAttackNormal(Pokemon opponent, int danni, string tipoMossa, string nomeMossa)
    {
        int damage = danni;
        string tipoMoves = tipoMossa;
        Console.WriteLine($"{nome} usa {nomeMossa}");
        if (opponent.tipo == "Roccia" || opponent.tipo2 == "Acciaio")
        {
            damage = damage / 2;
            Console.WriteLine("non è molto efficace");
        }

        StatBattaglia(opponent, damage, opponent.hp);
        opponent.hp -= damage;
        return opponent.hp;
    }

    public void StatBattaglia(Pokemon opponent, int damage, int totale)
    {
        if (opponent.hp> 0)
        {
            Console.WriteLine($"fa un danno di {damage} , {opponent.nome} ora ha {opponent.hp} Hp.");
        }

        else
        {
            Console.WriteLine($"fa un danno di {damage} , {opponent.nome} è KO");
        }
        
}
}
