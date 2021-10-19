using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Namespace: game_of_life_yousuf
Class: ICS4U
ClassName: Program
Description: This class creates the grid object and 2D array of Cell objects. Then it calls methods from other classes in order to run.
Name: Yousuf Hassan
Date: March 4, 2020
Notes:
*/

namespace game_of_life_yousuf
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid array = new Grid(2);
            Cell[,] cells = array.Create2dArray();
            array.PopulateRandom(cells); // randomly populate the array with 0s or 1s
            array.GetNeighbourVals(cells); // get the values of the neighbours for each cell object in the 2D array
            array.Print2dArray(cells); // I only call it once in the Main program as it is being looped in the Grid class   
        }
    }
}
