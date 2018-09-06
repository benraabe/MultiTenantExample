using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultiTenant05.Models;

namespace MultiTenant05.DataAccess
{
    public interface IDataConnection
    {
        Tenant GetTenant(string host);
    }
}