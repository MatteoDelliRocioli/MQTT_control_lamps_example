using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using message_service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace control_lamps_web_interface.Pages
{
    public class Control_LampsModel : PageModel
    {
        [BindProperty]
        public Lamp Input { get; set; }

        public void OnGet()
        {
            Input = new Lamp();
        }

        public async Task OnPost()
        {
            var lamp = new Lamp
            {
                Name = Input.Name,
                Color= Input.Color
            };

            RedirectToPage();
        }
    }
}