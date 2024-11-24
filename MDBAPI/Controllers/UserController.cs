using Microsoft.AspNetCore.Mvc;

namespace MDBAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        UserGetServices _userGetServices;
        UserTransactionServices _userTransactionServices;
        public UserController()
        {
            _userGetServices = new UserGetServices();
            _userTransactionServices = new UserTransactionServices();
        }
        [HttpGet]
        public IEnumerable<MDBAPI.User> GetUsers()
        {
            var activeusers = _userGetServices.GetUsersByStatus(1);

            List<MDBAPI.User> users = new List<User>();

            foreach (var item in activeusers)
            {
                users.Add(new MDBAPI.User { Itemname = item.Itemname, Category = item.category,Code = item.code});


            }
            return users;
        }
        [HttpPost]
        public JsonResult AddUser(User request)
        {
            var result = _userTransactionServices.CreateUser(request.ItemName, request.Category,request.Code);

            return new JsonResult(result);
        }





        [HttpPatch]
        public JsonResult UpdateUser(User request)
        {
            var result = _userTransactionServices.UpdateUser(request.ItemName, request.Category, request.Code);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteUser(User request)
        {
            var result = _userTransactionServices.DeleteUser(request.ItemName, request.Category, request.Code);

            return new JsonResult(result);

        }
    }
}


