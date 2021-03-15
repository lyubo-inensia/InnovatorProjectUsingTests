using Aras.IOM;

namespace Inensia.InnovatorProject
{
    public abstract class ServerMethod : Item
    {
        Aras.Server.Core.CallContext CCO;
        Aras.Server.Core.IContextState RequestState;
        public ServerMethod(IServerConnection conn) : base(conn)
        {
            SetContext(conn);
        }

        public ServerMethod(Item item) : base(item.getInnovator().getConnection())
        {
            SetContext(item.getInnovator().getConnection());
            this.dom = item.dom;
            this.node = item.node;
            this.nodeList = item.nodeList;
        }
        protected void SetContext(IServerConnection conn)
        {
            // TODO: find how to populate this
            //CCO = ((Aras.Server.Core.IOMConnection)conn).CCO;
           RequestState = CCO?.RequestState;
        }
    }
}
