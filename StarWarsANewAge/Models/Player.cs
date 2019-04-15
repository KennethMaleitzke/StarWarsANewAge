using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace StarWarsANewAge.Models
{
    public class Player : Character
    {
        #region ENUMS

        public enum JobTitleName { Jedi, Sith }

        #endregion

        #region FIELDS

        private int _credits;
        private int _health;
        private int _wealth;
        private int _experiencePoints;
        private JobTitleName _jobTitle;
        private List<Location> _locationsVisited;
        private ObservableCollection<GameItemQuantity> _inventory;
        private ObservableCollection<GameItemQuantity> _medpacs;
        private ObservableCollection<GameItemQuantity> _treasure;
        private ObservableCollection<GameItemQuantity> _weapons;
        private ObservableCollection<GameItemQuantity> _relics;



        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }


        #endregion

        #region PROPERTIES
        public int Credits
        {
            get { return _credits; }
            set
            {
                _credits = value;
                OnPropertyChanged(nameof(Credits));
            }
        }

        public JobTitleName JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Wealth
        {
            get { return _wealth; }
            set { _wealth = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }

        public ObservableCollection<GameItemQuantity> Relics
        {
            get { return _relics; }
            set { _relics = value; }
        }


        public ObservableCollection<GameItemQuantity> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }


        public ObservableCollection<GameItemQuantity> Treasure
        {
            get { return _treasure; }
            set { _treasure = value; }
        }


        public ObservableCollection<GameItemQuantity> Medpacs
        {
            get { return _medpacs; }
            set { _medpacs = value; }
        }


        public ObservableCollection<GameItemQuantity> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Player()
        {
            LocationsVisited = new List<Location>();
            _weapons = new ObservableCollection<GameItemQuantity>();
            _treasure = new ObservableCollection<GameItemQuantity>();
            _medpacs = new ObservableCollection<GameItemQuantity>();
            _relics = new ObservableCollection<GameItemQuantity>();
        }


        #endregion

        #region METHODS

        /// <summary>
        /// override the default greeting in the Character class to include the job title
        /// set the proper article based on the job title
        /// </summary>
        /// <returns>default greeting</returns>
        public override string DefaultGreeting()
        {
            string article = "a";

            List<string> vowels = new List<string>() { "A", "E", "I", "O", "U" };

            if (vowels.Contains(_jobTitle.ToString().Substring(0, 1))) 
            {
                article = "an";
            }

            return $"Hello, my name is {_name} and I am {article} {_jobTitle} for the Aion Project.";
        }

        public void UpdateInventoryCategories()
        {
            Medpacs.Clear();
            Weapons.Clear();
            Treasure.Clear();
            Relics.Clear();

            foreach (var gameItemQuantity in _inventory)
            {
                if (gameItemQuantity.GameItem is Medpacs) Medpacs.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Weapons) Weapons.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Treasure) Treasure.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Relic) Relics.Add(gameItemQuantity);
            }
        }

        ///<summary>
        /// remove selected item from inventory
        /// </summary>
        /// <param name="SelectedGameItem">Selected item</param>
        /// 
        public void AddGameItemToInventory(GameItemQuantity selectedGameItemQuantity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateInventoryCategories();
        }

        public void RemoveGameItemQuantityFromInventory(GameItemQuantity selectedGameItemQuantity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateInventoryCategories();
        }

        public void CalculateWealth()
        {
            //Wealth = _inventory.Sum(i => i.Value);
        }
        #endregion

        #region EVENTS



        #endregion
    }
}
