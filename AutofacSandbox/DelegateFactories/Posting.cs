using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateFactories
{
    class Posting : Interfaces.IPosting 
    {
        private readonly string title;
        private readonly string author;
        private readonly DateTime postedOn;
        private readonly string content;
        private readonly IList<Interfaces.IComment> comments;
        private readonly Factory.IComment commentBuilder;

        public Posting(string title, string author, string content, Factory.IComment commentBuilder)
        {
            this.title = title;
            this.author = author;
            this.postedOn = DateTime.Now;
            this.content = content;
            this.commentBuilder = commentBuilder;

            this.comments = new List<Interfaces.IComment>();
        }

        public string Title
        {
            get { return title; }
        }

        public string Author
        {
            get { return author; }
        }

        public DateTime PostedOn
        {
            get { return postedOn; }
        }

        public string Content
        {
            get { return content; }
        }

        public IEnumerable<Interfaces.IComment> Comments
        {
            get { return comments; }
        }

        public Interfaces.IComment AddComment(string author, string content)
        {
            var newComment = commentBuilder(author, content);
            comments.Add(newComment);

            return newComment;
        }

        public override string ToString()
        {
            var returnBuilder = new System.Text.StringBuilder();

            returnBuilder.AppendLine(Title);
            returnBuilder.AppendLine(string.Format("{0} ({1} {2})", Author, PostedOn.ToShortDateString(), PostedOn.ToShortTimeString()));
            returnBuilder.AppendLine(Content);
            returnBuilder.AppendLine();
            returnBuilder.AppendLine("Comments");
            returnBuilder.AppendLine("--------");

            foreach (var comment in Comments)
            {
                returnBuilder.Append(comment.ToString());
                returnBuilder.AppendLine();
            }

            return returnBuilder.ToString();
        }
    }
}
