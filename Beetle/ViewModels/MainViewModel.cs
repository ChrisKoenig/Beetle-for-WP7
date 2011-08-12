using System;
using Beetle.Messages;
using Beetle.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;

namespace Beetle.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ResetGame();

            RollTheDiceCommand = new RelayCommand(() => this.RollTheDice());
            ResetGameCommand = new RelayCommand(() => this.ResetGame());
            MessengerInstance.Register<RollTheDiceMessage>(this, (message) => this.RollTheDice());
        }

        private void ResetGame()
        {
            this.GameState.ResetGameState();
            GameOver = false;
            CurrentRoll = null;
        }

        private void RollTheDice()
        {
            // get the random dice roll
            CurrentRoll = GetRandomDieRoll();

            // add the part based on the die roll
            this.GameState.AddPart(CurrentRoll.Value);

            // just to make sure...
            RaisePropertyChanged(() => this.GameState);

            // check to see if the game is over
            CheckForGameOver();
        }

        private void CheckForGameOver()
        {
            this.GameOver = GameState.IsComplete();
        }

        private int GetRandomDieRoll()
        {
            Random rnd = new Random();
            int result = rnd.Next(1, 7);
            CurrentRoll = result;
            return result;
        }

        public RelayCommand RollTheDiceCommand { get; private set; }

        public RelayCommand ResetGameCommand { get; private set; }

        #region CurrentRoll property

        private int? _currentRoll = null;

        public int? CurrentRoll
        {
            get
            {
                return _currentRoll;
            }

            set
            {
                if (_currentRoll == value)
                {
                    return;
                }
                _currentRoll = value;
                RaisePropertyChanged(() => this.CurrentRoll);
            }
        }

        #endregion CurrentRoll property

        #region GameState property

        private GameState _gameState = new GameState();

        public GameState GameState
        {
            get
            {
                return _gameState;
            }

            set
            {
                if (_gameState == value)
                {
                    return;
                }
                _gameState = value;
                RaisePropertyChanged(() => this.GameState);
            }
        }

        #endregion GameState property

        #region GameOver property

        private bool _gameOver = false;

        public bool GameOver
        {
            get
            {
                return _gameOver;
            }

            set
            {
                if (_gameOver == value)
                {
                    return;
                }
                _gameOver = value;
                RaisePropertyChanged(() => this.GameOver);
            }
        }

        #endregion GameOver property
    }
}