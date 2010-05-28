using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateFactories
{
    class Factory
    {
        public delegate Interfaces.IComment IComment(string author, string content);
        public delegate Interfaces.IPosting IPosting(string title, string author, string content);
        public delegate Interfaces.IBlog IBlog(string title, string description);
    }
}
