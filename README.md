# Develop Innovator Server Side Method Locally
## Creating a method
#### Create new file containing partial class "ServerMethods" for your methods in InnovatorProject project.
```cs
namespace Inensia.InnovatorProject
{
    public partial class ServerMethods : ContextItem
    {
        // Creates a new document with the same name as the newly created Part
        public Item create_document_on_save()
        {
            Innovator inn = this.getInnovator();

            string docName = this.getProperty("item_number", "");
            Item document = inn.newItem("Document", "add");
            document.setProperty("item_number", docName);
            document = document.apply();
            
            if (document.isError())
            {
                return inn.newError(document.getErrorDetail());
            }

            return this;
        }
    }
}

```

#### Other option is to create another class which must inherits from ContextItem and put your mwehod in it.
```cs
namespace Inensia.InnovatorProject
{
    public partial class MyClass : ContextItem
    {
        public MyClass(Item item) : base(item)
        {
        }

    }
}

```
## Running and debuggging a method
#### Populate settings.json file with the innovator's instance connection details.
```json
{
  "Url": "http://InnovatorServer/MyInstance",
  "Db": "MyDb",
  "User": "admin",
  "Pass": "innovator"
}
```
#### Create or use an existing class in InnovatorProject.Tests.Unit project. The class must inherits from TestBase.
```cs
namespace InnovatorProject.Tests.Unit
{
    public partial class ServerMethodsTests : TestBase
    {
        

    }
}
```
#### Create a test method in the test class for your innovator method.
```cs
[Fact]
public void create_document_on_save()
{
    // Arrange
    // Create unigue name
    string partName = Guid.NewGuid().ToString("N");
    
    // Simulate Part item creation
    Item context = Inn.newItem("Part", "add");
    context.setProperty("item_number", partName);
    context = context.apply();
    
    // Pass the newly created part as a context for your method
    var item = new Inensia.InnovatorProject.ServerMethods(context);

    // Act
    // Execute your method
    var res = item.create_document_on_save();
}
```
#### Open Test Explorer in Visual Studio, select your test method from the tests tree, right click and choose Debug.
## Notice! If you try to read Innovator instance local files, the operation will fail, because these files are not available on your machine.
