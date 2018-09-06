using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTenant05.Models
{
    public sealed class PageModel
    {
        public PageModel()
        {
        }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Theme { get; set; }
    }
}