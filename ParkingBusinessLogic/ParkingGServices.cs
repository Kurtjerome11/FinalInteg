using ParkingManagementData;
using ParkingManagementModels;

namespace ParkingManagementServices
{
    public class ParkingGServices
    {
        private List<Park> GetAllUsers()
        {
            CarDataLogic userData = new CarDataLogic();

            return userData.GetParked();

        }

        public List<Park> GetUsersByStatus(int userStatus)
        {
            List<Park> usersByStatus = new List<Park>();

            foreach (var user in GetAllUsers())
            {
                if (user.status == userStatus)
                {
                    usersByStatus.Add(user);
                }
            }

            return usersByStatus;
        }

        public Park GetUser(string username, string colorCar)
        {
            Park foundUser = new Park();

            foreach (var user in GetAllUsers())
            {
                if (user.plateNum == username && user.colorCar == colorCar)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }

        public Park GetUser(string username)
        {
            Park foundUser = new Park();

            foreach (var user in GetAllUsers())
            {
                if (user.plateNum == username)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }
    }
}