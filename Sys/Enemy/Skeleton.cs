//############ Very Simple Turn Based Battle System ############//
//############# Made By : @DevPrionTeam - DJ.Next  #############// 
//######## It's free to use as base for your projects ;) #######//
using System;

namespace RPGBattleSystem.Sys.Enemy
{
    public class Skeleton
    {
        private string eName { get; set; }
        private byte eLvl { get; set; }
        private byte ePower { get; set; }
        private int eHp { get; set; }

        public Skeleton()
        {
            setEnemyName("Sworded Skeleton");
            setEnemyLevel(1);// Enemy level
            setEnemyPower(7);// enemy damage
            setEnemyHp(20);// enemy hp
        }// Enemy initiation [...]

        #region Enemy Encapsulation [...]
        public void setEnemyName(string name) { this.eName = name; }
        public string getEnemyName() { return this.eName; }
        public void setEnemyLevel(byte lvl) { this.eLvl = lvl; }
        public byte getEnemyLevel() { return this.eLvl; }
        public void setEnemyPower(byte pow) { this.ePower = pow; }
        public byte getEnemyPower() { return this.ePower; }
        public void setEnemyHp(int hp) { this.eHp = hp; }
        public int getEnemyHp() { return this.eHp; }
        #endregion
    }
}
