using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Prepaid_Mobile_Topup_Core_Web_App.BusinessModel;
using Prepaid_Mobile_Topup_Core_Web_App.Models;

namespace Prepaid_Mobile_Topup_Core_Web_App.Pages.TopUpChannels
{
    public class DeleteModel : PageModel
    {
        private readonly Prepaid_Mobile_Topup_Core_Web_App.Models.Prepaid_Mobile_Topup_DataContext _context;

        public DeleteModel(Prepaid_Mobile_Topup_Core_Web_App.Models.Prepaid_Mobile_Topup_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TopUpChannel TopUpChannel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TopUpChannel = await _context.TopUpChannel.FirstOrDefaultAsync(m => m.Id == id);

            if (TopUpChannel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TopUpChannel = await _context.TopUpChannel.FindAsync(id);

            if (TopUpChannel != null)
            {
                _context.TopUpChannel.Remove(TopUpChannel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
