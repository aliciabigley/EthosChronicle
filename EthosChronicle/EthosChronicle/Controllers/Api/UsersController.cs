using EthosChronicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EthosChronicle.Controllers.Api
{
    //public class UsersController : ApiController
    //{
    //    private ApplicationDbContext _context;
    //    public UsersController()
    //    {
    //        _context = new ApplicationDbContext();
    //    }

    //    //Get /api/user
    //    public IEnumerable<ApplicationUser> GetUsers()
    //    {
    //        return _context.Users.ToList();

    //    }

    //    public ApplicationUser GetUsers(int id)
    //    {
    //        var user = _context.Users.SingleOrDefault(u => u.d == id);
    //        if(user == null)
    //        {
    //            throw new HttpResponseException(HttpStatusCode.NotFound);
    //        }
    //        return user;
    //    }
    //}
}
