# Elevator Simulation

##External Sources

 -- This was sourced from stack overflow it has as advantage that you don't have to sort the list first. 
	This means that you have a time complexity of O(n) instead of O(n*log(n)) and a memory usage of O(1) instead of O(n).
 -- https://stackoverflow.com/questions/5953552/how-to-get-the-closest-number-from-a-listint-with-linq
    int closest = id.Aggregate((x, y) => Math.Abs(x - request.CurrentFloor) < Math.Abs(y - request.CurrentFloor) ? x : y);

##ON START

The following set ups will be done
--  The Elevator have to be in a building and we need to know how tall is that building in terms of floors.
	You can enter as many floors as you want eg 20 (All elevators will run from floor 1 - 20)
	
--  Then after the building set up we need to know how many elevators will run 
	If we have 5 they will all start from floor 1 and each will have a Guid just to check and unique identification
	This Guid is used to be displyed and where the elevator is or moving and in which direction also how many people are on board.
	There is also hard coded capacity(21) for every elevator so as to restrict more people than the capacity within the elevator

--	Elevator pick was not specified in the spec, so i made an assumption that all people getting inside the elevator will be dropped at the same destination
--	Console log messages were made slow (Thread.Sleep(1000)) just for readability.

--	Movement can be simulated like below


Please enter the number of floors in the building!
20
Please enter how many elevators are there!
3

-- The Lines above only show on initial load

Please enter your current floor!
5
Please enter your destination floor!
19
Please enter the Number of people waiting
10
Elevator 2e261fec-87e8-40c3-8790-c46302cef4a0 Moving up from floor 1 to pick up from floor 5
Floor 1
Floor 2
Floor 3
Floor 4
Picking up at floor 5 Proceeding to floor 19
Floor 5
Closing door Moving up from floor 5 to destination 19  with 10 people
Floor 6
Floor 7
Floor 8
Floor 9
Floor 10
Floor 11
Floor 12
Floor 13
Floor 14
Floor 15
Floor 16
Floor 17
Floor 18
Stopped at floor 19
Waiting..
Please enter your current floor!