using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent 
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
