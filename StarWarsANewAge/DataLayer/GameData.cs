using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsANewAge.Models;
using System.Collections.ObjectModel;

namespace StarWarsANewAge.DataLayer
{
    public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Doggard",
                Age = 43,
                JobTitle = Player.JobTitleName.Jedi,
                Race = Character.RaceType.Human,
                Health = 100,
                Credits = 100,
                ExperiencePoints = 0,
                LocationId = 0
            };
        }

        public static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }
        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                $"\tYou are a (job title here) set out on your mission to make the galaxy a better place.",
                "\tYou were found at a very young age and are destined to be one of the greatest force users in the galaxy. You will use your ship to travel to many planets and travel around the planets to comeplete your missions."
            };
        }
        public static Location InitialGameMapLocation()
        {
            return new Location()
            {

                Id = 4,
                Name = "Base of Operations",
                Description = "The main base of operations is where you will recieve intel about a certain objective " +
                "and what you need to do to accomplish your mission. You and your team will make the Galaxy a better place " +
                "one piece at a time.",
                Accessible = true,
                ModifyExperiencePoints = 10

            };
        }

        public static Map GameMapData()
        {

            Map gameMap = new Map();

            gameMap.StandardGameItems = StandardGameItems();

            gameMap.Location = new ObservableCollection<Location>()
            {
                 new Location()
                 {
                     Id = 4,
                    Name = "Base of Operations",
                    Description = "The main base of operations is where you will recieve intel about a certain objective " +
                    "and what you need to do to accomplish your mission. You and your team will make the Galaxy a better place " +
                    "one piece at a time.",
                    Accessible = true,
                    ModifyExperiencePoints = 10
                 },
                 new Location()
                 {
                    Id = 1,
                    Name = "Florian Swamp",
                    Description = "The Florian Swamp  is filled with mud, dirty looking water and deadly creatures " +
                    "The Florian Swamp is also a big battle field between the Republic and Imperials and has claimed many " +
                    "lives over the years.",
                    Accessible = true,
                    ModifyExperiencePoints = 10
                 }
            };

            //
            // row 1
            //
            //gameMap.MapLocations[0, 0] =;
            //gameMap.MapLocations[0, 1] = new Location()
            //{
            //    Id = 1,
            //    Name = "Aion Base Lab",
            //    Description = "The Norlon Corporation research facility located in the city of Heraklion on " +
            //    "the north coast of Crete and the top secret research lab for the Aion Project.\nThe lab is a large, " + "" +
            //    "well lit room, and staffed by a small number of scientists, all wearing light blue uniforms with the hydra-like Norlan Corporation logo.",
            //    Accessible = true,
            //    ModifiyExperiencePoints = 10
            //};

            ////
            //// row 2
            ////
            //gameMap.MapLocations[1, 1] = new Location()
            //{
            //    Id = 2,
            //    Name = "Felandrian Plains",
            //    Description = "The Felandrian Plains are a common destination for tourist. Located just north of the " +
            //    "equatorial line on the planet of Corlon, they provide excellent habitat for a rich ecosystem of flora and fauna.",
            //    Accessible = true,
            //    ModifiyExperiencePoints = 10
            //};
            //gameMap.MapLocations[1, 2] = new Location()
            //{
            //    Id = 2,
            //    Name = "Epitoria's Reading Room",
            //    Description = "Queen Epitoria, the Torian Monarh of the 5th Dynasty, was know for her passion for " +
            //    "galactic history. The room has a tall vaulted ceiling, open in the middle  with four floors of wrapping " +
            //    "balconies filled with scrolls, texts, and infocrystals. As you enter the room a red fog desends from the ceiling " +
            //    "and you begin feeling your life energy slip away slowly until you are dead.",
            //    Accessible = false,
            //    ModifiyExperiencePoints = 50,
            //    ModifyLives = -1,
            //    RequiredExperiencePoints = 40
            //};

            ////
            //// row 3
            ////
            //gameMap.MapLocations[2, 0] = new Location()
            //{
            //    Id = 3,
            //    Name = "Xantoria Market",
            //    Description = "The Xantoria market, once controlled by the Thorian elite, is now an open market managed " +
            //    "by the Xantorian Commerce Coop. It is a place where many races from various systems trade goods." +
            //    "You purchase a blue potion in a thin, clear flask, drink it and receive 50 points of health.",
            //    Accessible = false,
            //    ModifiyExperiencePoints = 20,
            //    ModifyHealth = 50,
            //    Message = "Traveler, our telemetry places you at the Xantoria Market. We have reports of local health potions."
            //};
            //gameMap.MapLocations[2, 1] = new Location()
            //{
            //    Id = 4,
            //    Name = "The Tamfasia Galactic Academy",
            //    Description = "The Tamfasia Galactic Academy was founded in the early 4th galactic metachron. " +
            //    "You are currently in the library, standing next to the protoplasmic encabulator that stores all " +
            //    "recorded information of the galactic history.",
            //    Accessible = true,
            //    ModifiyExperiencePoints = 10
            //};

            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>
            {
                new Weapons(4001, "Lightsaber", 200, 20, 64, "A powerful weapon mainly used by both Jedi and Sith to defend themselves.", 25),
                new Weapons(4002, "DL-44 Blaster", 125, 10, 50, "A blaster most famously used by Smugglers accross the galaxy.", 20),
                new Treasure(1998, "Ancient Device", 250, Treasure.TreasureType.Holocron, "Used to obtain ancient knowledge or to be sold for credits.", 50),
                new Treasure(1997, "Coin of the Rakata", 250, Treasure.TreasureType.Coin, "Can be sold for credits.", 5),
                new Medpacs(1002, "Small Medpac", 10, 50, "Used to regain a small amount of health.", 5),
                new Medpacs(1003, "Meduim Medpac", 15, 100, "Used to regain a moderate amount of health", 10),
                new Medpacs(1004, "Large Medpac", 20, 150, "Used to regain a large amount of health", 15),
                new Relic(3000, "Black Sun Keycard", 5, "Used to unlock the headquarters of the Black Sun gang", 10, "You have opened the headquarters of the black sun", Relic.UseActionType.OPENLOCATION)
            };  
            
        }
    }
}
