using Aras.IOM;
using Inensia.InnovatorProject;
using Xunit;

namespace InnovatorProject.Tests
{
    public class ItemTypeMethodsTests : TestBase
    {
        protected Item GetContextItem()
        {
            var ret = Inn.newItem("fake_type", "get");

            return ret;
        }

        [Theory]
        [InlineData("a")]
        public void set_user_fax_error_user_not_found(string userId)
        {
            // Arrange
            var item = new ItemTypeMethods(GetContextItem());
            item.setProperty("user_id", userId);

            // Act
            var res = item.set_user_fax();

            // Assert
            Assert.True(res.isError());
        }

        [Theory]
        [InlineData("30B991F927274FA3829655F50C99472E", "1234567")]
        public void set_user_fax_tests(string userId, string fax)
        {
            // Arrange
            var item = new ItemTypeMethods(GetContextItem());
            item.setProperty("user_id", userId);
            item.setProperty("fax", fax);

            // Act
            var res = item.set_user_fax();

            // Assert
            Assert.Equal(res.getProperty("fax"), fax);
        }
    }
}
