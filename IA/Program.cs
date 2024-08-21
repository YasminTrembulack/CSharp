
using System.Net;
using System.Text.RegularExpressions;



static MatchCollection getLinks(string html)
{
    var regex = new Regex(@"href=""(/wiki/[^""]*)""");
    return regex.Matches(html);
}

static Wiki[] getWikis(MatchCollection matches)
{
    Wiki[] result = new Wiki[matches.Count];
    for (int i = 0; i < matches.Count-1; i++)
    {
        foreach (var item in matches)
        {
            result[i] = new Wiki(matches[i].ToString()); 
        }
    }
    return result;
}
    
// var url = "http://pt.wikipedia.org";

var url_start = "/wiki/Michael_Jackson";
var url_end = "/wiki/Darth_Vader";

// var html_end = await getPage(url_end);
// var html_start = await getPage(url_start);

// var hrefs_start = getWikis(html_start);
// var hrefs_end = getWikis(html_end);

var start = new Wiki(url_start);
var end = new Wiki(url_end);

dijkstra(start, end);

static async void dijkstra(Wiki start, Wiki goal)
    {
        var url = "http://pt.wikipedia.org";
        var queue = new PriorityQueue<Wiki, float>();
        var distMap = new Dictionary<Wiki, float>();
        var comeMap = new Dictionary<Wiki, Space>();

        var html_goal = await getPage($"{url}{goal.Value}");
        var links_goal = getLinks(html_goal);

        queue.Enqueue(start, 0);

        while (queue.Count > 0)
        {
            var crr = queue.Dequeue();
            crr.Visited = true;

            if (crr.Value.Equals(goal.Value))
                break;
        
            var html = await getPage($"{url}{crr.Value}");
            var links = getLinks(html);
            var neighborhood = getWikis(links);
        
        //     for (int i = 0; i < start.Count-1; i++)
        // {
        //     if(start[i].ToString().Equals(end[i]))
        //     {
        //         queue.Enqueue(new Wiki(start[i].ToString()), 1);
        //         continue;
        //     }
        //     queue.Enqueue(new Wiki(start[i].ToString()), float.PositiveInfinity);
        // }

            foreach (var neighbor in neighborhood)
            {
                if (neighbor is null)
                    continue;

                if (!distMap.ContainsKey(neighbor))
                {
                    distMap.Add(neighbor, float.PositiveInfinity);
                    comeMap.Add(neighbor, null);
                }
                
                var newDist = distMap[crr] + 1;
                var oldDist = distMap[neighbor];
                if (newDist > oldDist)
                    continue;
                
                distMap[neighbor] = newDist;
                comeMap[neighbor] = crr;
                queue.Enqueue(neighbor, newDist);
            }
        }

        var it = goal;
        while (it != start)
        {
            it.IsSolution = true;
            it = comeMap[it];
        }
        start.IsSolution = true;
    }




static async Task<string> getPage(string url){
    using var client = new HttpClient(
        new HttpClientHandler {
            Proxy = new WebProxy{
                Address = new Uri("http://disrct:etsps2024401@rb-proxy-ca2.bosch.com:8080"),
                Credentials = new NetworkCredential("disrct", "etsps2024401")
            }
        }
    );
    var response = await client.GetAsync(url);
    var html = await response.Content.ReadAsStringAsync();
    return html;
}


class Wiki(string var)
{
    public bool Visited { get; set; } = false;

    public string Value { get; set; } = var;

}



