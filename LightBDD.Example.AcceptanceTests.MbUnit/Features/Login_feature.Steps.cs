using LightBDD.Example.Services;
using MbUnit.Framework;

namespace LightBDD.Example.AcceptanceTests.MbUnit.Features
{
    public partial class Login_feature : FeatureFixture
    {
        private const string _validUserName = "admin";
        private const string _validPassword = "password";

        private LoginRequest _loginRequest;
        private LoginService _loginService;
        private LoginResult _loginResult;

        private void Given_user_is_about_to_login()
        {
            _loginService = new LoginService();
            _loginService.AddUser(_validUserName, _validPassword);
            _loginRequest = new LoginRequest();
        }

        private void Given_user_entered_valid_login()
        {
            _loginRequest.UserName = _validUserName;
        }

        private void Given_user_entered_valid_password()
        {
            _loginRequest.Password = _validPassword;
        }

        private void Given_user_entered_anonymous_login()
        {
            _loginRequest.UserName = "anonymous";
        }

        private void Given_user_entered_invalid_login()
        {
            _loginRequest.UserName = "invalid user";
        }

        private void Given_user_entered_invalid_password()
        {
            _loginRequest.Password = "invalid password";
        }

        private void When_user_clicked_login_button()
        {
            _loginResult = _loginService.Login(_loginRequest);
        }

        private void Then_login_is_successful()
        {
            Assert.IsTrue(_loginResult.IsSuccessful, "Login should succeeded");
        }

        private void Then_welcome_message_is_returned_containing_user_name()
        {
            var expectedMessage = string.Format("Welcome {0}!", _validUserName);
            Assert.AreEqual(expectedMessage, _loginResult.ResultMessage);
        }

        private void Then_login_is_unsuccessful()
        {
            Assert.IsFalse(_loginResult.IsSuccessful);
        }

        private void Then_invalid_login_or_password_error_message_is_returned()
        {
            Assert.AreEqual("Invalid user name or password.", _loginResult.ResultMessage);
        }
    }
}