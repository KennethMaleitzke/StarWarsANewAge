﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsANewAge.Models
{
    public class Citizen : Npc, ISpeak
    {
        Random r = new Random();

        public List<string> Messages { get; set; }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public Citizen()
        {

        }

        public Citizen(int id, string name, RaceType race, string description, List<string> messages)
            :base(id, name, race, description)
        {
            Messages = messages;
        }

        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        private string GetMessage()
        {
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }
    }
}
