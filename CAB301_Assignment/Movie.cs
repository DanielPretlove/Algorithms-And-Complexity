using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CAB301_Assignment
{
    public class Movie
    {
        public string Title { get; set; }

        public string Actor { get; set; }

        public string Director { get; set; }

        public string Genre { get; set; }

        public string Classification { get; set; }

        public int Duration { get; set; }

        public int Release_Date { get; set; }
        public int Copies { get; set; }
        public int BorrowedMovies { get; set; }


       public Movie(string title)
        {
            Title = title;
            Copies = 1;
            BorrowedMovies = 0;
        }

        public override string ToString()
        {
            return $"Title:{Title}\nStarring: {Actor}\nDirector: {Director}\nGenre: {Genre}\nClassification: {Classification}\n" +
                $"Duration: {Duration}\nRelease Date: {Release_Date}\nCopies Available: {Copies}\nTimes borrowed: {BorrowedMovies}\n\n";
        }
    }
}
