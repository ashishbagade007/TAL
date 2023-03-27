
-------------------------------------DESCRIPTION-------------------------------------------------
1. This is a small utility to read footall standard scores format such as team, matches played,
	won, lost, goals for, goals against and points.
2. This utility reads the csv file and outputs the team with the least goal difference.
3. There are required sanity checks in place to validate the file before processing its contents.

-------------------------------------DESIGN AND FEATURE---------------------------------------
1. Implemented a very user friendly and extensible plug and play apparatus using xml file to define
	the columns and their order.
2. Also implemented the rule engine using xml and defining the operations there. This could be extended
	in the future.
3. Implemented ABSTRACT FACTORY design pattern and made the solution very abstract so that it could cater for different
	sports other than football, with its own rule engine and all.
4. Implemented Logger functionality using SINGLETON pattern which writes to a log file.
5. Implemented appropriate Unit Tests to test out the solution.