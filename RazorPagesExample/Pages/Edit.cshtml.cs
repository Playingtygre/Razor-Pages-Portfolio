using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExample.Models;

namespace RazorPagesExample.Pages
{
    public class EditModel : PageModel
    {
        private readonly IAutoService _autoService;

        [BindProperty]
        public Auto Auto { get; set; }

        [BindProperty]
        public bool IsNewAuto { get; set; }

        public EditModel(IAutoService autoService)
        {
            _autoService = autoService;
        }

        public async Task GetTaskAsync(long? id)
        {
            Auto = await _autoService.FindAsync(id);
            IsNewAuto = Auto is null;
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                bool success;

                if (IsNewAuto)
                {
                    success = await _autoService.AddAsync(Auto);
                }
                else
                {
                    success = await _autoService.UpdateAsync(Auto);
                }

                if (success)
                {
                    return RedirectToPage("Auto", new {id = Auto.Id} );

                }
               
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            await _autoService.RemoveAsync(Auto);
            return RedirectToPage("Index");
        }


        /*public void OnGet()
        {

        }*/
    }
}