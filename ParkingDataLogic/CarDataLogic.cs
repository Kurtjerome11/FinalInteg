using ParkingManagementModels;

namespace ParkingManagementData
{
    public class CarDataLogic
    {
        List<Park> parks;
        public CarDataLogic()
        {
            parks = new List<Park>();
        }

        public List<Park> GetParked()
        {
            return parks;
        }

        public void AddCar(Park park)
        {
            parks.Add(park);
        }

        public void UpdateUser(Park park)
        {
            for (int i = 0; i < parks.Count; i++)
            {
                if (parks[i].plateNum == park.plateNum)
                {
                    parks[i].plateNum = park.plateNum;
                }
            }
        }

        public int DeleteCar(Park park)
        {
            return DeleteCar(park);
        }
    }

}