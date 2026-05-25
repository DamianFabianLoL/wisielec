using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanWpf
{
    public class HangmanGame
    {
        private List<string> Words = new List<string> { "komputer", "programowanie", "wisielec", "csharp", "windows" };
        public string Word { get; private set; }
        public HashSet<char> UsedLetters { get; private set; }
        public int Errors { get; private set; }
        public int MaxErrors { get; private set; } = 6;

        public HangmanGame()
        {
            var rnd = new Random();
            Word = Words[rnd.Next(Words.Count)];
            UsedLetters = new HashSet<char>();
            Errors = 0;
        }

        public string GetMaskedWord()
        {
            return string.Join(" ", Word.Select(c => UsedLetters.Contains(char.ToLower(c)) ? c : '_'));
        }

        public bool Guess(char letter)
        {
            letter = char.ToLower(letter);
            if (!char.IsLetter(letter) || UsedLetters.Contains(letter))
                return false;
            UsedLetters.Add(letter);
            if (!Word.Contains(letter))
                Errors++;
            return true;
        }

        public bool IsWon()
        {
            return Word.ToLower().All(c => UsedLetters.Contains(char.ToLower(c)));
        }

        public bool IsLost()
        {
            return Errors >= MaxErrors;
        }
    }
}