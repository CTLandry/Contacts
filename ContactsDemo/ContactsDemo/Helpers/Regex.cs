using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactsDemo.Helpers
{
    public static class Regex
    {
        public static bool Alpha(string entry)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(entry, "^[a-zA-Z]*$");
        }
       
    }
}
