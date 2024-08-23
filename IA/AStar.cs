using System.Net;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Web;

static MatchCollection getLinks(string html)
{
    var regex = new Regex(@"href=""(/wiki/[^""#:.]+)""");

    // var regex = new Regex(@"href=""(/wiki/[^""]*)""");
    return regex.Matches(html);
}

static Wiki[] getWikis(MatchCollection matches)
{
    Wiki[] result = new Wiki[matches.Count];
    for (int i = 0; i < matches.Count; i++)
    {
        var url = matches[i].Groups[1].Value;
        result[i] = new Wiki(HttpUtility.UrlDecode(url));   
    }
    return result;
}

var url_start = "/wiki/Morango";
var url_end = "/wiki/Rennes";

var start = new Wiki(url_start);
var end = new Wiki(url_end);

await parallelDijkstra(start, end);


// void ThreadDijkstra()
// {


//     Thread thread = new Thread(() =>
//     {
//         while (!estado.EstaCompleto)
//             Thread.Yield();
//         Console.WriteLine(estado.resultado);
//     });
//     thread.Start();
// }


static async Task parallelDijkstra(Wiki start, Wiki goal)
{
    var html = await getPage($"http://pt.wikipedia.org{start.Value}");
    var links = getLinks(html);
    var neighborhood = getWikis(links);

    var results = await Task.WhenAny(neighborhood
        .Select(nei => dijkstra(nei, goal))
        .ToArray()
    );
    
    Dictionary<string, string> bestPath =  await results;
    System.Console.WriteLine(start.Value);

    // System.Console.WriteLine("-------------------");
    // System.Console.WriteLine(bestPath.Count());

    // foreach (var item in bestPath.Keys)
    // {
    //     System.Console.WriteLine(item);
    // }

    // var it = goal.Value;
    // while (!it.Equals(start.Value))
    // {
    //     System.Console.WriteLine(it);
    //     it = bestPath[it];
    // }
    // System.Console.WriteLine(it);
 


}


static async Task<Dictionary<string, string>> dijkstra(Wiki start, Wiki goal)
{
    var url = "http://pt.wikipedia.org";

    var queue = new PriorityQueue<Wiki, float>();
    var distMap = new Dictionary<string, float>();
    var comeMap = new Dictionary<string, string>();
    
    var html_goal = await getPage($"{url}{goal.Value}");
    var links_goal = getLinks(html_goal);

    var goalMap = new HashSet<int>();
    foreach (var link in links_goal)
        goalMap.Add(link.GetHashCode());
    
    distMap[start.Value] = 0;
    queue.Enqueue(start, 0);

    while (queue.Count > 0)
    {
        Wiki crr = null;
        lock(queue) 
        {
            crr = queue.Dequeue();
        }
        System.Console.WriteLine($"{url}{crr.Value}");
        crr.Visited = true;

        if (crr.Value.Equals(goal.Value))
            break;
        
        var html = await getPage($"{url}{crr.Value}");
        var links = getLinks(html);
        var neighborhood = getWikis(links);

        foreach (var neighbor in neighborhood)
        {
            if (neighbor is null)
                continue;

            if (!distMap.ContainsKey(neighbor.Value))
            {
                lock(distMap)
                {
                    distMap.Add(neighbor.Value, float.PositiveInfinity);
                }
                lock (comeMap)
                {
                    comeMap.Add(neighbor.Value, null);
                }
            }
            
            var newDist = distMap[crr.Value] + 1;
            var oldDist = distMap[neighbor.Value];
            if (newDist > oldDist)
                continue;
            lock(distMap)
            {
                distMap[neighbor.Value] = newDist;
            }
            lock (comeMap)
            {
                comeMap[neighbor.Value] = crr.Value;
            }

            var isAGoodLink = goalMap.Contains(neighbor.Value.GetHashCode());
            var heuristic = isAGoodLink ? 0f : 0.5f;
            
            lock(queue) 
            {
                queue.Enqueue(neighbor, newDist + heuristic);
            }
        }
    }

    // foreach (var item in comeMap)
    // {
    //     System.Console.Write(item.Key);
    //     System.Console.Write(" : ");
    //     System.Console.WriteLine(item.Value);
            
    // }
    System.Console.WriteLine("--------------");
    var it = goal.Value;
    while (!it.Equals(start.Value))
    {
        System.Console.WriteLine(it);
        it = comeMap[it];
    }
    System.Console.WriteLine(it);
    return comeMap;
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



