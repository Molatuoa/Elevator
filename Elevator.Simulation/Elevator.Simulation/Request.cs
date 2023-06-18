
namespace Elevator.Simulation
{
    public class Request
    {
        public int CurrentFloor;
        public int DesiredFloor;
        public int NumberInTransit;
        public Request(int currentFloor, int desiredFloor, int numberInTransit)
        {
            CurrentFloor = currentFloor;
            DesiredFloor = desiredFloor;
            this.NumberInTransit = numberInTransit;
        }
    }
}
