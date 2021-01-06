using System;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Uplift.Models.ViewModels
{
    public class ServiceVM
    {
        public Service Service { get; set; }

        public IEnumerable<SelectListItem> MyProperty { get; set; }
    }
}
