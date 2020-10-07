using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Emsapi.Data;
using Emsapi.Helpers;
using Emsapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Emsapi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;

        public ManagerController(DataContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
        {
            return await _context.Expenses.ToListAsync();
        }

        [HttpPost("approveExpense/{expenseId}")]
        public async Task<IActionResult> ApprovePhoto(int expenseId)
        {
            var expense = await _context.Expenses
                .FirstOrDefaultAsync(e => e.Id == expenseId);
            expense.Status = "Approved";


            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("rejectExpense/{expenseId}")]
        public async Task<IActionResult> RejectPhoto(int expenseId)
        {
            var expense = await _context.Expenses
                .FirstOrDefaultAsync(e => e.Id == expenseId);

            expense.Status = "Rejected";



            await _context.SaveChangesAsync();

            return Ok();
        }




    }
}