using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HmwkAPI.Data.API
{
    public class ManagerRepository
    {
        public IEnumerable<int> GetTopTwenty()
        {
            var web = new WebClient();
            string json = web.DownloadString("https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty");
            var list = JsonConvert.DeserializeObject<IEnumerable<int>>(json);
            return list.Take(20);
        }
        public IEnumerable<whatever> GetTheStuff(IEnumerable<int> ids)
        {
            var web = new WebClient();
            ids = GetTopTwenty();
            var whatever = new List<whatever>();
            int i = 0;
            foreach (int id in ids)
            {
                 string json = web.DownloadString($"https://hacker-news.firebaseio.com/v0/item/{id}.json?print=pretty");
                var list = JsonConvert.DeserializeObject<whatever>(json);
                whatever.Add(list);
                i++;
            };
            return whatever;
        }

    }
    public class whatever
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Score { get; set; }
        public string By { get; set; }
    }

}
