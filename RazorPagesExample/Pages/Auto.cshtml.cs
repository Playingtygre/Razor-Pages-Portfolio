using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExample.Models;

namespace RazorPagesExample.Pages
{
    public class AutoModel : PageModel
    {
        private readonly IAutoService _autoService;

        [BindProperty]
        public Auto Auto { get; set; }

        public AutoModel(IAutoService autoService)
        {
            _autoService = autoService;
        }


        public async Task OnGetAsync(long? id)
        {
            if (id.HasValue)
            {
                Auto = await _autoService.FindAsync(id);
            }
            else
            {
                Auto = await _autoService.GetRandomAsync();
            }

        }

        /*
        public void OnGet()
        {

        }*/
    }
}