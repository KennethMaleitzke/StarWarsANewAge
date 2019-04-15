using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsANewAge.Models
{
    public class Weapons : GameItem
    {
        public int MinimumDamage { get; set; }
        public int MaximunDamage { get; set; }

        public Weapons(int id, string name, int value, int minDamage, int maxDamage, string description, int experiencePoints)
            : base(id, name, value, description, experiencePoints)
        {
            MinimumDamage = minDamage;
            MaximunDamage = MaximunDamage;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}\nDamage: {MinimumDamage}-{MaximunDamage}";
        }
    }
}
