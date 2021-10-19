## Game of Life by Yousuf Hassan.

# Purpose
This program is based on John Conway's Game of Life. It was created as the final project for the final project for my grade 12 computer science course, ICS4U.
The main goal of this project was to create a program focusing on writing clean code and following object oriented program.

# Description:
This program creates a 2D grid comprised of individual cell objects.
The dimensions of the 2D grid are inputted by the user when they are prompted.
It can only accept integer values.

Each cell object has the following properties:
<ul>	<li> An integer value of either 0 or 1, meaning the cell is either dead or alive, respectively. </li>
	<li> An integer tuple that stores the position of the cell. </li>
	<li> Eight integer values that store the value of each neighbour of the cell. </li>
</ul>

After populating the the grid with cell objects, it randomly assigns the cell with a value of 0 or 1.

Then, it gets the values of the neighbours for each cell object.
For neighbours that don't exist within the dimensions of the array, it assigns it a value of -1, so that it is insignificant.
Alive neighbours have a value of 1 and dead neighbours have a value of 0.

Then, it outputs the 2D array to the console in the proper format using nested for loops.

Then, it applies the rules of Conway's Game of Life to generate the next generation of the grid.
	To do this, a second 2D array of cell objects is created.
		This array is the same dimensions as the original array and it has the exact same cell objects.
		This is done using nested for loops and making each index of the copied array equal to the respective index of the original array.
	The game rules are applied to the original array, and any changes that need to be made are happening to the copied array.
		This way, the grid can be updated according to the original grid and not the new changes made.

Once the new generation is created, the program gets the values of the neighbour cells for each index again.
Now it outputs the next generation of the grid to the console again.

The application of the rules, getting the new values of the neighbours and outputting the next generation repeats until the user closes the program.

# Rules of John Conway's Game of Life:
<ol>	<li> A live cell with less than 2 neighbors will die (due to under population). </li>
	<li> A live cell 2-3 neighbors lives on to the next generation. </li>
	<li> A live cell with more than 3 neighbors dies (due to overpopulation). </li>
	<li> A dead cell with EXACTLY 3 neighbors becomes a live cell (from reproduction). </li>
</ol>

