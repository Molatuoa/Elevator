using System;
using System.Threading;

namespace Elevator.Simulation
{
    class Program
    {
        static void Main(string[] args)
        {

            GetUseInput objInputs = new GetUseInput();
            int BuildingHight = objInputs.GetBuildingHight();
            int ElevetorCount = objInputs.GetElevatorCount();
            Building building = new Building(BuildingHight, ElevetorCount);


            while (true)
            {
                int UserCurrentFloor = objInputs.GetCurrentUserFloor();
                int DestinationRequest = objInputs.GeDestinationFloor();
                int PeopleToBoard = objInputs.GetTotalNumberToBoard();
                if (UserCurrentFloor > BuildingHight)
                {
                    InputErrors($"Requested current floor is greater the building floors of {BuildingHight}");
                    continue;
                }
                if (DestinationRequest > BuildingHight)
                {
                    InputErrors($"Requested destination floor is greater the building floors of {BuildingHight}");
                    continue;
                }
               
                Request request = new Request(UserCurrentFloor, DestinationRequest, PeopleToBoard);
                Elevator elevator = building.GetClosestElevator(request);
                if(PeopleToBoard > elevator.Capacity)
                {
                    InputErrors($"The number of people should not be creater than the elevator capacity of {elevator.Capacity}");
                    continue;
                }
                elevator.ProcessRequest(request);
            }

            static void InputErrors(string msg)
            {
                Console.WriteLine(msg);
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
