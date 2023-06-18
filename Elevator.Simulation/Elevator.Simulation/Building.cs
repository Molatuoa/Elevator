using System;
using System.Collections.Generic;
using System.Linq;

namespace Elevator.Simulation
{
    public class Building
    {
        private int NumOfFloors { get; set; }
        private List<Elevator> Elevators { get; set; }

        public Building(int BuildingHight, int ElevatorCount)
        {
            NumOfFloors = BuildingHight;
            Elevators = new List<Elevator>();
            for (int i = 0; i < ElevatorCount; i++)
            {
                Elevator objElevator = new Elevator(BuildingHight);
                Elevators.Add(objElevator);
            }
        }
        public Elevator GetClosestElevator(Request request)
        {
            List<int> id = Elevators.Where(x =>x.direction == Direction.Stopped).Select(x => x.CurrentFloor).ToList();
            //This was sourced from stack overflow it has as advantage that you don't have to sort the list first. This means that you have a time complexity of O(n) instead of O(n*log(n)) and a memory usage of O(1) instead of O(n).
            //https://stackoverflow.com/questions/5953552/how-to-get-the-closest-number-from-a-listint-with-linq
            int closest = id.Aggregate((x, y) => Math.Abs(x - request.CurrentFloor) < Math.Abs(y - request.CurrentFloor) ? x : y);
            return Elevators.FirstOrDefault(x => x.CurrentFloor == closest && x.direction == Direction.Stopped); ;
        }
    }
}
