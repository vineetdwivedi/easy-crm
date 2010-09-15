using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCRM.Model.Domains
{
    public partial class Contact
    {


    }
    
    public enum ContactStatus
    {
        Active = 1,
        Abandoned,
        Reliable,
        UnReliable
    }
}
