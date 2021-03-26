using System;
using WaelAlshabaniBlog.Core.Domain.Exception;

namespace WaelAlshabaniBlog.Core.Domain
{

    public class BlogEntity
    {
        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public BlogEntity(string title, string body)
        {
            Title = title;
            Body = body;
        }

        public bool UpdateSubTitle(string newSubTitle)
        {
            if (string.IsNullOrEmpty(newSubTitle))
            {
                throw new InvalidBlogTitleLengthException("sub title is invalid");
            }
            return true;
        }

        public string SubTitle { get; private set; }
        public string Body { get; private set; }


        public bool Targeted { get; private set; }
        public int? Priority { get; private set; }


        public Guid CreatedByUserId { get; set; }
        public DateTimeOffset CreatedAtDateTime { get; set; }

        public Guid? LastModifiedByUserId { get; set; }
        public DateTimeOffset? LastModifiedAtDateTime { get; set; }
        public int ModificationVersion { get; set; }

        public Guid DeletedByUserId { get; set; }
        public DateTimeOffset? DeletedAtDateTime { get; set; }
        public bool CanBeForcedDeleted { get; set; }



    }
}
