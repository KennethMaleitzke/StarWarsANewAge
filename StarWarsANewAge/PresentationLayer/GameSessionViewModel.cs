using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsANewAge.Models;
using StarWarsANewAge;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows;
using System.Windows.Threading;

namespace StarWarsANewAge.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        #region ENUMS



        #endregion

        #region FIELDS

        private Player _player;
        private List<string> _messages;
        private DateTime _gameStartTime;
        private Map _gameMap;
        private Location _currentLocation;
        private string _currentLocationName;
        private GameItemQuantity _currentGameItem;
        private ObservableCollection<Location> _accessibleLocations;



        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get { return FormatMessagesForViewer(); }
        }

        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {
            _accessibleLocations = new ObservableCollection<Location>();

        }

        public GameSessionViewModel(
            Player player,
            List<string> initialMessages,
            Map gameMap,
            Location currentLocation)
        {
            _player = player;
            _messages = initialMessages;
            _gameMap = gameMap;
            _currentLocation = currentLocation;
            InitializeView();
        }

        public ObservableCollection<Location> AccessibleLocations
        {
            get { return _accessibleLocations; }
            set { _accessibleLocations = value; }
        }

        public string CurrentLocationName
        {
            get { return _currentLocationName; }
            set
            {
                _currentLocationName = value;
                OnPlayerMove();
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }

        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        public GameItemQuantity CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }
        #endregion

        #region METHODS

        /// <summary>
        /// initial setup of the game session view
        /// </summary>
        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            _accessibleLocations = _gameMap.AccessibleLocations;
            _player.UpdateInventoryCategories();
            //_player.InitializeWealth(); //  Method is missing? Jim
        }

        /// <summary>
        /// generates a sting of mission messages with time stamp with most current first
        /// </summary>
        /// <returns>string of formated mission messages</returns>
        private string FormatMessagesForViewer()
        {
            List<string> lifoMessages = new List<string>();

            for (int index = 0; index < _messages.Count; index++)
            {
                lifoMessages.Add($" <T:{GameTime().ToString(@"hh\:mm\:ss")}> " + _messages[index]);
            }

            lifoMessages.Reverse();

            return string.Join("\n\n", lifoMessages);
        }

        /// <summary>
        /// running time of game
        /// </summary>
        /// <returns></returns>
        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }

        private void OnPlayerMove()
        {
            //
            //set new current location
            //

            foreach (Location location in AccessibleLocations)
            {
                if (location.Name == _currentLocationName)
                {
                    _currentLocation = location;
                }
            }
            _currentLocation = AccessibleLocations.FirstOrDefault(l => l.Name == _currentLocationName);

            if (!_player.LocationsVisited.Contains(_currentLocation))
            {
                _player.ExperiencePoints += _currentLocation.ModifyExperiencePoints;
                _player.LocationsVisited.Add(_currentLocation);
            }
            //
            // update experience points
            //

        }

        public void AddItemToInventory()
        {
            if (_currentGameItem != null & _currentLocation.GameItems.Contains(_currentGameItem))
            {
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItemQuantity);
                _player.AddGameItemToInventory(selectedGameItemQuantity);

                OnPlayerPutDown(selectedGameItemQuantity);
            }
        }

        public void RemoveItemFromInventory()
        {
            if (_currentGameItem != null)
            {
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentLocation.AddGameItemQuantityToLocation(selectedGameItemQuantity);
                _player.RemoveGameItemQuantityFromInventory(selectedGameItemQuantity);

                OnPlayerPutDown(selectedGameItemQuantity);
            }
        }

        private void OnPlayerPickUp(GameItemQuantity gameItemQuantity)
        {
            _player.ExperiencePoints += gameItemQuantity.GameItem.ExperiencePoints;
            _player.Wealth += gameItemQuantity.GameItem.Value;
        }

        private void OnPlayerPutDown(GameItemQuantity gameItemQuantity)
        {
            _player.Wealth -= gameItemQuantity.GameItem.Value;
        }

        public void OnUseGameItem()
        {
            switch (_currentGameItem.GameItem)
            {
                case Medpacs medpac:
                    ProcessMedpacUse(medpac);
                    break;
            }
        }

        private void ProcessMedpacUse(Medpacs medpacs)
        {
            _player.Health += medpacs.HealthChange;
            _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
        }

        private void OnPlayerDies(string message)
        {
            string messageText = message + "\n\nWould you like to play again?";

            string titleText = "You have become one with the force";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(messageText, titleText, button);


            //switch (result)
            //{
            //    case MessageBoxResult.Yes:
            //    ResetPlayer();
            //    break;
            //    case MessageBoxResult.No:
            //       QuitApplication();
            //    break;
            //}
        }
        #endregion

        #region EVENTS



        #endregion
    }
}
