using WebApplication1.DTOs;
using WebApplication1.Exceptions;
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
            if (!facilityService.CheckIfExists(seatData.FacilityId))
            {
                throw new NotFoundException("Facility Not Found");
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
            string? lastSeat = seatRepo.getLastAllocatedSeat(facilityId);
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

        public FacilityAssetsDto<Seat> GetFreeSeats(string? facility,bool? isFree)
        {
            if (string.IsNullOrEmpty(facility) || isFree == false)
                throw new BadRequestException("wrong filter");
           
            int facilityId = int.Parse(facility);
            FacilityAssetsDto<Seat> facilityAssetsDto = new FacilityAssetsDto<Seat>();
            if (!facilityService.CheckIfExists(facilityId))
            {
                throw new BadRequestException("facility not exist");

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
           var seatId= seatRepo.GetSeatId(facilityId, name);
            if (seatId == null)
                throw new BadRequestException("seat not found");
            else
                return (int)seatId;
            
        }
        public bool CheckIfExists(int seatId)
        {
            var seat = repository.GetById(seatId);
            if(seat== null)
                return false;
            return true;
        }
        public bool CheckIfAllocated(int seatId)
        {
            return repository.GetById(seatId)!.IsAssigned;
        }
        public void AllocateSeat(int seatId)
        {
            var seat = repository.GetById(seatId)!;
            seat.IsAssigned = true;
            repository.Update(seat);
        }

    }
}
