﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prepaid_Mobile_Topup_Core_Web_App.BusinessModel;
using Prepaid_Mobile_Topup_Core_Web_App.Models;

namespace Prepaid_Mobile_Topup_Core_Web_App.Pages.TopUps
{
    public class CreateModel : PageModel
    {
        private readonly Prepaid_Mobile_Topup_Core_Web_App.Models.Prepaid_Mobile_Topup_DataContext _context;

        public CreateModel(Prepaid_Mobile_Topup_Core_Web_App.Models.Prepaid_Mobile_Topup_DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MobileAccountId"] = new SelectList(_context.MobileAccount, "Id", "Number");
        ViewData["TopUpChannelId"] = new SelectList(_context.TopUpChannel, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public TopUp TopUp { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mobile = (from account in _context.MobileAccount
                         where account.Id == TopUp.MobileAccountId select account).FirstOrDefault();

            mobile.Balance = mobile.Balance + TopUp.TopUpAmount;
            _context.TopUp.Add(TopUp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
