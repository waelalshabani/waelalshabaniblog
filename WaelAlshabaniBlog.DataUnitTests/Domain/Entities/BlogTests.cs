using System.Threading.Tasks;
using FluentValidation.TestHelper;
using WaelAlshabaniBlog.Core.Domain;
using WaelAlshabaniBlog.DataUnitTests.DomainEntityValidator;
using Xunit;

namespace WaelAlshabaniBlog.DataUnitTests
{
    public class BlogTests
    {
        private readonly BlogValidator _blogValidator;


        public BlogTests()
        {
            _blogValidator = new BlogValidator(10, 20).BuildEntityRule();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("less")]
        public async Task CreateBlog_InvalidTitle_ShouldHaveValidationError(string title)
        {
            var newBlog = new BlogEntity(title, null);

            var result = _blogValidator.TestValidate(newBlog, include => include.IncludeAllRuleSets());

            result.ShouldHaveValidationErrorFor(blog => blog.Title);
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("This body contains")]
        public async Task CreateBlog_InvalidBlody_ShouldHaveValidationError(string body)
        {
            var newBlog = new BlogEntity(null, body);

            var result = _blogValidator.TestValidate(newBlog, include => include.IncludeAllRuleSets());

            result.ShouldHaveValidationErrorFor(blog => blog.Body);
        }

    }
}
