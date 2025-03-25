using System;
using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Net;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Principal;
using System.Text.Unicode;
using System.Threading.Channels;
using Coding.Exercise;

namespace Eser1;


class Program
{
     static void Main(string[] args)
     {
          Console.OutputEncoding = System.Text.Encoding.UTF8;
          Pokemon pikachu = new Pokemon("Pikachu",70,"Elettro");
          Pokemon charmender = new Pokemon("Charmender",75,"Fuoco");
          Pokemon bulbasaur = new Pokemon("Bulbasaur",85,"Erba");
          Pokemon squirtle = new Pokemon("Squirtle", 80, "Acqua");
          Pokemon Onix = new Pokemon("Onix", 120,"Terra","Roccia");
          Pokemon Pidgey = new Pokemon("Pidgey", 60,"Volante","Normale");
          Pokemon pkmAvversario = null;
          bool win = true;
          int numeroPozioni = 1;
          

          InizioAvventura();
          
          
           Pokemon InizioAvventura()
           { Pokemon pkmScelto = null;
               Console.WriteLine("Benvenuto nel mondo dei Pokemon, per incominciare la tua avventura scegli uno di questi 4 Pokemon:\n1.Pikachu\n2.Charmender\n3.Bulbasaur\n4.Squirtle\n5.Esci");
               bool scelta = int.TryParse(Console.ReadLine(),out int sceltaPkm);
               bool loop = true;

               if (!scelta)
               {
                    while (!scelta)
                    {
                         Console.WriteLine("Inserire una valore numerico tra 1 e 4");
                         scelta = int.TryParse(Console.ReadLine(),out sceltaPkm);
                    }
               }

               while (loop)
               {
                    switch (sceltaPkm)
                    {
                         case 1:
                              pkmScelto = pikachu;
                              Console.WriteLine($"hai scelto {pkmScelto.Name}, un Pokemon di tipo elettro");
                              loop = false;
                              break;
                         case 2:
                              pkmScelto = charmender;
                              Console.WriteLine($"hai scelto {pkmScelto.Name}, un Pokemon di tipo fuoco");
                              loop = false;
                              break;
                         case 3:
                              pkmScelto = bulbasaur;
                              Console.WriteLine($"hai scelto {pkmScelto.Name}, un Pokemon di tipo erba");
                              loop = false;
                              break;
                         case 4:
                              pkmScelto = squirtle;
                              Console.WriteLine($"hai scelto {pkmScelto.Name}, un Pokemon di tipo acqua");
                              loop = false;
                              break;
                         case 5:
                              Quit();
                              loop = false;
                              break;
                         default:
                              Console.WriteLine("errore nella scelta");
                              scelta = int.TryParse(Console.ReadLine(),out sceltaPkm);
                              break;
                    }
               }
               Console.WriteLine($"camminando nell'erba alta appare un {Pidgey.Name}\nVai {pkmScelto.Name} scelgo te");
               BattagliaPkm(pkmScelto,Pidgey);
               return pkmScelto;
          }
           

            void Quit()
           {
                Environment.Exit(0);
           }

            int SceltaMosse(Pokemon pkmScelto,Pokemon pkmAvversario)
           { 
                bool scelta = int.TryParse(Console.ReadLine(), out int sceltaMossa);
                bool loop = true;
                while (loop)
                {
                     if (pkmScelto == pikachu)
                     {
                          if (sceltaMossa < 1 || sceltaMossa > 4||!scelta)
                          {
                               Console.WriteLine("Errore nella scelta");
                               scelta = int.TryParse(Console.ReadLine(), out  sceltaMossa);
                          }
                          
                          else if (sceltaMossa == 4)
                          {
                               Zaino(pkmScelto,pkmAvversario);
                               loop = false;
                          }
                          
                          else 
                          {
                               string[] listaMossePikachu = new string[3] { "Fulmine ⚡⚡", "Tuono ⚡⚡⚡⚡", "Azione" };
                               int[] danniPikachu = new int[3] { 80, 120, 30 };
                               string[] tipi = new string[3] {"Elettro","Elettro","Normale"};
                               string tipoScelta = tipoScelta = tipi[sceltaMossa - 1];
                               string mossaScelta = listaMossePikachu[sceltaMossa - 1];
                               int danniPkm = danniPikachu[sceltaMossa - 1];

                               
                          
                               pkmScelto.Attacco(pkmAvversario,mossaScelta,danniPkm,tipoScelta);
                               loop = false;
                          }
                          
                          
                          
                          
                     }
                     else if (pkmScelto == bulbasaur)
                     {
                          if (sceltaMossa < 1 || sceltaMossa > 3||!scelta)
                          {
                               Console.WriteLine("Errore nella scelta");
                               scelta = int.TryParse(Console.ReadLine(), out  sceltaMossa);
                          }
                          
                          else if (sceltaMossa == 3)
                          {
                               Zaino(pkmScelto,pkmAvversario);
                               loop = false;
                          }
                          else
                          {
                               string[] listaMosseBulba = new string[2] { "FoglieLama", "Azione "};
                               int[] danniPikachu = new int[2] { 65,30 };
                               string[] tipi = new string[2] {"Erba","Normale"};
                               string tipoScelta = tipoScelta = tipi[sceltaMossa - 1];
                               string mossaScelta = listaMosseBulba[sceltaMossa - 1];
                               int danniPkm = danniPikachu[sceltaMossa - 1];

                               
                          
                               pkmScelto.Attacco(pkmAvversario,mossaScelta,danniPkm,tipoScelta);
                               loop = false;
                          }
                          
                     }
                     else if (pkmScelto == squirtle)
                     {
                          if (sceltaMossa < 1 || sceltaMossa > 4||!scelta)
                          {
                               Console.WriteLine("Errore nella scelta");
                               scelta = int.TryParse(Console.ReadLine(), out  sceltaMossa);
                          }
                          else if (sceltaMossa == 4)
                          {
                               Zaino(pkmScelto,pkmAvversario);
                               loop = false;
                          }
                          else
                          {
                               string[] listaMossePikachu = new string[3] { "Bolla","azione", "Idropompa "};
                               int[] danniPikachu = new int[3] {25,30,120 };
                               string[] tipi = new string[3] {"Acqua","normale","Acqua"};
                               string tipoScelta = tipoScelta = tipi[sceltaMossa - 1];
                               string mossaScelta = listaMossePikachu[sceltaMossa - 1];
                               int danniPkm = danniPikachu[sceltaMossa - 1];

                               
                          
                               pkmScelto.Attacco(pkmAvversario,mossaScelta,danniPkm,tipoScelta);
                               loop = false;
                          }
                                    
                               
                          
                          
                     }
                     else if (pkmScelto == charmender)
                     {
                               if (sceltaMossa < 1 || sceltaMossa > 3||!scelta)
                               {
                                    Console.WriteLine("Errore nella scelta");
                                    scelta = int.TryParse(Console.ReadLine(), out  sceltaMossa);
                               }
                               else if (sceltaMossa == 3)
                               {
                                    Zaino(pkmScelto,pkmAvversario);
                                    loop = false;
                               }
                               else
                               {
                                    string[] listaMosseChar = new string[2] { "LanciaFiamme 🔥🔥🔥🔥", "Azione "};
                                    int[] danniPikachu = new int[2] { 90,30 };
                                    string[] tipi = new string[2] {"Fuoco","Normale"};
                                    string tipoScelta = tipoScelta = tipi[sceltaMossa - 1];
                                    string mossaScelta = listaMosseChar[sceltaMossa - 1];
                                    int danniPkm = danniPikachu[sceltaMossa - 1];

                               
                          
                                    pkmScelto.Attacco(pkmAvversario,mossaScelta,danniPkm,tipoScelta);
                                    loop = false;
                               }
                               
                               
                     }
                     
                     
                }    
                return sceltaMossa;
           }

           void BattagliaPkm(Pokemon pkmScelto,Pokemon pkmAvversario )
           {
                while(pkmAvversario.Hp > 0 && pkmScelto.Hp > 0)
                {
                     if (pkmScelto == pikachu)
                     {
                          Console.WriteLine($"scegli cosa deve fare {pkmScelto.Name}\n1.Fulmine\n2.Tuono\n3.Azione\n4.Zaino");
                     }
                     else if(pkmScelto == bulbasaur)

                     {
                          Console.WriteLine($"scegli cosa deve fare {pkmScelto.Name}\n1.FoglieLama\n2.Azione\n3.Zaino"); 
                     }
                     else if (pkmScelto == squirtle)
                     {
                          Console.WriteLine($"scegli cosa deve fare {pkmScelto.Name}\n1.Bolla\n2.Azione\n3.Idropompa\n4.Zaino\"");
                     }
                     else if (pkmScelto == charmender)
                     {
                          Console.WriteLine($"scegli cosa deve fare {pkmScelto.Name}\n1.LanciaFiamme\n2.Azione\n3.Zaino");
                     }
                     SceltaMosse(pkmScelto,pkmAvversario);
                     if (pkmAvversario.Hp > 0)
                     {
                          
                          EstraiMossaRandom(pkmScelto,pkmAvversario);
                     }
                     
                     
                }
                if (pkmScelto.Hp > 0 && pkmAvversario.Hp  <= 0)
                {
                     Console.WriteLine("HAI VINTO LA BATTAGLIA");
                     win = true;
                }

                else
                {
                     Console.WriteLine($"HAI PERSO LA BATTAGLIA,IL TUO {pkmScelto.Name} è KO");
                     win = false;
                }

                Continua(win, pkmScelto);



           }

           void EstraiMossaRandom(Pokemon pkmScelto,Pokemon pkmAvversario )
           {
                Random rnd = new Random();
                int estrai = rnd.Next(1, 10);

                if (pkmAvversario == Pidgey)
                {
                     if (estrai > 0 && estrai <= 5)
                     {
                          Pidgey.Attacco(pkmScelto, "Azione", 30,"Normale");
                     }
                     else if (estrai > 5 && estrai <= 8)
                     {
                          Pidgey.Attacco(pkmScelto, "Attacco D'Ala", 40,"Volante");
                     }
                     else
                     {
                          Pidgey.Attacco(pkmScelto, "Tornado", 75,"Drago");
                     }  
                }
                else if (pkmAvversario == Onix)
                {
                     if (estrai > 0 && estrai <= 5)
                     {
                          Onix.Attacco(pkmScelto, "Azione", 30,"Normale");
                     }
                     else if (estrai > 5 && estrai <= 10)
                     {
                          Onix.Attacco(pkmScelto, "Sassata", 35,"Roccia");
                     }
                }

                
           }
           void Continua(bool vero,Pokemon pkmScelto)
           {
                if (vero == true)
                {
                     PrimoAllenatore(pkmScelto);
                }
           }

           void PrimoAllenatore(Pokemon pkmScelto)
           {
                string[] Nomi = new string[5] { "Luca", "Marco", "Gennaro", "Jonny", "Alessandro" };
                string[] categoriaAllenatore = new string[4] {"Pokéfanatico","Avventuriero","Bullo","Campeggista", };
                Random rnd = new Random();
                Random rnd2 = new Random();
                var estrattoNome = Nomi[rnd.Next(0, Nomi.Length)];
                var estrattoCategoria = categoriaAllenatore[rnd2.Next(0,categoriaAllenatore.Length)];
                Console.WriteLine("Premi un tasto qualsiasi per continuare la tua avventura ........");
                Console.ReadKey();
                Console.WriteLine($"Dopo aver vinto la prima battaglia contro un Pokemon selvatico incontri un altro allenatore come te che ti sfida.\n{estrattoNome} {estrattoCategoria} sceglie {Onix.Name} ");
                BattagliaPkm(pkmScelto,Onix);
           }

           void Zaino(Pokemon pkmScelto,Pokemon pkmAvversario)
           {
                List<string> strumenti = new List<string>() { "Pozione", "Amo Da Pesca", "Hamburger", "bicletta" };
                int counter = 1;
                bool loop = true;
                Console.WriteLine("Scegli cosa fare:");
                foreach (var item in strumenti)
                {
                     Console.WriteLine($"{counter}: {item}");
                     counter++;
                }
                bool scelta = int.TryParse(Console.ReadLine(), out int numeroStrumento);

                while (loop)
                {
                     switch (numeroStrumento)
                     {
                          case 1:
                               if (numeroPozioni == 1)
                               {
                                    pkmScelto.StrumentoCuraHp(pkmScelto,20,"Pozione");
                                    numeroPozioni++;
                                    Console.WriteLine(numeroPozioni);
                                    loop = false;   
                               }
                               else
                               {
                                    Console.WriteLine("Hai esaurito le pozioni");
                                    BattagliaPkm(pkmScelto,pkmAvversario);
                                    
                                    
                               }
                               
                               break;
                          case 2:
                          case 3:
                          case 4: 
                               Console.WriteLine("C'è un luogo e un momento per ogni cosa,ma non ora!");
                               scelta = int.TryParse(Console.ReadLine(), out numeroStrumento);
                               break;
                          default:
                               Console.WriteLine("Errore nella scelta");
                               scelta = int.TryParse(Console.ReadLine(), out numeroStrumento);
                               break;
                     }
                }
                
               
                 

                
           }
           
     }
     
     
     
}

