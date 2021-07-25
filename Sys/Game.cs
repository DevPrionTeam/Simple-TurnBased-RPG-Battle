//############ Very Simple Turn Based Battle System ############//
//############# Made By : @DevPrionTeam - DJ.Next  #############// 
//######## It's free to use as base for your projects ;) #######//
using System;
using System.Threading;
using RPGBattleSystem.Sys.Player;
using RPGBattleSystem.Sys.Enemy;

namespace RPGBattleSystem.Sys
{
    public class Game
    {
        // Instantiations.
        private Character player = new Character();
        private Skeleton enemy = new Skeleton();

        // System/Game Vars
        private string choise;// Variable to make choises.
        private bool yourTurn;// Decides if it's your turn or not.
        private bool canFlee;// variable to make the game let you flee from battle or not
        Random rand = new Random();// Variable to make random decisions

        public void Start()
        {
            // Init Player's info.
            Console.WriteLine("[System] Welcome to a very simple turn based battle system. ");
            Thread.Sleep(2500);// Wait 2.5 secs
            Console.Write("[System] Before we continue our game, please, tell me your name  >  ");
            player.setPlayerName(Console.ReadLine());
            Thread.Sleep(2000);// Wait 2 secs

            // Introdution
            Console.WriteLine("[System] Hello " + player.getPlayerName() + " !");
            Console.WriteLine("[System] Now.. Let's begin the game " + player.getPlayerName() + ". Good Luck ! ^-^\n\n\n");
            Thread.Sleep(5000);// Wait 5 secs

            // Battle question.
            Console.WriteLine("[System] You faced a Skeleton. Battle it ? "); Choises:;// Choises return label.
            Console.Write("1 - Yes , 2 - No : ");
            choise = Console.ReadLine();

            switch (choise)
            {
                case "1":
                        Console.WriteLine("[System] Understood, Initiating battle now... \n\n\n");
                        Thread.Sleep(3500);// Wait 3.5secs.
                        
                        ReInitBattle:;// Battle restart label.
                        
                        // Variables of chances.
                        int chance = rand.Next(0, 100);// Chance of attack first
                        int fleeChance = rand.Next(0, 100);// chance of flee from enemy

                        // Deciding if you do the initial attack or not based on probability.
                        if (chance <= 50) {
                            // Porbability of 50%
                            yourTurn = true;
                        } else { 
                            yourTurn = false;
                        }

                        // Let's Battle !
                        Battle:;// Return to battle gui Label
                        if(yourTurn && enemy.getEnemyHp() > 0) {
                            Console.WriteLine("----------------------- BATTLE -----------------------------\n");
                            Console.WriteLine("[Battle] It's a " + enemy.getEnemyName() + " !");
                            Console.WriteLine("[Battle] He has " + enemy.getEnemyHp() + " HP, What you gonna do ?\n");
                            Console.WriteLine("------------------------------------------------------------\n");
                            Console.WriteLine("Lvl : " + player.getPlayerLevel() + "  HP : " + player.getPlayerHp() + " ");
                            Console.Write("[ 1. Attack ]    -    [ 2. Flee ]   >  ");
                            choise = Console.ReadLine();
                            Console.WriteLine("------------------------------------------------------------\n\n");

                            switch (choise) {
                                case "1":// Attack
                                        Thread.Sleep(1700);
                                        Console.WriteLine("[Battle] " + player.getPlayerName() + " Decided to attack " + enemy.getEnemyName() + " !");
                                        Thread.Sleep(1700);
                                        Console.WriteLine("[Battle] " + player.getPlayerName() + " Dealed " + player.getPlayerPower() + " Damage to " + enemy.getEnemyName() + " !\n");
                                    
                                        // Process the damage 
                                        enemy.setEnemyHp(Convert.ToInt32(enemy.getEnemyHp() - player.getPlayerPower()));//Set a new hp value with damage dealed.
                                        yourTurn = false;
                                    goto Battle;

                                case "2":
                                    if (chance <= 30) {
                                        // Porbability of 42%
                                        canFlee = true;
                                    } else {
                                        canFlee = false;
                                    }
                                    if(canFlee) {
                                        Console.WriteLine("[System] You fleed from battle. Press any key to quit the game.");
                                    } else { 
                                        Console.WriteLine("[System] You didn't managed to scape the enemy.\n");
                                        Thread.Sleep(2000);
                                        yourTurn = false; 
                                        goto Battle; 
                                    } 
                                    break;
                            }
                        } else if(!yourTurn && enemy.getEnemyHp() > 0) {
                            // Enemy try to attack player.
                            Console.WriteLine("[Battle] " + enemy.getEnemyName() + " Decided to attack " + player.getPlayerName() + " !");
                            Thread.Sleep(1700);
                            Console.WriteLine("[Battle] " + enemy.getEnemyName() + " Dealed " + enemy.getEnemyPower() + " !\n");
                            player.setPlayerHp(Convert.ToInt32(player.getPlayerHp() - enemy.getEnemyPower()));// set a new hp value for player with damage dealed.
                            Thread.Sleep(2000);
                            yourTurn = true;// set player's turn to true.
                            goto Battle;

                        } else if (yourTurn || !yourTurn && enemy.getEnemyHp() <= 0) {
                            Console.WriteLine("[Battle] " + player.getPlayerName() + " has defeated " + enemy.getEnemyName() + " !");
                            Thread.Sleep(1000);
                            Console.WriteLine("[Battle] " + player.getPlayerName() + " gained +12 XP.\n");
                            player.setPlayerExp(12);// adds 12 of xp to player.
                            
                            Thread.Sleep(3000);
                            Console.WriteLine("[System] Thank You so much for playing this simple game !");
                            Console.WriteLine("[System] Press any key to quit the game.");

                        } else if (yourTurn && player.getPlayerHp() <= 0) { 
                            Console.WriteLine("[Battle] " + player.getPlayerName() + " was defeated by " + enemy.getEnemyName() + " !");
                            Thread.Sleep(3000);
                            Console.WriteLine("[System] You lose...");
                            Thread.Sleep(3000);

                            diedChoise:;// choise reset if selected wrong.
                            Console.WriteLine("[System] " + player.getPlayerName() + " you have a chance of revenge. Do you agree ?");
                            Console.Write("1. Yes    or    2. No  > ");
                            choise = Console.ReadLine();
                            
                            // choise handle
                            switch(choise) {
                                case "1":
                                    Thread.Sleep(1000);
                                    Console.WriteLine("[system] Restarting the battle !");
                                goto ReInitBattle;

                                case "2":
                                    Console.WriteLine("[System] You lose...");
                                    Thread.Sleep(3000);
                                    Console.WriteLine("[System] Thank You so much for playing this simple game !");
                                    Console.WriteLine("[System] Press any key to quit the game.");
                                break;

                                default:
                                    Console.WriteLine("[System] This option doesn't exist, please select a valid one.\n");
                                goto diedChoise;
                            }
                        }
                    break;

                case "2":
                        Console.WriteLine("[System] You fleed from battle. Press any key to quit the game.");
                    break;

                default:
                        Console.WriteLine("[System] This option doesn't exist, Please select a valid one.\n");
                    goto Choises;
            }
            Console.ReadKey();
        }
    }
}
