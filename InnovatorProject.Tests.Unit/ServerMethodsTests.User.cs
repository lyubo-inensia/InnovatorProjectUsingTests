using Aras.IOM;
using Inensia.InnovatorProject;
using Xunit;

namespace InnovatorProject.Tests.Unit
{
    public class ServerMethodsTestsUser : TestBase
    {
        // Creates a dummy item of non existing type
        protected Item GetContextItem()
        {
            var ret = Inn.newItem("fake_type", "get");

            return ret;
        }
        [Theory]
        [InlineData("some invalid id")]
        [InlineData("")]
        [InlineData(null)]
        public void set_user_fax_error_user_not_found(string userId)
        {
            // Arrange
            var item = new Inensia.InnovatorProject.ServerMethods(GetContextItem());
            item.setProperty("user_id", userId);

            // Act
            var res = item.set_user_fax();

            // Assert
            Assert.True(res.isError());
        }

        [Fact]
        public void set_user_fax_tests()
        {
            // Arrange
            string fax = "1234567";
            var item = new Inensia.InnovatorProject.ServerMethods(GetContextItem());
            Item user = Inn.newItem("User", "get").apply().getItemByIndex(0);
            item.setProperty("user_id", user.getID());
            item.setProperty("fax", fax);

            // Act
            var res = item.set_user_fax();

            // Assert
            Assert.Equal(res.getProperty("fax"), fax);
        }
    }
}
