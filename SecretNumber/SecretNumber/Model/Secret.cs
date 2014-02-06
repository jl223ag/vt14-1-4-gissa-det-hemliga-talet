using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace SecretNumber.Model
{
    public class Secret
    {
        private int _number;
        private List<int> _previousGuesses;
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess
        {
            get
            {
                if (Count >= MaxNumberOfGuesses || _previousGuesses.Contains(_number))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int Count
        {
            get
            {
                return _previousGuesses.Count;
            }
        }

        public int? Number
        {
            get
            {
                if (!CanMakeGuess)
                {
                    return _number;
                }
                return null;
            }
        }

        public ReadOnlyCollection<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }

        public void Initalize()
        {
            Random random = new Random();
            _number = random.Next(1, 101);

            if (_previousGuesses != null)
            {
                _previousGuesses.Clear();
            }
            
            _previousGuesses = new List<int>(MaxNumberOfGuesses);

            Out = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {            
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentException("talet är inte i intervallet 1 - 100!");
            }
            else if (!CanMakeGuess)
            {
                Out = Outcome.NoMoreGuesses;
            }
            else if (_previousGuesses.Contains(guess))
            {
                Out = Outcome.PreviousGuess;
            }
            else
            {
                if (guess == _number)
                {
                    Out = Outcome.Correct;
                }
                else if ((Count + 1) >= MaxNumberOfGuesses) // ifall inte sista gissningen är rätt körs denna
                {
                    Out = Outcome.NoMoreGuesses;
                }
                else if (guess < _number)
                {
                    Out = Outcome.Low;
                }
                else
                {
                    Out = Outcome.High;
                }

                _previousGuesses.Add(guess);
            }
            
            return Out;
        }

        public Outcome Out
        {
            get;
            set;
        }
    }

    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }
}