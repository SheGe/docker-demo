using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyDemoApp.Pages
{
    public class IndexModel : PageModel
    {
        public async void OnGetAsync()
        {
            Directory.CreateDirectory("./data");
            using (var stream = System.IO.File.AppendText("./data/test.log"))
            {
                await stream.WriteLineAsync($"{DateTime.Now}: My super message");
            }
        }
    }
}
