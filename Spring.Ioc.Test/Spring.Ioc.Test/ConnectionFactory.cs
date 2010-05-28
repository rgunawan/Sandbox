namespace Spring.Ioc.Test
{
    class ConnectionFactory
    {
        public CifsConnection CreateCifsLocation()
        {
            return new CifsConnection()
                       {
                           Address = "factory-created address",
                           Password = "password from factory",
                           Username = "username from factory"
                       };
        }
    }
}
