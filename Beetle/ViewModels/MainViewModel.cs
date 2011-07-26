using System;
using Beetle.Messages;
using Beetle.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Beetle.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ResetGame();
            RollTheDiceCommand = new RelayCommand(() => this.RollTheDice());
            ResetGameCommand = new RelayCommand(() => this.ResetGame());
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
            }
        }

        private void ResetGame()
        {
            this.GameState.ResetGameState();
        }

        private void RollTheDice()
        {
            // get the random die roll
            int dieRoll = GetRandomDieRoll();

            // add the part based on the die roll
            GameState.AddPart(dieRoll);

            // just to make sure...
            RaisePropertyChanged(() => this.GameState);

            // check to see if the game is over
            if (GameState.IsComplete())
                MessengerInstance.Send<GameOverMessage>(new GameOverMessage());
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
    }
}