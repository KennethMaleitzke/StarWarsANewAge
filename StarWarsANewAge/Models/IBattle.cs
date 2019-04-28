using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsANewAge.Models
{
    public interface IBattle
    {
        int SkillLevel { get; set; }
        Weapons CurrentWepaon { get; set; }
        BattleModeName BattleMode { get; set; }

        int Attack();
        int Defend();
        int Retreat();
    }
}
