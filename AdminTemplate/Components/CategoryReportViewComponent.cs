using AdminTemplate.Data;
using Microsoft.AspNetCore.Mvc;

namespace AdminTemplate.Components
{
    public class CategoryReportViewComponent : ViewComponent
    {
        private readonly MyContext _context;

        public CategoryReportViewComponent(MyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = _context;

            return View(data);
        }
    }
}
