//############ Very Simple Turn Based Battle System ############//
//############# Made By : @DevPrionTeam - DJ.Next  #############// 
//######## It's free to use as base for your projects ;) #######//
using System;
using RPGBattleSystem.Sys;

namespace RPGBattleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Window Setup
            Console.Title = "Simple and basic RPG Turn Based Battle.";
            Game game = new Game();// Init Class
            game.Start();// Start Game.
        }
    }
}
//###############################################################//