namespace ParkingManagementServices
{
    public class ParkingVServices
    {

        ParkingGServices getservices = new ParkingGServices();

        public bool CheckIfCarExists(string plateNum)
        {
            bool result = getservices.GetUser(plateNum) != null;
            return result;
        }

        public bool CheckIfCarExists(string plateNum, string colorCar)
        {
            bool result = getservices.GetUser(plateNum, colorCar) != null;
            return result;
        }

    }
}
