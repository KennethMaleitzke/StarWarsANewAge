using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsANewAge.Models;

namespace StarWarsANewAge.PresentationLayer
{
    public class GameSessionViewModel
    {
        #region FIELDS

        private Player _player;
        private List<string> _messages;

        #endregion

        #region PROPERTIES
        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public List<string> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }
        }

        #endregion

        #region
        public GameSessionViewModel(
            Player player, List<string> initialMessages)
        {
            _player = player;
            _messages = initialMessages;
        }
        #endregion

        #region METHODS

        #endregion
    }
}
