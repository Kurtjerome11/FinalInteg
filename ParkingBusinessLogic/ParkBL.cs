using ParkingManagementData;
using ParkingManagementModels;

namespace ParkingManagementServices
{
    public class ParkBL
    {
        ParkingVServices validationServices = new ParkingVServices();
        CarDataLogic userData = new CarDataLogic();

        public bool CreateCar(Park park)
        {
            bool result = validationServices.CheckIfCarExists(park.plateNum);


            if (result)
            {
                userData.AddCar(park);
            }

            return result;
        }

        public bool CreateCar(string plateNum, string colorCar)
        {
            Park park = new Park { plateNum = plateNum, colorCar = colorCar };

            return CreateCar(park);
        }

        public bool UpdateUser(Park park)
        {
            bool result = validationServices.CheckIfCarExists(park.plateNum);

            if (result)
            {
                userData.UpdateUser(park);
            }

            return result;
        }

        public bool UpdateCar(string plateNum, string colorCar)
        {
            Park park = new Park { plateNum = plateNum, colorCar = colorCar };

            return UpdateUser(park);
        }

        public bool DeleteCar(Park park)
        {
            bool result = false;

            if (validationServices.CheckIfCarExists(park.plateNum))
            {
                result = userData.DeleteCar(park) > 0;
            }

            return result;
        }

        public bool DeleteCar(string plateNum, string colorCar)
        {
            Park park = new Park { plateNum = plateNum, colorCar = colorCar };

            return UpdateUser(park);
        }
    }
}
