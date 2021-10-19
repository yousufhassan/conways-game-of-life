using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Namespace: game_of_life_yousuf
Class: ICS4U
ClassName: Cell
Description: This class creates the outline for a Cell object and contains the methods to get the neighbours of a cell, set the value of a cell,
             and get the value of a cell.
Name: Yousuf Hassan
Date: March 4, 2020
Notes: The SetValue method was giving me errors and updating values in both the original grid and copied grid (in the Grid class), so I did not end
       up using it. I just updated the value of the cell in a different way.
*/

namespace game_of_life_yousuf
{
    class Cell
    {
        private int value;
        private int nb1; // top left
        private int nb2; // top middle
        private int nb3; // top right
        private int nb4; // middle left
        private int nb5; // middle right
        private int nb6; // bottom left
        private int nb7; // bottom middle
        private int nb8; // bottom right
        private int[] position = new int[2]; // location of the cell object in the 2d array

        /* Overloaded constructor for a cell object
         * Arguments: Value of the cell object, the row it is in of the 2d array, the column it is in of the 2d array
         */
        public Cell(int val, int row, int column)
        {
            this.value = val;
            this.position[0] = row;
            this.position[1] = column;
        }

        /* Method to get the values of the neighbours of a cell object
         * Arguments: original 2d array of cell objects
         */
        public int[] GetNeighbours(Cell[,] cells)
        {
            try
            {
                // get the value of the neighbour cell if it exists
                // if the there is no cell there, then make the value irrelevant (-1)
                if (this.position[0] == 0 || this.position[0] == cells.GetLength(0) - 1 || this.position[1] == 0 || this.position[1] == cells.GetLength(1) - 1) // if the cell is on the edges
                {
                    if (this.position[0] == 0 && this.position[1] == 0) // if the cell is the top left
                    {
                        this.nb1 = -1;
                        this.nb2 = -1;
                        this.nb3 = -1;
                        this.nb4 = -1;
                        this.nb5 = cells[this.position[0], this.position[1] + 1].GetValue();
                        this.nb6 = -1;
                        this.nb7 = cells[this.position[0] + 1, this.position[1]].GetValue();
                        this.nb8 = cells[this.position[0] + 1, this.position[1] + 1].GetValue();
                    }

                    else if (this.position[0] == 0 && this.position[1] == cells.GetLength(1) - 1) // if the cell is the top right
                    {
                        this.nb1 = -1;
                        this.nb2 = -1;
                        this.nb3 = -1;
                        this.nb4 = cells[this.position[0], this.position[1] - 1].GetValue();
                        this.nb5 = -1;
                        this.nb6 = cells[this.position[0] + 1, this.position[1] - 1].GetValue();
                        this.nb7 = cells[this.position[0] + 1, this.position[1]].GetValue();
                        this.nb8 = -1;
                    }

                    else if (this.position[0] == cells.GetLength(0) - 1 && this.position[1] == 0) // if the cell is the bottom left
                    {
                        this.nb1 = -1;
                        this.nb2 = cells[this.position[0] - 1, this.position[1]].GetValue();
                        this.nb3 = cells[this.position[0] - 1, this.position[1] + 1].GetValue();
                        this.nb4 = -1;
                        this.nb5 = cells[this.position[0], this.position[1] + 1].GetValue();
                        this.nb6 = -1;
                        this.nb7 = -1;
                        this.nb8 = -1;
                    }

                    else if (this.position[0] == cells.GetLength(0) - 1 && this.position[1] == cells.GetLength(1) - 1) // if the cell is the bottom right
                    {
                        this.nb1 = cells[this.position[0] - 1, this.position[1] - 1].GetValue();
                        this.nb2 = cells[this.position[0] - 1, this.position[1]].GetValue();
                        this.nb3 = -1;
                        this.nb4 = cells[this.position[0], this.position[1] - 1].GetValue();
                        this.nb5 = -1;
                        this.nb6 = -1;
                        this.nb7 = -1;
                        this.nb8 = -1;
                    }

                    else if (this.position[0] == 0 && this.position[1] != 0 && this.position[1] != cells.GetLength(1) - 1) // top row excluding corners
                    {
                        this.nb1 = -1;
                        this.nb2 = -1;
                        this.nb3 = -1;
                        this.nb4 = cells[this.position[0], this.position[1] - 1].GetValue();
                        this.nb5 = cells[this.position[0], this.position[1] + 1].GetValue();
                        this.nb6 = cells[this.position[0] + 1, this.position[1] - 1].GetValue();
                        this.nb7 = cells[this.position[0] + 1, this.position[1]].GetValue();
                        this.nb8 = cells[this.position[0] + 1, this.position[1] + 1].GetValue();
                    }

                    else if (this.position[0] == cells.GetLength(0) - 1 && this.position[1] != 0 && this.position[1] != cells.GetLength(1) - 1) // bottom row excluding corners
                    {
                        this.nb1 = cells[this.position[0] - 1, this.position[1] - 1].GetValue();
                        this.nb2 = cells[this.position[0] - 1, this.position[1]].GetValue();
                        this.nb3 = cells[this.position[0] - 1, this.position[1] + 1].GetValue();
                        this.nb4 = cells[this.position[0], this.position[1] - 1].GetValue();
                        this.nb5 = cells[this.position[0], this.position[1] + 1].GetValue();
                        this.nb6 = -1;
                        this.nb7 = -1;
                        this.nb8 = -1;
                    }

                    else if (this.position[1] == 0 && this.position[0] != 0 && this.position[0] != cells.GetLength(0) - 1) // first column excluding corners
                    {
                        this.nb1 = -1;
                        this.nb2 = cells[this.position[0] - 1, this.position[1]].GetValue();
                        this.nb3 = cells[this.position[0] - 1, this.position[1] + 1].GetValue();
                        this.nb4 = -1;
                        this.nb5 = cells[this.position[0], this.position[1] + 1].GetValue();
                        this.nb6 = -1;
                        this.nb7 = cells[this.position[0] + 1, this.position[1]].GetValue();
                        this.nb8 = cells[this.position[0] + 1, this.position[1] + 1].GetValue();
                    }

                    else if (this.position[1] == cells.GetLength(1) - 1 && this.position[0] != 0 && this.position[0] != cells.GetLength(0) - 1) // last column excluding corners
                    {
                        this.nb1 = cells[this.position[0] - 1, this.position[1] - 1].GetValue();
                        this.nb2 = cells[this.position[0] - 1, this.position[1]].GetValue();
                        this.nb3 = -1;
                        this.nb4 = cells[this.position[0], this.position[1] - 1].GetValue();
                        this.nb5 = -1;
                        this.nb6 = cells[this.position[0] + 1, this.position[1] - 1].GetValue();
                        this.nb7 = cells[this.position[0] + 1, this.position[1]].GetValue();
                        this.nb8 = -1;
                    }
                }

                else // if the cell is in the middle of the grid (not the edges)
                {
                    this.nb1 = cells[this.position[0] - 1, this.position[1] - 1].GetValue();
                    this.nb2 = cells[this.position[0] - 1, this.position[1]].GetValue();
                    this.nb3 = cells[this.position[0] - 1, this.position[1] + 1].GetValue();
                    this.nb4 = cells[this.position[0], this.position[1] - 1].GetValue();
                    this.nb5 = cells[this.position[0], this.position[1] + 1].GetValue();
                    this.nb6 = cells[this.position[0] + 1, this.position[1] - 1].GetValue();
                    this.nb7 = cells[this.position[0] + 1, this.position[1]].GetValue();
                    this.nb8 = cells[this.position[0] + 1, this.position[1] + 1].GetValue();
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            int[] neighbours = new int[8] { this.nb1, this.nb2, this.nb3, this.nb4, this.nb5, this.nb6, this.nb7, this.nb8 };
            return neighbours;
        }

        public int GetValue()
        {
            return this.value;
        }

        public void SetValue(int val)
        {
            this.value = val;
        }

    }
}
