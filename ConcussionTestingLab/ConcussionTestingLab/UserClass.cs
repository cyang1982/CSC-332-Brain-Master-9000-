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
        } // User

        public class TestScores
        {
            public DateTime curDate;
            public double concentrationScore;
            public double memoryScore;
            public double reactionTimeScore;
        } // TestScores

        public static List<User> userList = new List<User>();
        public static List<TestScores> testScoreList = new List<TestScores>();
    }
}
