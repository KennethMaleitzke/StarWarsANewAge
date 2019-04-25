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
                LocationId = 0,
                Inventory = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GetGameItemById(1002), 1),
                    new GameItemQuantity(GetGameItemById(4001), 1),
                    new GameItemQuantity(GetGameItemById(4002), 1),
                }
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
                ModifyExperiencePoints = 10,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GetGameItemById(1002), 1),
                    new GameItemQuantity(GetGameItemById(4001), 1),
                    new GameItemQuantity(GetGameItemById(4002), 1),
                }

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
                    ModifyExperiencePoints = 10,
                       GameItems = new ObservableCollection<GameItemQuantity>
                       {
                       new GameItemQuantity(GetGameItemById(1002), 1),
                       new GameItemQuantity(GetGameItemById(4001), 1),
                       new GameItemQuantity(GetGameItemById(4002), 1),
                       }

                 },
                 new Location()
                 {
                    Id = 1,
                    Name = "Florian Swamp",
                    Description = "The Florian Swamp  is filled with mud, dirty looking water and deadly creatures " +
                    "The Florian Swamp is also a big battle field between the Republic and Imperials and has claimed many " +
                    "lives over the years.",
                    Accessible = true,
                    ModifyExperiencePoints = 10,
                       GameItems = new ObservableCollection<GameItemQuantity>
                       {
                        new GameItemQuantity(GetGameItemById(1002), 1),
                        new GameItemQuantity(GetGameItemById(4001), 1),
                        new GameItemQuantity(GetGameItemById(4002), 1),
                       }

                 }
            };

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

        public static GameItem GetGameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }
    }

    

}
