using bookDemo.Models;

namespace bookDemo.Data
{
    public static class ApplicationContext
    {
        public static List<book>books { get; set; }
        static ApplicationContext()
        {
            books = new List<book>()
            {
                new book(){Id=1,title="cin ali",price=52},
                new book(){Id=2,title="abc",price=48},
                new book(){Id=3,title="cba",price=34}
            };
        }
    }
}
