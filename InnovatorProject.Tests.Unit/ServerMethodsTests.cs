using Aras.IOM;
using Inensia.InnovatorProject;
using Xunit;

namespace InnovatorProject.Tests.Unit
{
    public partial class ServerMethodsTests : TestBase
    {

        [Fact]
        public void MRN_PLM_DialogChange_test()
        {
            // Arrange
            var context = Inn.newItem("fake_type", "get");
            var item = new Inensia.InnovatorProject.ServerMethods(context);

            // Act
            var res = item.MRN_PLM_DialogChange();

            // Assert
            Assert.False(res.isError());
        }
    }
}
