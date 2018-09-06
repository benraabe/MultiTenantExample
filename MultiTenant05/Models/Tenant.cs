using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTenant05.Models
{
    public class Tenant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Host { get; set; }

        public string Title { get; set; }

        public string Theme { get; set; }
    }
}