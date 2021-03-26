using System;
using WaelAlshabaniBlog.Core.Domain.Exception;

namespace WaelAlshabaniBlog.Core.Domain
{

    public class BlogEntity
    {
        public int Id { get; private set; }
        public Guid PublicId { get; private set; }

        public string Title { get; private set; }
        public string Body { get; private set; }


        public bool Targeted { get; private set; }
        public int? Priority { get; private set; }

        public string SubTitle { get; private set; }


        public TrackingInformation<Guid> Tracking { get; private set; }


        public BlogEntity(string title, string body)
        {
            Title = title;
            Body = body;
        }


        public void UpdateSubTitle(string newSubTitle)
        {
            if (string.IsNullOrEmpty(newSubTitle))
            {
                throw new InvalidBlogTitleLengthException("sub title is invalid");
            }

            SubTitle = newSubTitle;
        }

  



    }
}
