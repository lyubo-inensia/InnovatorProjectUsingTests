using Aras.IOM;

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
