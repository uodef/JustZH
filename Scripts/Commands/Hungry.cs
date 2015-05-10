﻿using System;
using Server.Mobiles;

namespace Server.Commands
{
    public class Hungry
    {
        public static void Initialize()
        {
            CommandSystem.Register("hungry", AccessLevel.Player, new CommandEventHandler(Classe_OnCommand));
        }

        

        [Usage("hungry")]
        [Description("Returns the players hunger level.")]
        private static void Classe_OnCommand(CommandEventArgs e)
        {
            bool debug = true;

            string retString = "Hunger isnt working as intended :(";
            Mobile m = e.Mobile;

            var hungerLevel = m.Hunger;
            if(debug)Console.WriteLine(hungerLevel);
            if (hungerLevel == 20) // hunger should always be 20. But im not 100% certain yet
            {
                retString = "You're stuffed!";
            }
            
            e.Mobile.SendMessage(retString);

        }
    }
}