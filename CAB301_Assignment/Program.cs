using System;

namespace CAB301_Assignment
{
    class Program
    {
        MovieCollection moviecollection = new MovieCollection();

        MemberCollection all_members = new MemberCollection();
        Member current_member = null;
        Movie movie = null;


        string[] memberinput = new string[5];
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Community_Library();

            Console.ReadKey();
        }

        // main menu / community library
        public void Community_Library()
        {
            int input;
            Console.WriteLine("\nWelcome to the Community Library");
            Console.WriteLine("========== Main Menu ===========");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("==============================");
            Console.Write("\nPlease make a selection (1-2, or 0 to exit ");
          
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Credentials();
                        break;

                    case 2:
                        Member_Login();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        Community_Library();
                        break;
                }
            }
            
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Community_Library();
            }
            
           
        }

        // login for staff menu
        public void Credentials()
        {
            Console.WriteLine();
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (username == "staff" && password == "today123")
            {
               Staff_Menu();

            }
            else
            {
                Community_Library();
            }

        }

        // login for member menu
        public void Member_Login()
        {
            Console.WriteLine();
            Console.Write("Enter username {lastnamefirstname}: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            for (int i = 0; i < all_members.members.Length; i++)
            {
                try
                {
                    Member temp = all_members.Find_Member(username);
                    if(temp.VerifyLogin(password))
                    {
                        current_member = temp;
                        Member_Menu();
                    }
                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Community_Library();
                }
                
            }
        }

        public void Staff_Menu()
        {
            Console.WriteLine("\n=========== Staff Menu ===========");
            Console.WriteLine("1. Add a new movie DVD");
            Console.WriteLine("2. Remove a movie DVD");
            Console.WriteLine("3. Register a new Member");
            Console.WriteLine("4. Find a registered member's phone number");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.Write("Please make a selection (1-4, or 0 to return to main menu: ");
            int input = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (input)
                {
                    case 0:
                        Community_Library();
                        break;
                    case 1:
                        Add_Movies();
                        break;
                    case 2:
                        Remove_Movies();
                        break;
                    case 3:
                        Register_Member();
                        break;
                    case 4:
                        Members_Number();
                        break;
                    default:
                        Staff_Menu();
                        break;

                }
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Staff_Menu();
            }
           
        }

        // adds a movie to the binary search tree
        public void Add_Movies()
        {

            string movie_title, actors, director;
            int genre_values, classfication_values, duration, release_date, copies;



            Console.WriteLine();
            Console.Write("Enter a movie title:");
            movie_title = Console.ReadLine();
            movie = new Movie(movie_title);


            // check if movie_title already exist in the binary tree

            /// first loop no checks 
            /// second loop check if movie_title is not null within the node 


            try
            {
                Node temp = moviecollection.Find(movie);

                for(int i = 0; i < 25; i++)
                {
                    if (movie_title == temp.Data.Title)
                    {
                        try
                        {
                            Console.Write("Enter number of copies you would like to add: ");
                            copies = Convert.ToInt32(Console.ReadLine());
                            movie = temp.Data;
                            temp.Data.Copies = copies;
                            movie.Copies = temp.Data.Copies;
                            Console.WriteLine("Added {0} copies to {1}", movie.Copies, movie_title);
                            Staff_Menu();
                        }
                        
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Staff_Menu();
                        }

                    }
                }
            }

            catch
            {
                try
                {
                    moviecollection.Add(movie);
                    Console.Write("Enter the starring actor(s): ");
                    actors = Console.ReadLine();
                    movie.Actor = actors;

                    Console.Write("Enter the director(s): ");
                    director = Console.ReadLine();
                    movie.Director = director;

                    Console.Write("Select the genre:\n1: Drama\n2: Adventure\n3: Family\n4: Action\n5: Sci-Fi\n6: Comedy\n7: Thriller\n8: Other\nMake selection (1-8): ");
                    genre_values = Convert.ToInt32(Console.ReadLine());
                    string genre = Convert.ToString(genre_values);

                    switch (genre_values)
                    {
                        case 1:
                            genre = "Drama";
                            break;
                        case 2:
                            genre = "Adventure";
                            break;
                        case 3:
                            genre = "Family";
                            break;
                        case 4:
                            genre = "Action";
                            break;
                        case 5:
                            genre = "Sci-Fi";
                            break;
                        case 6:
                            genre = "Comedy";
                            break;
                        case 7:
                            genre = "Thriller";
                            break;
                        case 8:
                            Console.Write("Type in other genre's: ");
                            genre = Console.ReadLine();
                            break;

                    }

                    movie.Genre = genre;

                    Console.Write("Select the classification:\n1: General (G)\n2: Parental Guidence(PG)\n3: Mature (M15+)\n4: Mature Accompied (MA15+)\nMake selection (1-4): ");
                    classfication_values = Convert.ToInt32(Console.ReadLine());
                    string classification = Convert.ToString(classfication_values);
                    switch (classfication_values)
                    {
                        case 1:
                            classification = "General (G)";
                            break;
                        case 2:
                            classification = "Parental Guidence(PG)";
                            break;
                        case 3:
                            classification = "Mature (M15+)";
                            break;
                        case 4:
                            classification = "Mature Accompied (MA15+)";
                            break;
                    }

                    movie.Classification = classification;

                    Console.Write("Enter the duration (minutes): ");
                    duration = Convert.ToInt32(Console.ReadLine());
                    movie.Duration = duration;

                    Console.Write("Enter the release date (year): ");
                    release_date = Convert.ToInt32(Console.ReadLine());
                    movie.Release_Date = release_date;

                    Console.Write("Enter the number of copies available: ");
                    copies = Convert.ToInt32(Console.ReadLine());
                    movie.Copies = copies;

                    Console.WriteLine("{0} has been added which has {1}, {2}, {3}, {4}, {5}, {6}, {7}\n",
                        movie.Title, movie.Actor, movie.Director, movie.Genre, movie.Classification, movie.Duration, movie.Release_Date, movie.Copies);
                    Staff_Menu();


                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    moviecollection.Remove(movie);
                    Staff_Menu();
                }




            }

        }

        // removes a movie from the binary search tree
        public  void Remove_Movies()
        {
            string movie_title;
            Console.Write("\n\nEnter a movie title:");
            movie_title = Console.ReadLine();
            movie = new Movie(movie_title);
            moviecollection.Remove(movie);
            Console.WriteLine("{0} has been deleted", movie.Title);
            Staff_Menu();
        }


        // creating a new member
        public void Register_Member()
        {
            Console.WriteLine("\n\nRegister a new member: ");
            Console.Write("\nEnter member's first name: ");
            memberinput[0] = Console.ReadLine();

            Console.Write("\nEnter member's last name: ");
            memberinput[1] = Console.ReadLine();

            Console.Write("\nEnter member's address: ");
            memberinput[2] = Console.ReadLine();

            Console.Write("\nEnter member's phone number: ");
            memberinput[3] = Console.ReadLine();


            Console.Write("\nEnter member's password(4 digits): ");
            string password = Console.ReadLine();

            Console.Write("\nConfirm Password: ");
            string confirm_password = Console.ReadLine();


            if (password != confirm_password)
            {
                Console.WriteLine("Password doesn't match");
                Staff_Menu();
            }

            memberinput[4] = password;
            Member member = new Member(memberinput);
            try
            {
                if(password.Length == 4)
                {
                    

                    all_members.Register_Member(member);
                    Console.WriteLine(member);
                    Staff_Menu();
                }

                else
                {
                    member = null;
                    Console.WriteLine("password needs to be 4 characters long.", member);
                    Staff_Menu();
                }
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // finds the members phone number
        public void Members_Number()
        {
            string[] membername = new string[2];
            Member member = new Member(memberinput);
            Console.WriteLine("\nFind members Phone Number\n");

            Console.Write("Enter member's first name: ");
            membername[0] = Console.ReadLine();

            Console.Write("\nEnter member's last name: ");
            membername[1] = Console.ReadLine();

            for(int i = 0; i < all_members.members.Length; i++)
            {
                try
                {
                    if ((membername[0] == all_members.members[i].FirstName) && (membername[1] == all_members.members[i].LastName))
                    {
                        Console.WriteLine("{0} {1}'s phone number is: {2}", all_members.members[i].FirstName, all_members.members[i].LastName, all_members.members[i].Password);
                        break;
                    }
                }
                
                catch
                {
                    Console.WriteLine("member doesn't exist");
                    break;
                }
            }

            if (member.Password == 0 || member.Address == null)
            {
                Console.WriteLine("Password doesn't exist");
            }

            Staff_Menu();
        }


        public void Member_Menu()
        {
            Console.WriteLine("\n\n=========== Member Menu ===========");
            Console.WriteLine("1. Display all movies");
            Console.WriteLine("2. Borrow a movie DVD");
            Console.WriteLine("3. Return a movie DVD");
            Console.WriteLine("4. List current borrowed movie DVDs");
            Console.WriteLine("5. Display top 10 most popular movies");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.Write("Please make a selection (1-5, or 0 to return to main menu: ");
            try
            {
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        Community_Library();
                        break;
                    case 1:
                        Display_All_Movies();
                        break;
                    case 2:
                        Borrow_Movie();
                        break;
                    case 3:
                        Return_Movie();
                        break;
                    case 4:
                        Movies_Currently_Borrowed();
                        break;
                    case 5:
                        Popular_Movies();
                        break;
                    default:
                        Console.WriteLine("\n\nInvalid input");
                        Member_Menu();
                        break;
                }
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Member_Menu();
            }
        }

        // displaying all added movies
        public void Display_All_Movies()
        {
            Console.WriteLine("All Movies: ");   
            moviecollection.TraverseInOrder(moviecollection.Root);
            Member_Menu();
        }


        // borrowing a movie 
        public void Borrow_Movie()
        {

            Console.WriteLine("Borrow a movie DVD\n");
            Console.Write("Enter a movie title: ");
            string movie_title = Console.ReadLine();
  
            movie = new Movie(movie_title);
            
            try
            {
                current_member.Borrow(movie);
                try
                {
                    moviecollection.Lend(movie);
                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    current_member.Return_Movie(movie);
                    Member_Menu();
                }
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Member_Menu();
            }
            Console.WriteLine("Has been lended");
            Member_Menu();
        }

        // returning a movie
        public void Return_Movie()
        {
            Console.WriteLine("Return a movie DVD\n");
            Console.Write("Enter a movie title: ");
            string movie_title = Console.ReadLine();
            movie = new Movie(movie_title);

            try
            {
                current_member.Return_Movie(movie);
                try
                {
                    moviecollection.Return_Movie(movie);
                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    current_member.Borrow(movie);
                    Member_Menu();
                }

            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Member_Menu();
            }

            Console.WriteLine("Has been returned");
            Member_Menu();


        }

        // all movies currently being borrowed by a specific member
        public void Movies_Currently_Borrowed()
        {
            Console.WriteLine("List of currently borrowed movies");
            for(int i = 0; i < current_member.Rented_Movies.Length; i++)
            {
                if(current_member.Rented_Movies[i] != null)
                {
                    Console.WriteLine(current_member.Rented_Movies[i].Title);
                }
            }
        }

        // top 10 popular movies
        public void Popular_Movies()
        {
            Console.WriteLine("top 10 movies");
            for(int i = 0; i < 10; i++)
            {
                try
                {
                    moviecollection.Popular_Movies(moviecollection.Root);
                    Member_Menu();
                }

                catch
                {
                    Member_Menu();
                }
               
            }
        }
    }
}

