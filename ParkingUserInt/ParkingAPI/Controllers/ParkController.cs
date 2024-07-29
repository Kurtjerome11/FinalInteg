using Microsoft.AspNetCore.Mvc;
using ParkingManagementData;
using ParkingManagementModels;
using ParkingManagementServices;

namespace ParkingAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class ParkController : Controller
    {
        ParkingGServices _userGetServices;
        ParkBL _userTransactionServices;

        public ParkController()
        {
            _userGetServices = new ParkingGServices();
            _userTransactionServices = new ParkBL();
        }

        [HttpGet]
        [Route("displayparkedcars")]
        public IEnumerable<ParkingAPI.User> GetParked()
        {
            var activeusers = _userGetServices.GetUsersByStatus(1);

            List<ParkingAPI.User> users = new List<User>();

            foreach (var item in activeusers)
            {
                users.Add(new ParkingAPI.User { plateNum = item.plateNum, colorCar = item.colorCar, status = item.status });
            }

            return users;
        }

        [HttpPost]
        [Route("carsthatwillpark")]
        public JsonResult AddCar(User request)
        {
            var result = _userTransactionServices.CreateCar(request.plateNum, request.colorCar);

            return new JsonResult(result);
        }

        [HttpPatch]
        [Route("carsthatneedstobeupdate")]
        public JsonResult UpdateCar(User request)
        {
            var result = _userTransactionServices.UpdateCar(request.plateNum, request.colorCar);

            return new JsonResult(result);
        }

        [HttpDelete]
        [Route("carsthatwillgo")]
        public JsonResult DeleteCar(User request)
        {
            var result = _userTransactionServices.DeleteCar(request.plateNum, request.colorCar);

            return new JsonResult(result);
        }


    }
}
