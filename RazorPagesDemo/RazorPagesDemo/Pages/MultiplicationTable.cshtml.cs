using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Pages.Models;

namespace RazorPagesDemo.Pages
{
    public class MultiplicationTableModel : PageModel
    {
        [BindProperty]
        public int DigitRow { get; set; }
        [BindProperty]
        public int DigitColumn { get; set; }

        public TableType? Type { get; set; }

        public void OnPostMultiply()
        {
            Type = TableType.Multiply;
        }

        public void OnPostAdd()
        {
            Type = TableType.Add;
        }

        public void OnPostSubtract()
        {
            Type = TableType.Subtract;
        }

        public void OnGet()
        {
        }
    }
}
