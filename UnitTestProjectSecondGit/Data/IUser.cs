using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondGit.Data
{
    public interface IUser
    {
        string Username { get; }        // Required
        string Password { get; }       // Required
        string OrgPin { get; }          // Required
        string DatabaseName { get; }    // Required
        string Email { get; }
        string Address { get; }
    }
}
