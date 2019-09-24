using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKD_Sokaban.view
{
    public class StartView
    {
        Controller localController;
        public StartView(Controller controller)
        {
            localController = controller;
            ShowStartView();
        }

        public void ShowStartView()
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("|  Welkom bij Sokoban                 |");
            Console.WriteLine("|                                     |");
            Console.WriteLine("|  Gebruiksaanwijzingen               |");
            Console.WriteLine("|                                     |");
            Console.WriteLine("|  █ : muur                           |");
            Console.WriteLine("|  . : vloer                          |");
            Console.WriteLine("|  o : krat                           |");
            Console.WriteLine("|  0 : krat op bestemming             |");
            Console.WriteLine("|  x : bestemming                     |");
            Console.WriteLine("|  @ : speler                         |");
            Console.WriteLine("+-------------------------------------+");

            Console.Write("Kies een doolhof (1-6), s = stop: ");

            localController.StartViewInput(Console.ReadLine());
        }


    }
}
