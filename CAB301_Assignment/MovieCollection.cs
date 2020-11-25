using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_Assignment
{

    public class Node
    {
        public Movie Data;
        public Node LeftChild;
        public Node RightChild;

        public Node() : this(null) { }

        public Node(Movie data)
        {
            Data = data;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class MovieCollection
    {
        public Node Root { get; set; }

        // used http://shixiangzb007.blogspot.com/2008/10/how-to-delete-node-from-binary-search.html as reference
        // find a specific movie in the binary search tree
        public Node Find_Movie(string movie)
        {
            return Find(Root.Data);
        }

        public Node Find(Movie movie)
        {
            return Find(movie, this.Root);
        }

        private Node Find(Movie movie, Node parent)
        {
            if(parent != null)
            {
                if (string.Compare(movie.Title, parent.Data.Title) == 0)
                {
                    return parent;
                }
                else
                {
                    if(string.Compare(movie.Title, parent.Data.Title) < 0)
                    {
                        return Find(movie, parent.LeftChild);
                    }

                    else
                    {
                        return Find(movie, parent.RightChild);
                    }
                }
            }

            else
            {
                return null;
            }
        }
        
        // adds a movie in the binary search tree
        public void Add(Movie movie)
        {
            Node before = null;
            Node after = this.Root;

            while (after != null)
            {
                before = after;

                if (string.Compare(movie.Title, after.Data.Title) < 0)
                {
                    after = after.LeftChild;
                }

                else if (string.Compare(movie.Title, after.Data.Title) > 0)
                {
                    after = after.RightChild;
                }

                else
                {
                    after.Data.Copies++;
                    return;
                }
            }

            Node newNode = new Node(movie);

            if (Root == null)
            {
                Root = newNode;
            }

            else
            {
                if (string.Compare(movie.Title, before.Data.Title) < 0)
                {
                    before.LeftChild = newNode;
                }
                else
                {
                    before.RightChild = newNode;
                }
            }
        }


        // removes a movie from the binary search tree
        public void Remove(Movie movie)
        {
            Node root = Root;
            Node parent = null;

            while((root != null) && (string.Compare(movie.Title, root.Data.Title)) != 0)
            {
                parent = root;
                if(string.Compare(movie.Title, root.Data.Title) < 0)
                {
                    root = root.LeftChild;
                }

                else
                {
                    root = root.RightChild;
                }
            }

            if(root != null)
            {
                if((root.LeftChild != null) && (root.RightChild != null))
                {
                    if(root.LeftChild.RightChild == null)
                    {
                        root.Data.Title = root.LeftChild.Data.Title;
                        root.LeftChild = root.LeftChild.LeftChild;
                    }

                    else
                    {
                        while (parent.LeftChild.RightChild != null)
                        {
                            parent = parent.LeftChild;
                            parent.LeftChild = parent.LeftChild.LeftChild;
                        }

                        root.Data.Title = parent.LeftChild.Data.Title;
                        parent.RightChild = parent.LeftChild.LeftChild;
                    }
                }
                
                else
                {
                    Node child;
                    if(root.LeftChild != null)
                    {
                        child = root.LeftChild;
                    }
                    else
                    {
                        child = root.RightChild;
                    }


                    if(root == Root)
                    {
                        Root = child;
                    }

                    else
                    {
                        if(root == parent.LeftChild)
                        {
                            parent.LeftChild = child;
                        }

                        else
                        {
                            parent.RightChild = child;
                        }
                    }
                }
            }
        }

        // orders movie in traversal inorder
        public void TraverseInOrder(Node parent)
        {
            if(parent != null)
            {
                TraverseInOrder(parent.LeftChild);
                Console.Write(parent.Data + "");
                TraverseInOrder(parent.RightChild);
            }
        }

            // sorting BorrowedMovies from 0 - 9, although the code does not work
          public Movie Partition(Movie movie, int left, int right)
          {
              int pivot;
              pivot = movie.BorrowedMovies;

              while (movie.BorrowedMovies < pivot)
              {
                  left++;
              }

              while (movie.BorrowedMovies > pivot)
              {
                  right--;
              }

              if (left < right)
              {
                  int temp = movie.BorrowedMovies;
                  movie.BorrowedMovies = temp;
              }

              return null;
        }

          public void quickSort(Movie movie, int left, int right)
          {
              Movie pivot;
              if (left < right)
              {
                  pivot = Partition(Root.Data, left, right);
                  if (pivot.BorrowedMovies> 1)
                  {
                      quickSort(movie, left, pivot.BorrowedMovies - 1);
                  }
                  if (pivot.BorrowedMovies + 1 < right)
                  {
                      quickSort(movie, pivot.BorrowedMovies + 1, right);
                  }
              }
         }


        // check for most popular movies
        public void Popular_Movies(Node parent)
        {
            if(parent != null)
            {
                if(parent.Data.BorrowedMovies > 0)
                {
                    Popular_Movies(parent.LeftChild);
                    Console.Write("{0} borrowed {1}\n", parent.Data.Title, parent.Data.BorrowedMovies);
                    Popular_Movies(parent.RightChild);
                   // quickSort(parent.Data, 0, 9);
                }
            }
        }


        // returns a movie that a member has borrowed
        public void Lend(Movie movie)
        {
            Node find_movie = Find(movie);

            if(find_movie != null && find_movie.Data.Copies > 0)
            {
                find_movie.Data.Copies--;
                find_movie.Data.BorrowedMovies++; 
            }

            else
            {
                throw new Exception($"{movie.Title} not avaliable");
            }
        }

        // returning the movie
        public void Return_Movie(Movie movie)
        {
            Node find_movie = Find(movie);

            if(find_movie != null)
            {
                find_movie.Data.Copies++;
            }

            else
            {
                throw new Exception($"{movie.Title} doesn't exist");
            }
        }
    }
}
