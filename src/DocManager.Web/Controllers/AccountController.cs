using System;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using DocManager.Business.Contract.Users.Models;
using DocManager.Web.Models;
using Microsoft.AspNet.Identity;
using Ninject;

namespace DocManager.Web.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        [Inject]
        public UserManager<ProfileUser, Guid> UserManager { get; set; }

        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProfileUser user = Mapper.Map<RegisterModel, ProfileUser>(model);
            IdentityResult result = await UserManager.CreateAsync(user, user.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            foreach (var resultError in result.Errors)
            {
                ModelState.AddModelError(string.Empty, resultError);
            }

            return BadRequest(ModelState);
        }
    }
}