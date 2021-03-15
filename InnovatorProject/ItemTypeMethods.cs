using Aras.IOM;

namespace Inensia.InnovatorProject
{
    public class ItemTypeMethods : ServerMethod
    {
        public ItemTypeMethods(Item item) : base(item)
        {
        }

        public Item set_user_fax()
        {
            Innovator inn = this.getInnovator();
            string fax = this.getProperty("fax", "");
            string user_id = this.getProperty("user_id", "");
            Item user = inn.newItem("User", "edit");
            user.setID(user_id);
            user = user.apply();

            if (user.isError())
            {
                return this.getInnovator().newError(user.getErrorDetail());
            }

            user.setProperty("fax", fax);
            Item res = user.apply();
            if (res.isError())
            {
                return this.getInnovator().newError(res.getErrorDetail());
            }

            return user;
        }
    }
}
