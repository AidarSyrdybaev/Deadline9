using DeadLine9.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Deadline9.UI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Security.Claims;
using Deadline9.Models;

namespace Deadline9.Tests
{
    public class AccountControllerTests
    {
        [Fact]
        public void GetRegisterTest()
        {
            var UserManagerMock = new Mock<FakeUserManager>();
            var SignInManagerMock = new Mock<FakeSignInManager>();

            var AccountController = new AccountController(UserManagerMock.Object, SignInManagerMock.Object);

            var result = AccountController.Register();

            Assert.NotNull(result);
        }

        [Fact]
        public void HttpRegisterTest()
        {
            var UserManagerMock = new Mock<FakeUserManager>();
            var SignInManagerMock = new Mock<FakeSignInManager>();

            UserManagerMock.Setup(repo => repo.CreateAsync(null, null)).Returns(UserCreateAsyncMockMethod(null, null));
            SignInManagerMock.Setup(repo => repo.SignInAsync(null, null, null)).Returns(UserSigninAsyncMockMethod(null, null, null));

            var AccountController = new AccountController(UserManagerMock.Object, SignInManagerMock.Object);

            var Result = AccountController.Register(new UserRegisterModel { Email = "Aidar_1997_kg@mail.ru", Password = "!Number98", PasswordConfirm = "!Number98" });

            Assert.NotNull(Result);

        }

        [Fact]
        public void GetLoginTest()
        {
            var UserManagerMock = new Mock<FakeUserManager>();
            var SignInManagerMock = new Mock<FakeSignInManager>();

            var AccountController = new AccountController(UserManagerMock.Object, SignInManagerMock.Object);

            var Result = AccountController.Login("url");

            Assert.NotNull(Result);

        }

        [Fact]
        public void PostLoginTest()
        {
            var UserManagerMock = new Mock<FakeUserManager>();
            var SignInManagerMock = new Mock<FakeSignInManager>();

            SignInManagerMock.Setup(repo => repo.PasswordSignInAsync("UserName", null, false, false)).Returns(PasswordSignInAsyncMockMethod("UserName", null, false, false));

            var AccountController = new AccountController(UserManagerMock.Object, SignInManagerMock.Object);

            var Result = AccountController.Login(new UserLoginModel { Email = "Aidar_1997_kg@mail.ru", Password ="!Number98", RememberMe=false, ReturnUrl=null});

            Assert.NotNull(Result);


        }

        [Fact]
        public void LogoutTest()
        {
            var UserManagerMock = new Mock<FakeUserManager>();
            var SignInManagerMock = new Mock<FakeSignInManager>();

            SignInManagerMock.Setup(repo => repo.SignOutAsync()).Returns(SignOutAsyncMockMethod());

            var AccountController = new AccountController(UserManagerMock.Object, SignInManagerMock.Object);

            var Result = AccountController.Logout();

            Assert.NotNull(Result);
        }


        public async Task<IdentityResult> UserCreateAsyncMockMethod(User user, ClaimsPrincipal claimsPrincipal)
        {
            return IdentityResult.Success;
        }

        public async Task UserSigninAsyncMockMethod (User user, AuthenticationProperties authenticationProperties, string authMethod)
        { 
        
        }

        public async Task<SignInResult> PasswordSignInAsyncMockMethod(string UserName, string Password, bool IsPersistent, bool LockoutOnFailure)
        {
            return SignInResult.Success;
        }

        public async Task SignOutAsyncMockMethod()
        { 
        
        }
    }

    public class FakeSignInManager : SignInManager<User>
    {
        public FakeSignInManager()
            : base(GetMockUserManager().Object,
            new Mock<IHttpContextAccessor>().Object,
            new Mock<IUserClaimsPrincipalFactory<User>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<ILogger<SignInManager<User>>>().Object,
            new Mock<IAuthenticationSchemeProvider>().Object, 
            new Mock<IUserConfirmation<User>>().Object)
        { }

        private static Mock<UserManager<User>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<User>>();
            return new Mock<UserManager<User>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }
    }

    public class FakeUserManager : UserManager<User>
    {
        public FakeUserManager()
            : base(new Mock<IUserStore<User>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<IPasswordHasher<User>>().Object,
                  new IUserValidator<User>[0],
                  new IPasswordValidator<User>[0],
                  new Mock<ILookupNormalizer>().Object,
                  new Mock<IdentityErrorDescriber>().Object,
                  new Mock<IServiceProvider>().Object,
                  new Mock<ILogger<UserManager<User>>>().Object)
        { }
    }
}
