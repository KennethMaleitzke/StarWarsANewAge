using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsANewAge.Models;
using StarWarsANewAge.DataLayer;
using StarWarsANewAge.PresentationLayer;

namespace StarWarsANewAge.BusinessLayer
{
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        Player _player = new Player();
        List<string> _messages = new List<string>();
        bool _newPlayer = false;
        PlayerSetupView _playerSetupView;
        Map _gameMap;
        Location _currentLocation;

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        private void InitializeDataSet()
        {
            _player = GameData.PlayerData();
            _messages = GameData.InitialMessages();
            _gameMap = GameData.GameMapData();
            _currentLocation = _gameMap.CurrentLocation; //GameData.InitialGameMapLocation();
            
        }

        private void InstantiateAndShowView()
        {
            _gameSessionViewModel = new GameSessionViewModel(_player, _messages, _gameMap, _currentLocation);
            GameData.InitialMessages();

            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

            //_playerSetupView.Close();
        }

        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();

                _player.ExperiencePoints = 0;
                _player.Health = 100;
                _player.Credits = 100;
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }
    }
}
