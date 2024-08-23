using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduZoneAPI3.DbContexts;
using EduZoneAPI3.Interfaces.IServices;
using EduZoneAPI3.Model.ApplicationForm;

namespace EduZoneAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormsController : ControllerBase
    {
        private readonly IApplicationFormService _applicationService;

        public ApplicationFormsController(
            IApplicationFormService applicationFormService)
        {
            _applicationService = applicationFormService;

        }

        // GET: api/ApplicationForms
        [HttpGet]
        public IActionResult GetAll()
        {
          var applicants = _applicationService.GetAll();
            return Ok(applicants);
        }

        // GET: api/ApplicationForms/5
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var applicant = _applicationService.GetById(id);
            return Ok(applicant);
        }
       
        

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationForm(int id, ApplicationForm applicationForm)
        {
            if (id != applicationForm.ApplicationId)
            {
                return BadRequest();
            }

            _context.Entry(applicationForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationFormExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApplicationForms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost ("ApplicationForm")]
        public async Task<ActionResult<ApplicationForm>> PostApplicationForm([FromBody] ApplicationFormDTO ApplicationFormDTO)
        {
            try
            {
                  if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var applicant = new ApplicationForm
                {
                    ApplicantName = ApplicationFormDTO.Name,
                    ApplicantSurname = ApplicationFormDTO.Surname,
                    ApplicantIDNo = ApplicationFormDTO.IdentityNumber,
                    ApplicantGradeLevel=ApplicationFormDTO.gradeLevel



                };

            
            }catch
            {

            }    
        }

        // DELETE: api/ApplicationForms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationForm(int id)
        {
            var applicationForm = await _context.Applications.FindAsync(id);
            if (applicationForm == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(applicationForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationFormExists(int id)
        {
            return _context.Applications.Any(e => e.ApplicationId == id);
        }
    }
}
