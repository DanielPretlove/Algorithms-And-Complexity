using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_Assignment
{
    class Member
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Phone_Number { get; set; }
        public int Password { get; set; }

        public Movie[] Rented_Movies = new Movie[10];

        // userinput for creating a member
        public Member(string[] userInput)
        {
            if(userInput.Length != 5)
            {
                throw new Exception("You need to fill in all of the values to make a member: ");
            }
            else
            {
                try
                {
                    FirstName = userInput[0];
                    LastName = userInput[1];
                    Address = userInput[2];
                    Phone_Number = int.Parse(userInput[3]);
                    Password = int.Parse(userInput[4]);
                }

                catch
                {
                    Console.WriteLine("A member has not been created");
                }
                
            }   
        }

        // verify member login
        public bool VerifyLogin(string pin)
        {
            return int.Parse(pin) == Password;
        }

        public override string ToString()
        {
            return $"\nFirst Name: {FirstName}, Last Name: {LastName}, Address {Address}, Phone Number: {Phone_Number} PIN (Password): {Password}";
        }

        // borrows a movie
        public void Borrow(Movie movie)
        {
            int count = 0;
            while(Rented_Movies[count] != null)
            {
                if(Rented_Movies[count].Title == movie.Title)
                {
                    throw new Exception($"Error: {FirstName} {LastName} is already borrowing {movie.Title}");
                }

                else
                {
                    count++;
                }
            }

            if(count < Rented_Movies.Length)
            {
                Rented_Movies[count] = movie;
            }

            else
            {
                throw new Exception($"{FirstName} {LastName} is already borrowing {Rented_Movies.Length} movies");
            }
        }

        // returns a movie in the array
        public void Return_Movie(Movie movie)
        {
            for(int i = 0; i < Rented_Movies.Length; i++)
            {
                if(Rented_Movies[i] != null && Rented_Movies[i].Title == movie.Title)
                {
                    Return_Movie(i);
                    return;
                }
            }

            throw new Exception($"Member: {FirstName} {LastName} is not borrowing movier called {movie.Title}");
        }

        public void Return_Movie(int rented_movie)
        {
            if(rented_movie < Rented_Movies.Length)
            {
                Rented_Movies[rented_movie] = null;
            }

            else
            {
                throw new Exception($"member can only have up to 10 movies");
            }
        }
    }
}
