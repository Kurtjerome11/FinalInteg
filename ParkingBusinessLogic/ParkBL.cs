using ParkingManagementData;
using ParkingManagementModels;

namespace ParkingManagementServices
{
    public class ParkBL
    {
        CarDataLogic userData = new CarDataLogic();
        SqlDbData SqlDbData = new SqlDbData();

        public void CreateCar(string plateNum, string colorCar)
        {
            SqlDbData.AddCar(plateNum, colorCar);
        }

        public List<Park> GetParked()
        {
            return SqlDbData.GetParked();
        }

        public void UpdateCar(string originalplateNum, string updatedplateNum, string updatedcolorCar)
        {
            SqlDbData.UpdateCar(originalplateNum, updatedplateNum, updatedcolorCar);
        }

        public void DeleteCar(string plateNum)
        {
            SqlDbData.DeleteCar(plateNum);
        }
    }
}
