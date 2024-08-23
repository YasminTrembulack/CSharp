using System;
using System.Collections.Generic;

public class Solver
{
    public int Move(
        Dictionary<int, (int id, float x, float y, int[] conns)> nodes,
        (float x, float y) target,
        (float x, float y) player,
        int targetLocId,
        int playerLocId
    )
    {
        var queue = new PriorityQueue<int, float>();
        var distMap = new Dictionary<int, float>();
        var comeMap = new Dictionary<int, int>();

        distMap[playerLocId] = 0;
        queue.Enqueue(playerLocId, 0);

        while (queue.Count > 0)
        {
            var crr = queue.Dequeue();

            if (crr == targetLocId)
                break;
            
            var node = nodes[crr];
            var neighborhood = node.conns;

            foreach (var neighbor in neighborhood)
            {
                if (!nodes.TryGetValue(neighbor, out var nei))
                    continue;
                
                var dx = node.x - nei.x;
                var dy = node.y - nei.y;
                var dist = MathF.Sqrt(dx * dx + dy * dy);
                var newDist = distMap[crr] + dist;

                if (!distMap.TryGetValue(neighbor, out float oldDist))
                {
                    oldDist = float.PositiveInfinity;
                    distMap.Add(neighbor, float.PositiveInfinity);
                    comeMap.Add(neighbor, crr);
                }
                
                if (newDist > oldDist)
                    continue;
                
                distMap[neighbor] = newDist;
                comeMap[neighbor] = crr;

                dx = nodes[targetLocId].x - nei.x;
                dy = nodes[targetLocId].y - nei.y;
                dist = MathF.Sqrt(dx * dx + dy * dy);
                newDist = distMap[crr] + dist;
                queue.Enqueue(neighbor, newDist + dist);
            }
        }

        var it = targetLocId;
        var prev = comeMap[targetLocId];
        while (prev != playerLocId)
        {
            it = prev;
            prev = comeMap[it];
        }
        return it;
    }
}
