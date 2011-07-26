using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Beetle.Models
{
    public class GameState : INotifyPropertyChanged
    {
        public void ResetGameState()
        {
            Body = Head = Leg1 = Leg2 = Leg3 = Leg4 = Leg5 = Leg6
                = Antenna1 = Antenna2 = Wing1 = Wing2 = false;
        }

        public void AddPart(int dieRoll)
        {
            switch (dieRoll)
            {
                case 1: // eye
                    if (Head && !Eye2)
                    {
                        if (Eye1)
                        {
                            Eye2 = true;
                        }
                        else
                        {
                            Eye1 = true;
                        }
                    }
                    break;

                case 2: // antenna
                    if (Head && !Antenna2)
                    {
                        if (Antenna1)
                        {
                            Antenna2 = true;
                        }
                        else
                        {
                            Antenna1 = true;
                        }
                    }
                    break;

                case 3: // leg
                    if (Body && !Leg6)
                    {
                        if (Leg5)
                        {
                            Leg6 = true;
                        }
                        else if (Leg4)
                        {
                            Leg5 = true;
                        }
                        else if (Leg3)
                        {
                            Leg4 = true;
                        }
                        else if (Leg2)
                        {
                            Leg3 = true;
                        }
                        else if (Leg1)
                        {
                            Leg2 = true;
                        }
                        Leg1 = true;
                    }
                    break;

                case 4: // wing
                    if (Body && !Wing2)
                    {
                        if (Wing1)
                        {
                            Wing2 = true;
                        }
                        else
                        {
                            Wing1 = true;
                        }
                    }
                    break;

                case 5: // head
                    Head = Body;
                    break;

                case 6: // body
                    Body = true;
                    break;

                default:
                    break;
            }
        }

        public bool IsComplete()
        {
            return Body && Head && Leg1 && Leg2 && Leg3 && Leg4 && Leg5 && Leg6 && Antenna1 && Antenna2 && Eye1 && Eye2;
        }

        #region Properties

        private bool _Wing2;
        private bool _Wing1;
        private bool _Antenna2;
        private bool _Antenna1;
        private bool _Eye2;
        private bool _Eye1;
        private bool _Leg6;
        private bool _Leg5;
        private bool _Leg4;
        private bool _Leg3;
        private bool _Leg2;
        private bool _Leg1;
        private bool _Head;
        private bool _Body;

        public bool Body
        {
            get { return _Body; }
            set
            {
                if (_Body == value)
                    return;
                _Body = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Body"));
            }
        }

        public bool Head
        {
            get { return _Head; }
            set
            {
                if (_Head == value)
                    return;
                _Head = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Head"));
            }
        }

        public bool Leg1
        {
            get { return _Leg1; }
            set
            {
                if (_Leg1 == value)
                    return;
                _Leg1 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Leg1"));
            }
        }

        public bool Leg2
        {
            get { return _Leg2; }
            set
            {
                if (_Leg2 == value)
                    return;
                _Leg2 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Leg2"));
            }
        }

        public bool Leg3
        {
            get { return _Leg3; }
            set
            {
                if (_Leg3 == value)
                    return;
                _Leg3 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Leg3"));
            }
        }

        public bool Leg4
        {
            get { return _Leg4; }
            set
            {
                if (_Leg4 == value)
                    return;
                _Leg4 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Leg4"));
            }
        }

        public bool Leg5
        {
            get { return _Leg5; }
            set
            {
                if (_Leg5 == value)
                    return;
                _Leg5 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Leg5"));
            }
        }

        public bool Leg6
        {
            get { return _Leg6; }
            set
            {
                if (_Leg6 == value)
                    return;
                _Leg6 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Leg6"));
            }
        }

        public bool Eye1
        {
            get { return _Eye1; }
            set
            {
                if (_Eye1 == value)
                    return;
                _Eye1 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Eye1"));
            }
        }

        public bool Eye2
        {
            get { return _Eye2; }
            set
            {
                if (_Eye2 == value)
                    return;
                _Eye2 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Eye2"));
            }
        }

        public bool Antenna1
        {
            get { return _Antenna1; }
            set
            {
                if (_Antenna1 == value)
                    return;
                _Antenna1 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Antenna1"));
            }
        }

        public bool Antenna2
        {
            get { return _Antenna2; }
            set
            {
                if (_Antenna2 == value)
                    return;
                _Antenna2 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Antenna2"));
            }
        }

        public bool Wing1
        {
            get { return _Wing1; }
            set
            {
                if (_Wing1 == value)
                    return;
                _Wing1 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Wing1"));
            }
        }

        public bool Wing2
        {
            get { return _Wing2; }
            set
            {
                if (_Wing2 == value)
                    return;
                _Wing2 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Wing2"));
            }
        }

        #endregion Properties

        #region OnPropertyChanged

        public virtual void OnPropertyChanged(object source, PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
                PropertyChanged(source, args);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion OnPropertyChanged
    }
}