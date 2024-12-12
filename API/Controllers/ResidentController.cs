using System.Reflection;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentController : Controller
    {
        private readonly ApplicationDbContext context;

        public ResidentController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Resident> GetResident()
        {
            return context.residents
                          .Where(r => r.is_deleted != "1")
                          .OrderByDescending(r => r.residentID)
                          .ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetResidents(int id)
        {
            var resident = context.residents.Find(id);
            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident);
        }

        [HttpPost]
        public IActionResult CreateResident(ResidentDTO residentDTO)
        {
            var otherResident = context.Administrators.FirstOrDefault(r => r.email == residentDTO.Email);
            if (otherResident != null)
            {
                ModelState.AddModelError("Email", "The Email Address is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var resident = new Resident
            {
                householdID = 1,
                first_name = residentDTO.First_name,
                middle_name = residentDTO.Middle_name,
                last_name = residentDTO.Last_name,
                email = residentDTO.Email,
                relation_to_head = residentDTO.Relation_to_head,
                gender = residentDTO.Gender,
                birth_date = residentDTO.Birth_date,
                is_head_of_household = residentDTO.Is_head_of_household,
                is_deleted = "0",
                date_inserted = residentDTO.Date_inserted ?? DateOnly.FromDateTime(DateTime.Now),
                has_disability = residentDTO.Has_disability,
                pre_existing_condition = residentDTO.Pre_existing_condition,
                covid_vaccinated = residentDTO.Covid_vaccinated,
                highest_level_completed = residentDTO.Highest_level_completed,
                school_name = residentDTO.School_name,
                employment_status = residentDTO.Employment_status,
                job_title = residentDTO.Job_title,
                monthly_income = residentDTO.Monthly_income
            };

            context.residents.Add(resident);
            context.SaveChanges();

            return Ok(resident);
        }

        [HttpPut("{id}")]
        public IActionResult EditResident(int id, ResidentDTO residentDTO)
        {
            var otherResident = context.residents.FirstOrDefault(r => r.residentID != id && r.email == residentDTO.Email);
            if (otherResident != null)
            {
                ModelState.AddModelError("Email", "The Email Address is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);

            }

            var resident = context.residents.Find(id);
            if (resident == null)
            {
                return NotFound();
            }

                resident.first_name = residentDTO.First_name;
                resident.middle_name = residentDTO.Middle_name;
                resident.last_name = residentDTO.Last_name;
                resident.email = residentDTO.Email;
                resident.relation_to_head = residentDTO.Relation_to_head;
                resident.gender = residentDTO.Gender;
                resident.birth_date = residentDTO.Birth_date;
                resident.is_head_of_household = residentDTO.Is_head_of_household;
                resident.has_disability = residentDTO.Has_disability;
                resident.pre_existing_condition = residentDTO.Pre_existing_condition;
                resident.covid_vaccinated = residentDTO.Covid_vaccinated;
                resident.highest_level_completed = residentDTO.Highest_level_completed;
                resident.school_name = residentDTO.School_name;
                resident.employment_status = residentDTO.Employment_status;
                resident.job_title = residentDTO.Job_title;
                resident.monthly_income = residentDTO.Monthly_income;



            context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}/delete")]
        public IActionResult DeleteResident(int id)
        {
            var resident = context.residents.Find(id);
            if (resident == null)
            {
                return NotFound();
            }

            resident.is_deleted = "1";

            context.SaveChanges();

            return Ok();
        }
    }
}
