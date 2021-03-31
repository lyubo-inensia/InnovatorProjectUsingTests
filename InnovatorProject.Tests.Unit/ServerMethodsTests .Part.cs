using Aras.IOM;
using Inensia.InnovatorProject;
using System;
using Xunit;

namespace InnovatorProject.Tests.Unit
{
    public partial class ServerMethodsTestsPart : TestBase
    {
        [Fact]
        public void create_document_on_save()
        {
            // Arrange
            string partName = Guid.NewGuid().ToString("N");
            Item context = Inn.newItem("Part", "add");
            context.setProperty("item_number", partName);
            context = context.apply();
            var item = new ServerMethods(context);
            Item doc = Inn.newItem("Document", "get");
            doc.setProperty("item_number", partName);

            // Act
            var res = item.create_document_on_save();
            doc = doc.apply();

            // Assert
            Assert.False(res.isError());
            Assert.False(doc.isError());
            Assert.False(doc.isCollection());
            Assert.False(string.IsNullOrWhiteSpace(doc.getID()));
        }
    }
}
