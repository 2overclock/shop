using System.ComponentModel.DataAnnotations;

namespace shop.web.Areas.Admin.Models
{
    public class TestModel
    {
        [Required]
        public string Title { get; set; }

        public bool CheckMe { get; set; }

        public List<TestEnum> CheckAllOfMe { get; set; }

        public TestEnum TestMe { get; set; }

        [Display(Name = "Select me")]
        public TestEnum SelectMe { get; set; }
    }

    public enum TestEnum
    {
        Test1 = 1,
        Test2 = 2,
        Test3 = 3,
        Test4 = 4
    }
}
