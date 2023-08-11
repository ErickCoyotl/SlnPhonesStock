using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhonesStock.Shared.DataContexts;
using PhonesStock.Shared.Models;

namespace PhonesStock.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly SQLDBContext _dbContext;

        public PhoneController(SQLDBContext context)
        {
            _dbContext = context;
        }

        [Route("GetPhones")]
        [HttpGet]
        public async Task<IList<Phone>> GetPhones()
        {
            try
            {
                var phones = await _dbContext.Phones.ToListAsync();
                return phones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("GetPhone/{id}")]
        [HttpGet]
        public async Task<Phone> GetPhone(int id)
        {
            try
            {
                var phone = await _dbContext.Phones.FindAsync(id);
                return phone;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("SavePhone")]
        [HttpPost]
        public async Task<IActionResult> SavePhone(Phone phone)
        {
            try
            {
                if (_dbContext.Phones == null)
                {
                    return Problem("Entity set 'SQLDBContext.Phones' is null.");
                }

                if (phone != null)
                {
                    _dbContext.Add(phone);
                    await _dbContext.SaveChangesAsync();

                    return Ok("Phone saved successfully!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        [Route("UpdatePhone")]
        [HttpPost]
        public async Task<IActionResult> UpdatePhone(Phone phone)
        {
            _dbContext.Entry(phone).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
                return Ok("Phone updated successfully!");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(phone.Id))
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

        [HttpDelete("DeletePhone/{id}")]
        public async Task<IActionResult> DeletePhone(int id)
        {
            if (_dbContext.Phones == null)
            {
                return NotFound();
            }

            var phone = await _dbContext.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }

            _dbContext.Phones.Remove(phone);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool PhoneExists(int id)
        {
            return (_dbContext.Phones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
