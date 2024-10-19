using Microsoft.AspNetCore.Mvc;
using ParkingManagementData;
using ParkingManagementModels;
using ParkingManagementServices;

namespace ParkingAPI.Controllers
{
    [ApiController]
    [Route("api/park")]
    public class ParkController : Controller
    {
        ParkBL parkbl;

        public ParkController()
        {
            parkbl = new ParkBL();
        }

        [HttpGet]
        [Route("displayparkedcars")]
        public IEnumerable<User> GetParked()
        {
            var activeusers = parkbl.GetParked();

            List<User> users = new List<User>();

            foreach (var item in activeusers)
            {
                users.Add(new User { plateNum = item.plateNum, colorCar = item.colorCar});
            }

            return users;
        }

        [HttpPost]
        [Route("carsthatwillpark")]
        public JsonResult AddCar(User request)
        {
            parkbl.CreateCar(request.plateNum, request.colorCar);

            return new JsonResult("Okay Cool! Here's the parking ticket!");
        }

        [HttpPatch]
        [Route("carsthatneedstobeupdate")]
        public JsonResult UpdateCar(update request)
        {
            parkbl.UpdateCar(request.oldplatenum, request.updateplatenum, request.updatedcolorCar);

            return new JsonResult("Okay Cool! The Data of that Car is Updated!");
        }

        [HttpDelete]
        [Route("carsthatwillgo")]
        public JsonResult DeleteCar(User request)
        {
            parkbl.DeleteCar(request.plateNum);

            return new JsonResult("Okay Cool! The Data of that Car is Deleted!");
        }


    }
}
