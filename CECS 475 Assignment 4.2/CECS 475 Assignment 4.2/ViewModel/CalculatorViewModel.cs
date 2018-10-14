using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CECS_475_Assignment_4._2.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace CECS_475_Assignment_4._2.ViewModel
{
    public class CalculatorViewModel : ViewModelBase
    {
        private double _firstEntry;
        private double _secondEntry;
        private double _result;
        private string _operation;
        private ICommand _buttonCommand;
        private ICommand _subtractCommand;
        private ICommand _multiplyCommand;
        private ICommand _divideCommand;
        private ICommand _clearCommand;

        

        public ICommand OnButtonCommand
        {
            get
            {
                _buttonCommand = new RelayCommand(OnButtonCommandAction);
                return _buttonCommand;
            }
        }

        public ICommand SubtractCommand
        {
            get
            {
                _subtractCommand = new RelayCommand(OnSubtractAction);
                return _subtractCommand;
            }
        }

        public ICommand MultiplyCommand
        {
            get
            {
                _multiplyCommand = new RelayCommand(OnMultiplyAction);
                return _multiplyCommand;
            }
        }

        public ICommand DivideCommand
        {
            get
            {
                _divideCommand = new RelayCommand(OnDivideAction);
                return _divideCommand;
            }
        }

        public ICommand ClearCommand
        {
            get
            {
                _clearCommand = new RelayCommand(OnClearAction);
                return _clearCommand;
            }
        }


        public string Operation
        {
            get
            {
                return _operation;
            }
            set
            {
                _operation = value;
                RaisePropertyChanged("Operation");
            }
        }

        public double FirstEntry
        {
            get
            {
                return _firstEntry;
            }
            set
            {
                _firstEntry = Convert.ToDouble(value);
                RaisePropertyChanged("FirstEntry");
            }
        }

        public double SecondEntry
        {
            get
            {
                return _secondEntry;
            }
            set
            {
                _secondEntry = Convert.ToDouble(value);
                RaisePropertyChanged("SecondEntry");
            }
        }

        public double Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                RaisePropertyChanged("Result");
                
            }
        }

        public ICommand GetValuesCommand { get; private set; }

        public CalculatorViewModel()
        {

        }



        private void OnButtonCommandAction()
        {   
            Result = FirstEntry + SecondEntry;   
        }

        private void OnSubtractAction()
        {
            Result = FirstEntry - SecondEntry;
        }

        private void OnMultiplyAction()
        {
            Result = FirstEntry * SecondEntry;
        }

        private void OnDivideAction()
        {
            Result = FirstEntry / SecondEntry;
        }

        private void OnClearAction()
        {
            Result = 0;
            FirstEntry = 0;
            SecondEntry = 0;
        }
    }
}