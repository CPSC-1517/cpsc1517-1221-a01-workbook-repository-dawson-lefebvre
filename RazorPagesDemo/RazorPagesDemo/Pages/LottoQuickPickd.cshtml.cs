using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class LottoQuickPickdModel : PageModel
    {
        [BindProperty]
        public string? UserName { get; set; }
        [BindProperty]
        public string LottoType { get; set; }
        [BindProperty]
        public int QuickPickQuantity { get; set; }

        public string? InfoMessage { get; set; }
        public string? ErrorMessage { get; set; }

        public List<int[]> QuickPickNumbers { get; private set; } = new();

        Random random = new Random();
        public void OnPost()
        {
            if(string.IsNullOrWhiteSpace(UserName))
            {
                ErrorMessage = "Name is required";
            }
            else
            {
                InfoMessage = $"Hello {UserName}";
                //Clear the quick pick numbers
                QuickPickNumbers.Clear();
                for(int arrayNumber = 1; arrayNumber <= QuickPickQuantity; arrayNumber++)
                {
                    if (LottoType.ToUpper() == "LOTTO649")
                    {
                        int[] current649Picks = new int[6]; 
                        for(int count = 1; count <= 6; count++)
                        {
                            current649Picks[count - 1] = random.Next(1, 49);
                        }

                        Array.Sort(current649Picks);
                        QuickPickNumbers.Add(current649Picks);
                    }
                }
            }
        }

        public void OnGet()
        {
        }
    }
}
