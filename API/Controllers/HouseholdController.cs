using System.Data;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseholdController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public HouseholdController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Households> GetHousehold()
        {
            return context.households.OrderByDescending(h => h.HouseholdID).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetHouseholds(int id)
        {
            var household = context.households.Find(id);
            if (household == null)
            {
                return NotFound();
            }

            return Ok(household);
        }

        [HttpPost]
        public IActionResult CreateHousehold(HouseholdDTO householdDTO)
        {
            var otherHousehold = context.households.FirstOrDefault(h => h.Email == householdDTO.email);
            if (otherHousehold != null)
            {
                ModelState.AddModelError("Email", "The Email Address is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var household = new Households
            {

                Family_Name = householdDTO.family_Name,
                Address = householdDTO.address,
                Income = householdDTO.income,
                Email = householdDTO.email,
                Phone = householdDTO.phone,
                House_Type = householdDTO.house_Type,
                Ownership = householdDTO.ownership,
                Profile_Picture = householdDTO.profile_Picture,
                Survey_Date = householdDTO.survey_Date ?? DateTime.Now,
                Survey_By = householdDTO.survey_By = "Me",
                Note = householdDTO.note,
                Ethnicity = householdDTO.ethnicity,
                Religion = householdDTO.religion,
                Primary_Language = householdDTO.primary_Language,
                Secondary_Language = householdDTO.secondary_Language,
                Has_Electricity = householdDTO.has_Electricity,
                Has_Water = householdDTO.has_Water

            };

            context.households.Add(household);
            context.SaveChanges();

            return Ok(household);
        }


        [HttpPut("{id}")]
        public IActionResult EditHousehold(int id, HouseholdDTO householdDTO)
        {
            var otherHousehold = context.households.FirstOrDefault(h => h.HouseholdID != id && h.Email == householdDTO.email);
            if (otherHousehold != null)
            {
                ModelState.AddModelError("Email", "The Email Address is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);

            }

            var household = context.households.Find(id);
            if (household == null)
            {
                return NotFound();
            }

            household.Family_Name = householdDTO.family_Name;
            household.Address = householdDTO.address;
            household.Income = householdDTO.income;
            household.Email = householdDTO.email;
            household.Phone = householdDTO.phone;
            household.House_Type = householdDTO.house_Type;
            household.Ownership = householdDTO.ownership;
            household.Profile_Picture = householdDTO.profile_Picture;
            household.Note = householdDTO.note;
            household.Ethnicity = householdDTO.ethnicity;
            household.Religion = householdDTO.religion;
            household.Primary_Language = householdDTO.primary_Language;
            household.Secondary_Language = householdDTO.secondary_Language;
            household.Has_Electricity = householdDTO.has_Electricity;
            household.Has_Water = householdDTO.has_Water;
            
            context.SaveChanges();

            return Ok();
        }

    }
}
