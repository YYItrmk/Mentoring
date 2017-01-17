namespace WpfApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        public bool IsSelected { get; set; }

        public int Id { get; set; }

        public string DisplayName { get; set; }

        public int Age { get; set; }

        
    }

    public class Weahter
    {
        public string City { get; set; }

        public string TODAY { get; set; }

        public string TOMORROW { get; set; }
    }
    
    public class News
    {
        //できない
        public string[] Title { get; set; }
        public string[] URL { get; set; }
    }
}
