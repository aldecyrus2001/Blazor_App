using System.Data;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AdministratorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Administrator> getAdministrators() 
        { 
            return context.Administrators.OrderByDescending(a => a.adminID).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetAdministrator(int id)
        {
            var administrator = context.Administrators.Find(id);
            if (administrator == null)
            {
                return NotFound();
            }

            return Ok(administrator);
        }

        [HttpPost] 
        public IActionResult CreateAdministrator(AdministratorDTO administratoDto)
        {
            var otherAdministrator = context.Administrators.FirstOrDefault(e => e.email == administratoDto.Email);
            if (otherAdministrator != null) 
            {
                ModelState.AddModelError("Email", "The Email Address is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var admin = new Administrator
            {
                firstname = administratoDto.FirstName,
                middlename = administratoDto.MiddleName ?? "",
                lastname = administratoDto.LastName,
                email = administratoDto.Email,
                password = administratoDto.Password,
                role = administratoDto.Role,
                phone = administratoDto.Phone,
                profile_picture = administratoDto.Profile_Picture,
                last_login = administratoDto.Last_Login,
                created_at = administratoDto.Created_At ?? DateTime.Now,
                updated_at = administratoDto.Updated_At,
                token = administratoDto.Token ?? "",
                isDeleted = "0",

            };

            context.Administrators.Add(admin);
            context.SaveChanges();

            return Ok(admin);
        }

        [HttpPut("{id}")]
        public IActionResult EditAdministrator(int id, AdministratorDTO administratorDto) 
        {
            var otherAdministrator = context.Administrators.FirstOrDefault(a => a.adminID != id && a.email == administratorDto.Email);
            if (otherAdministrator != null) 
            {
                ModelState.AddModelError("Email", "The Email Address is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);

            }

            var administrator = context.Administrators.Find(id);
            if (administrator == null)
            {
                return NotFound();
            }

            administrator.firstname = administratorDto.FirstName;
            administrator.middlename = administratorDto.MiddleName ?? "";
            administrator.lastname = administratorDto.LastName;
            administrator.email = administratorDto.Email;
            administrator.password = administratorDto.Password;
            administrator.role = administratorDto.Role;
            administrator.phone = administratorDto.Phone;
            administrator.profile_picture = administratorDto.Profile_Picture;

            context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}/delete")]
        public IActionResult DeleteAdministrator(int id)
        {
            var administrator = context.Administrators.Find(id);
            if (administrator == null)
            {
                return NotFound();
            }

            administrator.isDeleted = "1";

            context.SaveChanges();

            return Ok();
        }


    }
}
