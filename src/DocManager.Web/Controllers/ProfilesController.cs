using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using DocManager.Business.Contract.Users.Models;
using DocManager.Business.Contract.Users.Services;
using DocManager.Web.Models;
using Microsoft.AspNet.Identity;
using Ninject;

namespace DocManager.Web.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Profiles")]
    public class ProfilesController : ApiController
    {
        #region Dependencies

        [Inject]
        public IUserRetrievingService UserRetrievingService { get; set; }

        [Inject]
        public UserManager<ProfileUser, Guid> UserManager { get; set; }

        #endregion

        [HttpGet]
        [Route("{userId:guid}")]
        public async Task<ProfileModel> GetUserProfile(Guid userId)
        {
            ProfileUser user = await UserRetrievingService.GetById(userId);

            ProfileModel profile = Mapper.Map<ProfileUser, ProfileModel>(user);

            SetIsSelf(profile);

            return profile;
        }

        [HttpGet]
        public IHttpActionResult GetUsersProfiles()
        {
            IEnumerable<ProfileUser> users = UserRetrievingService.GetAll();

            List<ProfileModel> profiles = users.Select(Mapper.Map<ProfileModel>).ToList();

            ProfileModel selfProfile = profiles.First(p => p.UserName == User.Identity.Name);
            selfProfile.IsSelf = true;

            return Ok(profiles);
        }

        //[HttpGet]
        //[Route("/self")]
        //public async Task<IHttpActionResult> GetSelfProfile()
        //{
        //    ProfileUser user = await UserRetrievingService.GetByUserName(User.Identity.Name);

        //    ProfileModel selfProfileModel = Mapper.Map<ProfileUser, ProfileModel>(user);

        //    selfProfileModel.IsSelf = true;

        //    return Ok(selfProfileModel);
        //}

        [HttpPut]
        [Route("Edit")]
        public async Task<ProfileModel> Edit([FromBody] ProfileModel editModel)
        {
            ProfileUser user = await UserRetrievingService.GetByUserName(User.Identity.Name);

            if (editModel.Id != user.Id)
            {
                throw new InvalidOperationException("You cannot edit current profile");
            }

            ProfileUser editedUser = Mapper.Map(editModel, user);

            await UserManager.UpdateAsync(editedUser);

            return editModel;
        }

        private void SetIsSelf(ProfileModel profileModel)
        {
            if (profileModel.UserName == User.Identity.Name)
            {
                profileModel.IsSelf = true;
            }
        }
    }
}