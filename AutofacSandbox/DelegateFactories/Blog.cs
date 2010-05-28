using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateFactories
{
    class Blog : Interfaces.IBlog
    {
        private readonly string title;
        private readonly string description;
        private readonly Factory.IPosting postBuilder;
        private readonly IList<Interfaces.IPosting> posts;

        public Blog(string title, string description, Factory.IPosting postBuilder)
        {
            this.title = title;
            this.description = description;
            this.postBuilder = postBuilder;

            posts = new List<Interfaces.IPosting>();
        }

        public string Title
        {
            get { return title; }
        }

        public string Description
        {
            get { return description; }
        }

        public IEnumerable<Interfaces.IPosting> Posts
        {
            get { return posts; }
        }

        public Interfaces.IPosting AddPost(string title, string author, string content)
        {
            var newPost = postBuilder(title, author, content);
            posts.Add(newPost);

            return newPost;
        }

        public override string ToString()
        {
            var returnBuilder = new System.Text.StringBuilder();

            returnBuilder.AppendLine(Title);
            returnBuilder.AppendLine();
            returnBuilder.AppendLine(Description);
            returnBuilder.AppendLine();
            returnBuilder.AppendLine("====================");

            foreach (var post in Posts.OrderBy(x => x.PostedOn).Reverse())
            {
                returnBuilder.Append(post.ToString());
                returnBuilder.AppendLine("====================");
            }

            return returnBuilder.ToString();
        }
    }
}
