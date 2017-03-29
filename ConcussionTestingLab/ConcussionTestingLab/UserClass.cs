using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcussionTestingLab
{
    class UserClass
    {
        public class User
        {
            public string userID;
            public string userName;
            public DateTime curDate;
            public double testScore1;
            public double testScore2;
            public double testScore3;
        } // User

        public List<User> userList = new List<User>();
    }
}
