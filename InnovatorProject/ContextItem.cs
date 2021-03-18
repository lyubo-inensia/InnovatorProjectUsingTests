using Aras.IOM;

namespace Inensia.InnovatorProject
{
    public abstract class ContextItem : Item
    {
        Aras.Server.Core.CallContext CCO;
        Aras.Server.Core.IContextState RequestState;
        public ContextItem(IServerConnection conn) : base(conn)
        {
            SetContext(conn);
        }

        public ContextItem(Item item) : base(item.getInnovator().getConnection())
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
