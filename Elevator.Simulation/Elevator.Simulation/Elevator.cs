using System;
using System.Threading;

namespace Elevator.Simulation
{
    public class Elevator
    {
        public string IdElevator { get; set; }

        private bool[] Ready { get; set; }
        public int CurrentFloor { get; set; } = 1;
        public int Capacity { get; set; } = 21;
        public Direction direction { get; set; }

        public Elevator(int NumOfFloors)
        {
            direction = Direction.Stopped;
            //This is used to have unique id for the elevator
            IdElevator = Guid.NewGuid().ToString("D");
            //plus one so that we dont have out of bound exeption
            Ready = new bool[NumOfFloors + 1];
        }
        public void ProcessRequest(Request request)
        {
            Ready[request.DesiredFloor] = true;
            if (CurrentFloor > request.CurrentFloor)
            {
                Console.WriteLine($"Elevator {IdElevator} Moving Down from floor {CurrentFloor} to pick from floor {request.CurrentFloor}");
                ProcessDownRequest(request, CurrentFloor, request.CurrentFloor);
                if(request.CurrentFloor < request.DesiredFloor)
                {
                    Console.WriteLine($"Closing door Moving up from floor {request.CurrentFloor} to destination {request.DesiredFloor} with {request.NumberInTransit} people");
                    ProcessUpRequest(request, request.CurrentFloor, request.DesiredFloor);
                }
                else
                {
                    Console.WriteLine($"Closing door Moving Down from floor {request.CurrentFloor} to destination {request.DesiredFloor} with {request.NumberInTransit} people");
                    ProcessDownRequest(request, request.CurrentFloor + 1, request.DesiredFloor);
                }
            }
            else
            {
                Console.WriteLine($"Elevator {IdElevator} Moving up from floor {CurrentFloor} to pick up from floor {request.CurrentFloor}");
                ProcessUpRequest(request, CurrentFloor, request.CurrentFloor);

                if(request.CurrentFloor > request.DesiredFloor)
                {
                    Console.WriteLine($"Closing door Moving Down from floor {request.CurrentFloor} to destination {request.DesiredFloor} with {request.NumberInTransit} people");
                    ProcessDownRequest(request, request.CurrentFloor, request.DesiredFloor);
                }
                else
                {
                    Console.WriteLine($"Closing door Moving up from floor {request.CurrentFloor} to destination {request.DesiredFloor}  with {request.NumberInTransit} people");
                    ProcessUpRequest(request, request.CurrentFloor + 1, request.DesiredFloor);
                }
                
            }

        }
        private void StopElevator(int CurrFloor)
        {
            CurrentFloor = CurrFloor;
            direction = Direction.Stopped;
            Ready[CurrFloor] = false;

            Console.WriteLine($"Stopped at floor {CurrentFloor}");
            Console.WriteLine("Waiting..");
        }
        private void ProcessUpRequest(Request request, int start, int Destination)
        {
            direction = Direction.Up;
            for (int i = start; i <= Destination; i++)
            {
                if (Ready[i])
                    StopElevator(request.DesiredFloor);
                else
                {
                    if (i == request.CurrentFloor)
                    {
                        Console.WriteLine($"Picking up at floor {i} Proceeding to floor {request.DesiredFloor}");
                    }
                    Console.WriteLine($"Floor {i}");
                    Thread.Sleep(1000);
                    continue;
                }
            }
        }
        private void ProcessDownRequest(Request request, int Start, int Destination)
        {
            direction = Direction.Down;
            for (int i = Start; i >= Destination; i--)
            {
                if (Ready[i])
                    StopElevator(request.DesiredFloor);
                else
                {
                    if (i == request.CurrentFloor)
                    {
                        Console.WriteLine($"Picking up at floor {i} Proceeding to floor {request.DesiredFloor}");
                    }
                    Console.WriteLine($"Floor {i}");
                    Thread.Sleep(1000);
                    continue;
                }
            }
        }

    }
}
