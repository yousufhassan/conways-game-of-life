using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Namespace: game_of_life_yousuf
Class: ICS4U
ClassName: Grid
Description: This class creates the outline for a Grid object and contains the methods to get the create the 2D array of Cell objects,
             randomly populate the grid with cell objects, get the values of cell neighbours, copy an array, calculate the next generation
             of the grid, and print the grid to the console.
Name: Yousuf Hassan
Date: March 4, 2020
Notes: Instead of looping the output of the grid in the Program class, it is done in this class, in the Print2dArray method.
*/

namespace game_of_life_yousuf
{
    class Grid
    {
        private int dimension;

        /* Overloaded constructor for a Grid object
         * Arguments: Rows (always set to 2)
         */
        public Grid(int dimension)
        {
            this.dimension = dimension;
        }

        /*
         * This method creates a 2D array of Cell objects
         * Arguments: None
         */
        public Cell[,] Create2dArray()
        {
            bool correctVal = true;
            Cell[,] origArray; // create 2D array of cell objects
            while (correctVal == true)
            {
                try
                {
                    // declare 2D arrays and variables
                    Console.Write("How many rows would you like in the array: ");
                    int rows = Convert.ToInt32(Console.ReadLine());
                    Console.Write("How many columns would you like in the array: ");
                    int columns = Convert.ToInt32(Console.ReadLine());
                    origArray = new Cell[rows, columns]; // initialize the grid using the user's values
                    Console.WriteLine();
                    correctVal = false;
                    return origArray;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            origArray = new Cell[0, 0]; // this is just here so that all code paths return a value
            return origArray;
        }

        /*
         * This method creates a cell object at each index and gives it a value of either 0 or 1
         * Arguments: Original 2D array of cell objects 
         */
        public void PopulateRandom(Cell[,] origArray)
        {
            try
            {
                // generate either a 0 or 1 for each cell object
                Random rnd = new Random();

                // for loops that create a cell object and populate each index with a cell object
                for (int i = 0; i < origArray.GetLength(0); i++)
                {
                    for (int j = 0; j < origArray.GetLength(1); j++)
                    {
                        int rndVal = rnd.Next(2);
                        origArray[i, j] = new Cell(rndVal, i, j); // the object has a random value of 0 or 1, and then also sends the position in the 2d array
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*
         * This method gets the values of each neighbour for each cell object
         * Arguments: Original 2D array of cell objects
         */
        public Cell[,] GetNeighbourVals(Cell[,] origArray)
        {
            try
            {
                for (int i = 0; i < origArray.GetLength(0); i++)
                {
                    for (int j = 0; j < origArray.GetLength(1); j++)
                    {
                        origArray[i, j].GetNeighbours(origArray); // gets the neighbour values of each cell in the array
                    }
                }

                return origArray;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return origArray;
        }

        /*
         * This method copies the original array and all its properties into a new array
         * Arguments: Original 2D array of cell objects 
         */
        public Cell[,] CopyArray(Cell[,] origArray)
        {
            try
            {
                Cell[,] newArray = new Cell[origArray.GetLength(0), origArray.GetLength(1)]; // creates an new array with the same dimensions as the original
                for (int i = 0; i < origArray.GetLength(0); i++)
                {
                    for (int j = 0; j < origArray.GetLength(1); j++)
                    {
                        newArray[i, j] = origArray[i, j]; // the new inheirits all properties of the original, including the neighbour values
                    }
                }

                return newArray;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return origArray;
        }

        /*
         * This method applies the rules of Conway's game and updates the values of the grid for the next generation
         * Arguments: Original 2D array of cell objects
         */
        public Cell[,] NextGen(Cell[,] origArray)
        {
            try
            {
                Cell[,] copiedArray = CopyArray(origArray); // create a copy of the original array
                int[] neighbours;
                int counter = 0; // counter tracks the number of alive neighbours around a specific cell

                for (int i = 0; i < copiedArray.GetLength(0); i++)
                {
                    for (int j = 0; j < copiedArray.GetLength(1); j++)
                    {
                        neighbours = copiedArray[i, j].GetNeighbours(origArray); // gets the neigbours for that cell object
                        for (int k = 0; k < neighbours.Length; k++)
                        {
                            if (neighbours[k] == 1) // if neighbour is alive add to the counter
                            {
                                counter++;
                            }
                        }

                        // the code below applies the rules of the game of life
                        if (copiedArray[i, j].GetValue() == 0) // if cell is already dead
                        {
                            if (counter == 3)
                            {
                                copiedArray[i, j] = new Cell(1, i, j); // becomes alive
                            }
                        }

                        else if (copiedArray[i, j].GetValue() == 1) // if cell is already alive
                        {
                            if (counter < 2)
                            {
                                copiedArray[i, j] = new Cell(0, i, j); // becomes dead
                            }

                            else if (counter >= 2 && counter <= 3)
                            {
                                copiedArray[i, j].SetValue(1); // stays same
                            }

                            else if (counter > 3)
                            {
                                copiedArray[i, j] = new Cell(0, i, j); // becomes dead
                            }
                        }

                        counter = 0; // reset the counter back to 0 for the next cell in the array
                    }
                }
                return copiedArray;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return origArray; // this is just here so that all code paths return a value. The code never really reaches here

        }

        /*
         * This method outputs the 2D array to the console, in the proper format
         * Arguements: Original 2D array of cell objects
         */
        public void Print2dArray(Cell[,] array)
        {
            try
            {
                while (true)
                {
                    // output the 2D array
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            Console.Write(array[i, j].GetValue()); // only outputs the value of the cell, nothing else
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();

                    array = NextGen(array); // apply rules to get the next generation of the game
                    GetNeighbourVals(array); // get the values of the neighbours for each cell object in the 2D array

                    System.Threading.Thread.Sleep(100); // produces a buffer of 100 milliseconds
                    Console.SetCursorPosition(0, 999); // allows the screen to clear without a flicker

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
