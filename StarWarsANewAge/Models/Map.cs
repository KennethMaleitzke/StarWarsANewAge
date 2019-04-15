using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace StarWarsANewAge.Models
{
    public class Map
    {
        #region FIELD
        private ObservableCollection<Location> _locations;
        private Location _currentLocation;
        private ObservableCollection<Location> _accessibleLocations;
        private int _maxRows, _maxColumns;
        private List<GameItem> _standardGameItems;

        #endregion
        #region PROPERTIES
        public ObservableCollection<Location> AccessibleLocations
        {
            get
            {
                _accessibleLocations = new ObservableCollection<Location>();
                foreach (var location in _locations)
                {
                    if (location.Accessible == true)
                    {
                        _accessibleLocations.Add(location);
                    }
                    //_accessibleLocations.Add(location);
                }
                return _accessibleLocations;
            }
        }


        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }


        public ObservableCollection<Location> Location
        {
            get { return _locations; }
            set { _locations = value; }
        }

        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }
        #endregion
        #region CONSTRUCTORS

        #endregion
        #region METHODS
        public void Move(Location location)
        {
            _currentLocation = location;
        }

        public Map(int rows, int columns)
        {
            _maxRows = rows;
            _maxColumns = columns;
            //_mapLocations = new Location[rows, columns];
        }

        public string OpenLocationsByRelic(int relicId)
        {
            string message = "The relic did nothing.";
            Location mapLocation = new Location();

            for (int row = 0; row < _maxRows; row++)
            {
                for (int column = 0; column < _maxColumns; column++)
                {
                    //mapLocation = _mapLocations[row, column];

                    //if (mapLocation != null && mapLocation.RequiredRelicId == relicId)
                    {
                        mapLocation.Accessible = true;
                        message = $"{mapLocation.Name} is now accessible.";
                    }
                }
            }

            return message;
        }
        #endregion
    }
}
