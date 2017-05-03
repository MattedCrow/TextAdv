using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class CombatEngine : GameEngine
    {
        private Die d6_1, d6_2, d6_3, d6_4, d6_5, d6_6;

        public bool fightStart = false;

        private string _outputString;
        private string OutputString
        {
            get { return _outputString; }
        }

        public CombatEngine()
        {
            _outputString = "Boop";
            d6_1 = new Die(6);
            d6_2 = new Die(6);
            d6_3 = new Die(6);
            d6_4 = new Die(6);
            d6_5 = new Die(6);
            d6_6 = new Die(6);
        } 
        
        int atkRoll, defRoll, atkDamage;

        public void DoATK(out string response, out string roundResults)
        {
            response = "\n";
            roundResults = "\n";
            Player.getInfo();

            if (World.inBattle == true)
            {
                // Use speed to determine who goes first
                int atkSPD = Player.SPD + roll3d6();
                int MonSPD = Monster.SPD + roll3d6();
                if (atkSPD > MonSPD || atkSPD == MonSPD)
                {
                    // Player attacks first
                    string attackPlayerResults, defendDefendResults;
                    PlayerATK(out attackPlayerResults);
                    if (Monster.HLT > 0)
                    {
                        MonsterATK(out defendDefendResults);
                        response = attackPlayerResults + defendDefendResults + "\n";
                        roundResults = "\nPlayer " + Player.Name + " now has " + Player.HLT + " health. \nMonster "
                            + Monster.Name + " now has " + Monster.HLT + " health. \n";
                    }
                    else
                    {
                        response = attackPlayerResults + "\n";
                    }

                }
                else if (MonSPD > atkSPD)
                {
                    string defendPlayerResults, attackMonsterResults;
                    // Monster attacks first
                    MonsterATK(out attackMonsterResults);
                    if (Player.HLT > 0)
                    {
                        PlayerATK(out defendPlayerResults);

                        response = attackMonsterResults + defendPlayerResults + "\n";
                        roundResults = "\nPlayer " + Player.Name + " now has " + Player.HLT + " health. \nMonster "
                            + Monster.Name + " now has " + Monster.HLT + " health. \n";
                    }
                    else
                    {
                        response = attackMonsterResults + "\n";
                    }

                }
            }
        }

        public void PlayerATK(out string attackResults)
        {
            atkRoll = Player.ATK + roll3d6();
            defRoll = Monster.DEF + defenderRoll3d6();

            if (atkRoll > defRoll)
            {
                Player.DamageDie1.roll();
                atkDamage = Player.DamageDie1.DieResultA;
                Monster.HLT = Monster.HLT - atkDamage;
                attackResults = Player.Name + " attacked the enemy " + Monster.Name + " for " + atkDamage + " damage!\n";

                if (Monster.HLT <= 0)
                {
                    attackResults += Player.Name + " has defeated the enemy " + Monster.Name + "!\n";
                }
                else
                {
                    attackResults = Player.Name + " attacked the enemy " + Monster.Name + " for " + atkDamage + " damage!\n";
                }
            }
            else
            {
                attackResults = Player.Name + " missed!\n";
            }
        }

        public void MonsterATK(out string defendResults)
        {
            atkRoll = Monster.ATK + defenderRoll3d6();
            defRoll = Player.DEF + roll3d6();

            if (atkRoll > defRoll)
            {
                Monster.DamageDie2.roll();
                atkDamage = Monster.DamageDie2.DieResultB;
                Player.HLT = Player.HLT - atkDamage;
                defendResults = Monster.Name + " attacked the player, " + Player.Name + " for " + atkDamage + " damage!\n";

                if (Player.HLT <= 0)
                {
                    defendResults += Monster.Name + " has defeated the player, " + Player.Name + "!\n";
                    gameLost = true;
                }
                else
                {
                    defendResults = Monster.Name + " attacked the player, " + Player.Name + " for " + atkDamage + " damage!\n";
                }
            }
            else
            {
                defendResults = Monster.Name + " missed!\n";
            }
        }

        public int roll3d6()
        {
            d6_1.roll();
            d6_2.roll();
            d6_3.roll();

            int result = d6_1.DieResultA + d6_2.DieResultA + d6_3.DieResultA;
            return result;
        }
        public int defenderRoll3d6()
        {
            d6_4.roll();
            d6_5.roll();
            d6_6.roll();

            int result = d6_1.DieResultB + d6_2.DieResultB + d6_3.DieResultB;
            return result;
        }
    }
}
