using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateFactories.Interfaces
{
    interface IBlog
    {
        string Title { get; }
        string Description { get; }
        IEnumerable<IPosting> Posts { get; }

        IPosting AddPost(string title, string author, string content);
    }
}
