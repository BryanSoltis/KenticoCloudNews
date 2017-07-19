using System.Threading.Tasks;
using Xamarin.Forms;

namespace Common.Helpers
{
    public class General
    {
        public static async Task Sleep(int ms)
        {
            await Task.Delay(ms);
        }
    }
}
