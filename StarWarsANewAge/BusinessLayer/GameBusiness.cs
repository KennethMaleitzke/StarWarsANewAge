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

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        private void InitializeDataSet()
        {
            _messages = GameData.InitialMessages();
        }

        private void InstantiateAndShowView()
        {
            _gameSessionViewModel = new GameSessionViewModel(
            _player, 
            GameData.InitialMessages()
            );

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
                _player.Lives = 5;
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }
    }
}
