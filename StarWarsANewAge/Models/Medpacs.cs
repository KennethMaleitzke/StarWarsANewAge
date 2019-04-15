using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsANewAge.Models
{
    public class Medpacs : GameItem
    {
        public int HealthChange { get; set; }

        public Medpacs(int id, string name, int value, int healthChange, string description, int experiencePoints) 
            : base(id, name, value, description, experiencePoints)
        {
            HealthChange = healthChange;
        }

        public override string InformationString()
        {
            if (HealthChange != 0)
            {
                return $"{Name}: {Description}\nHealth: {HealthChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }
    }
}
