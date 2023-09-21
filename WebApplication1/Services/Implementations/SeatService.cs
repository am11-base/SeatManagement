using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Implementations;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class SeatService : ISeatService
    {
        private readonly IRepository<Seat> repository;
        private readonly IFacilityService facilityService;
        private readonly ISeatRepo seatRepo;

        public SeatService(IRepository<Seat> repository, IFacilityService facilityService, ISeatRepo seatRepo)
        {
            this.repository = repository;
            this.facilityService = facilityService;
            this.seatRepo = seatRepo;
        }
        public string AddSeats(SeatDto seatData)
        {
            string message;
            if (!facilityService.CheckIfExists(seatData.FacilityId))
            {
                message = "Facility Not Found";
                return message;
            }
            else
            {
                var facilityAbbreviation = facilityService.GetFacilityAbbreviation(seatData.FacilityId);
                for (int i = 0; i < seatData.countOfSeats; i++)
                {
                    string seatName = $"{facilityAbbreviation}-{GetSeatNumber(seatData.FacilityId)}";
                    Seat seat = new Seat { FacilityId = seatData.FacilityId, SeatName = seatName };
                    repository.Add(seat);
                }
                return "Seats Added";
            }
        }
        private string GetSeatNumber(int facilityId)
        {
            string lastSeat = seatRepo.getLastAllocatedSeat(facilityId);
            if (lastSeat == null)
            {
                return "S001";
            }
            else
            {
                string numericPart = lastSeat.Substring(lastSeat.LastIndexOf("S") + 1);
                int number = int.Parse(numericPart);
                number++;
                return "S" + number.ToString("D3");
            }
        }

        public FacilityAssetsDto<Seat> GetFreeSeats(string facility)
        {
            int facilityId = int.Parse(facility);
            //var facilityIdArray = facility.Split(',').Select(int.Parse).ToList();
            FacilityAssetsDto<Seat> facilityAssetsDto = new FacilityAssetsDto<Seat>();
            if (!facilityService.CheckIfExists(facilityId))
            {
                facilityAssetsDto.FacilityId = -1;

            }
            else
            {
                var listOfSeats = seatRepo.GetFreeSeats(facilityId);

                facilityAssetsDto.FacilityId = facilityId;
                facilityAssetsDto.Assets = listOfSeats;
            }
            return facilityAssetsDto;
        }
        public int GetSeatId(int facilityId, string name)
        {
            return seatRepo.GetSeatId(facilityId, name);
        }
        public bool CheckIfAllocated(int seatId)
        {
            return repository.GetById(seatId).IsAssigned;
        }
        public void AllocateSeat(int seatId)
        {
            var seat = repository.GetById(seatId);
            seat.IsAssigned = true;
            repository.Update(seat);
        }
    }
}
