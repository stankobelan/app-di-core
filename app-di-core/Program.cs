using homework.Wrapper;
using System.Net.Http;
using System.Threading.Tasks;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            IProgramServis servis = new ProgramServis(new HttpStorage("https://api-test-34995-default-rtdb.europe-west1.firebasedatabase.app/document", new HttpClientWrapper(new HttpClient())),
                new MyJsonSerializer(),
                new HttpStorage("https://api-test-34995-default-rtdb.europe-west1.firebasedatabase.app/document", new HttpClientWrapper(new HttpClient())),
                new MyJsonSerializer());

            Task taskA = Task.Run(() => servis.MainTask());
            taskA.Wait();
        }
    }
}
