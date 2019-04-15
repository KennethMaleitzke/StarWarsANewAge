using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsANewAge.Models;
using System.Collections.ObjectModel;

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
                OnPropertyChanged("CurrentLocation");
            }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
            }
        }

        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
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
            _player.InitializeWealth();
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
            if (_currentGameItem)
            {

            }
        }
        #endregion

        #region EVENTS



        #endregion
    }
}
