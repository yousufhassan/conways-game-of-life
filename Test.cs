using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Namespace: game_of_life_yousuf
Class: ICS4U
ClassName: Test
Description: This purpose of this class is to test each method in the solution with good and bad data, ensuring it doesn't break.
Name: Yousuf Hassan
Date: March 27, 2020
Notes:
*/

namespace game_of_life_yousuf
{
    class Test
    {
        /*
         * This method tests the instantiation of the Grid object
         * Arguments: None
         */
        public void TestGrid()
        {
            // if the Grid parameter is positive
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells = grid.Create2dArray();
                grid.Print2dArray(cells);
                Console.WriteLine("This is a valid input");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // if the Grid parameter is 0
            try
            {
                Grid gridTwo = new Grid(0);
                Cell[,] cells = gridTwo.Create2dArray();
                gridTwo.Print2dArray(cells);
                Console.WriteLine("This is a valid input");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // if the Grid parameter is negative
            try
            {
                Grid gridThree = new Grid(-4);
                Cell[,] cells = gridThree.Create2dArray();
                gridThree.Print2dArray(cells);
                Console.WriteLine("This is a valid input");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*
         * This method tests the Create2dArray function located in the Grid class
         * Arguments: None
         */
        public void TestCreate2dArray()
        {
            // there are no parameters, so it is just testing to see if the method works
            try
            {
                Grid grid = new Grid(2);
                grid.Create2dArray();
                Console.WriteLine("This method works!");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*
         * This method tests the PopulateRandom function located in the Grid class
         * Arguments: None
         */
        public void TestPopulateRandom()
        {
            // if the method parameter is correctly initialized 
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells = grid.Create2dArray();
                grid.PopulateRandom(cells);
                Console.WriteLine("This method works!");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // NOT DONE YET!
            // if the method parameter is not initialized
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells;
                //grid.PopulateRandom(cells);
                Console.WriteLine("This method works!");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*
         * This method tests the GetNeighbourVals function located in the Grid class
         * Arguments: None
         */
        public void TestGetNeighbourVals()
        {
            // if 2D array of cell objects is correctly initialized and randomly populated
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells = grid.Create2dArray();
                grid.PopulateRandom(cells);
                grid.GetNeighbourVals(cells);
                Console.WriteLine("This method works!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // if 2D array of cell objects is not populated (all values are null)
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells = grid.Create2dArray();
                grid.GetNeighbourVals(cells);
                Console.WriteLine("This method works!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*
         * This method tests the CopyArray function located in the Grid class
         * Arguments: None
         */
        public void TestCopyArray()
        {
            // if 2D array of cell objects is correctly initialized, randomly populated, and neighbour values are retrieved
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells = grid.Create2dArray();
                grid.PopulateRandom(cells);
                grid.GetNeighbourVals(cells);
                grid.CopyArray(cells);
                Console.WriteLine("This method works!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // if 2D array of cell objects is not populated (all values and neighbour values are null)
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells = grid.Create2dArray();
                grid.GetNeighbourVals(cells);
                grid.CopyArray(cells);
                Console.WriteLine("This method works!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*
         * This method tests the NextGen function located in the Grid class
         * Arguments: None
         */
        public void TestNextGen()
        {
            // if 2D array of cell objects is correctly initialized, randomly populated, and neighbour values are retrieved
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells = grid.Create2dArray();
                grid.PopulateRandom(cells);
                grid.GetNeighbourVals(cells);
                grid.NextGen(cells);
                Console.WriteLine("This method works!");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // if 2D array of cell objects is not populated (all values and neighbour values are null)
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells = grid.Create2dArray();
                grid.GetNeighbourVals(cells);
                grid.NextGen(cells);
                Console.WriteLine("This method works!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*
         * This method tests the Print2dArray function located in the Grid class
         * Arguments: None
         */
        public void TestPrint2dArray()
        {
            // if 2D array of cell objects is correctly initialized, randomly populated, and neighbour values are retrieved
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells = grid.Create2dArray();
                grid.PopulateRandom(cells);
                grid.GetNeighbourVals(cells);
                grid.Print2dArray(cells);
                Console.WriteLine("This method works!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // if 2D array of cell objects is not populated (all values and neighbour values are null)
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells = grid.Create2dArray();
                grid.GetNeighbourVals(cells);
                grid.Print2dArray(cells);
                Console.WriteLine("This method works!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*
         * This method tests the GetNeighbours function located in the Cell class
         * Arguments: None
         */
        public void TestGetNeighbours()
        {
            // if 2D array of cell objects is correctly initialized, randomly populated
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells = grid.Create2dArray();
                grid.PopulateRandom(cells);

                for (int i = 0; i < cells.GetLength(0); i++)
                {
                    for (int j = 0; j < cells.GetLength(1); j++)
                    {
                        cells[i, j].GetNeighbours(cells);
                    }
                }

                Console.WriteLine("This method works!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // if 2D array of cell objects is not populated (values are null)
            try
            {
                Grid grid = new Grid(2);
                Cell[,] cells = grid.Create2dArray();

                for (int i = 0; i < cells.GetLength(0); i++)
                {
                    for (int j = 0; j < cells.GetLength(1); j++)
                    {
                        cells[i, j].GetNeighbours(cells);
                    }
                }

                Console.WriteLine("This method works!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
