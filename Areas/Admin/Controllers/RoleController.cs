using Microsoft.AspNetCore.Mvc;
using PBL3.Areas.Admin.Models.DAL;
using PBL3.Models;

namespace PBL3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private RoleDAL roleDal;

        private List<Role> roles;
        public RoleController()
        {
            roleDal = new RoleDAL();
            roles = roleDal.GetAllRoles();
        }
        public IActionResult Index()
        {
           
            return View(roles);
        }

        public IActionResult AddRole() {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role) {
            
            roleDal.AddRole(role);
            return RedirectToAction("Index");   
        }
        public IActionResult DeleteRole(int id)
        {
            roleDal.DeleteRole(id);
            return RedirectToAction("Index");
        }
        public IActionResult EditRole(int? id)
        {
            if(id == null )
            {
                return NotFound();
            }
            int roleId = id.Value;

          
            Role role = roles.FirstOrDefault(r => r.RoleID == roleId);
            if(role == null)
            {
                return NotFound();
            }
            return View(role);
            
        }
        [HttpPost]
        public IActionResult EditRole(int id, Role role) {
        
            if(id != role.RoleID)
            {
                return NotFound();
            }
            roleDal.EditRole(role);
            return View(role);
        }
    }
}
