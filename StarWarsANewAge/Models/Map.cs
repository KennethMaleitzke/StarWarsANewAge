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
        #endregion
        #region CONSTRUCTORS

        #endregion
        #region METHODS
        public void Move(Location location)
        {
            _currentLocation = location;
        }
        #endregion
    }
}
