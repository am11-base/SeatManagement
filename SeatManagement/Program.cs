using SeatManagement.Implementations;
using SeatManagement.Interfaces;
using System;
using System.Threading.Tasks;

public class MyClass
{
    public static async Task Main(string[] args)
    {
       
        int choice;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n\t \t Welcome to the Seat Management System");
            Console.WriteLine("\n 1. Onboard a facility");
            Console.WriteLine(" 2. Onboard seats in a location");
            Console.WriteLine(" 3. Onboard cabins");
            Console.WriteLine(" 4. Onboard Meeting Rooms");
            Console.WriteLine(" 5. Upload Employee List");
            Console.WriteLine(" 6. Allocate an employee to an asset");
            Console.WriteLine(" 7. Generate Reports");
            Console.WriteLine(" 8. Exit");

            Console.Write("\n Enter your choice (1-8): ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    IFacilityHandler facility = new FacilityHandler();
                    await facility.AddAsync();
                    break;
                case 2:
                    ISeatHandler seat = new SeatHandler();
                    await seat.AddAsync();
                    break;
                case 3:
                    ICabinHandler cabin = new CabinHandler();
                    await cabin.AddAsync();
                    break;
                case 4:
                    IMeetingRoomHandler meetingRoom = new MeetingRoomHandler();
                    await meetingRoom.AddAsync();
                    break;
                case 5:
                    IEmployeeHandler employee = new EmployeeHandler();
                    await employee.AddAsync();
                    break;
                case 6:
                    IAllocationHandler allocationHandler = new AllocationHandler();
                    await allocationHandler.AddAllocationAsync();
                    break;
                case 7:
                    IReportHandler reportHandler = new ReportHandler();
                    await reportHandler.ReportMenuAsync();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
            }
            Console.ReadLine();
        }
    }
}
