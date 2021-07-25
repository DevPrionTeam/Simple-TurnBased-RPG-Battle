//############ Very Simple Turn Based Battle System ############//
//############# Made By : @DevPrionTeam - DJ.Next  #############// 
//######## It's free to use as base for your projects ;) #######//
using System;

namespace RPGBattleSystem.Sys.Player
{
    public class Character 
    {
        private string pName { get; set; }
        private byte pLvl { get; set; }
        private int pExp { get; set; }
        private byte pPower { get; set; }
        private int pHp { get; set; }

        public Character() {
            setPlayerLevel(1);// player level
            setPlayerExp(0);// player experience
            setPlayerPower(7);// player damage
            setPlayerHp(45);// player hp
        }// Player initiation [...]

        #region Player Incapsulation [...]
        public void setPlayerName(string name) { this.pName = name; }
        public string getPlayerName() { return this.pName; }
        public void setPlayerLevel(byte lvl) { this.pLvl = lvl; }
        public byte getPlayerLevel() { return this.pLvl; }
        public void setPlayerExp(int xp) { this.pExp += xp; }
        public void setPlayerPower(byte pow) { this.pPower = pow; }
        public byte getPlayerPower() { return this.pPower; }
        public void setPlayerHp(int hp) { this.pHp = hp; }
        public int getPlayerHp() { return this.pHp; }
        #endregion
    }
}
