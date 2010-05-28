namespace Spring.Ioc.Test
{
    using System;

    class Repository
    {
        public string Name { get; set; }
        public CifsConnection ConnectionInfo { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + Environment.NewLine + ConnectionInfo.ToString();
        }
    }
}
