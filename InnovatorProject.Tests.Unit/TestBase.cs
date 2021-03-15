using Aras.IOM;

namespace InnovatorProject.Tests.Unit
{
    public class TestBase
    {
        public TestBase()
        {
            Settings = Conf.Load();
            Inn = IomFactory.CreateInnovator(Connection);
        }

        protected AppSettings Settings;

        public Innovator Inn { get; }
        protected IServerConnection conn;
        public IServerConnection Connection
        {
            get {
                if (conn == null)
                {
                    conn = IomFactory.CreateHttpServerConnection(
                        Settings.Url,
                        Settings.Db,
                        Settings.User,
                        Settings.Pass
                        );
                }

                return conn;
            }
        }
    }
}
