using RomanNumberCalculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ReactiveUI;

namespace RomanNumberCalculator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string _mainText = "";
        bool _error;
        char _op;
        RomanNumberExtend romanNumber;

        private bool Error
        {
            get => _error;
            set
            {
                if (value)
                    SetErrorMessage();
                else if (!value && _error)
                    MainText = "";

                _error = value;
            }
        }

        public string MainText
        {
            get => _mainText;
            set
            {
                this.RaiseAndSetIfChanged(ref _mainText, value);
            }
        }

        public void DoRoman(char x)
        {
            Error = false;
            MainText += x;
        }

        public void Calculate()
        {
            RomanNumberExtend x = new RomanNumberExtend(MainText);
            try
            {
                if (_op == '+')
                    MainText = (x + romanNumber).ToString();
                else if (_op == '-')
                    MainText = (romanNumber - x).ToString();
                else if (_op == '/')
                    MainText = (romanNumber / x).ToString();
                else if (_op == '*')
                    MainText = (romanNumber * x).ToString();
            }
            catch (RomanNumberException)
            {
                Error = true;
            }
        }

        public void Clear()
        {
            MainText = "";
            Error = false;
            romanNumber = null;
        }

        private void SetErrorMessage() => MainText = "ERROR";

        public void DoOperator(char op)
        {
            romanNumber = new RomanNumberExtend(MainText);
            this._op = op;
            MainText = "";
        }
    }
}
