namespace Spring.Ioc.Test
{
    using System;

    class CifsConnection : ConnectionInfo
    {
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return "Address: " + Address + Environment.NewLine +
                   "Username: " + Username + Environment.NewLine +
                   "Password: " + Password + Environment.NewLine;
        }
    }
}
