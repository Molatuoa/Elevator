using System;
using System.Threading;

namespace Elevator.Simulation
{
    public class GetUseInput
    {
        private int floors;

        public int GetBuildingHight()
        {
           return GetInputs(GetBuildingHight, "Please enter the number of floors in the building!");
        }
        public int GetElevatorCount()
        {
            return GetInputs(GetElevatorCount, "Please enter how many elevators are there!");
        }
        public int GetCurrentUserFloor()
        {
            return GetInputs(GetCurrentUserFloor, "Please enter your current floor!");
        }
        public  int GeDestinationFloor()
        {
            return GetInputs(GeDestinationFloor, "Please enter your destination floor!");
        }
        public int GetTotalNumberToBoard()
        {
            return GetInputs(GetTotalNumberToBoard, "Please enter the Number of people waiting");
        }
        private int GetInputs(Func<int> MethodName, string ConsoleMessage)
        { 
            Console.WriteLine(ConsoleMessage);
            if (!int.TryParse(Console.ReadLine(), out floors))
            {
                InputsError(MethodName);
            }
            if(floors <= 0)
            {
                InputsError(MethodName);
            }
            return floors;
        }
        private void InputsError(Func<int> MethodName)
        {
            Console.WriteLine("Invalid input please try again with numbers starting from 1");
            Thread.Sleep(1000);
            Console.Clear();
            MethodName?.Invoke();
        }
    }
}
