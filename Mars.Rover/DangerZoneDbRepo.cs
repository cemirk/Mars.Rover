using System;
using System.Collections.Generic;
using System.Linq;
using Mars.Rover.Models;

namespace Mars.Rover
{
    public class DangerZoneDbRepo
    {
        private static List<Coords> coords;
        private DangerZoneDbRepo()
        {
            coords = new List<Coords>();
        }
        public static Lazy<DangerZoneDbRepo> Instance => new Lazy<DangerZoneDbRepo>(new DangerZoneDbRepo());

        public void Add(int x, int y)
        {
            if (!coords.Any(c => c.X == x && c.Y == y))
            {
                coords.Add(new Coords {X = x, Y = y});
            }
        }

        public bool IsRestricted(int x, int y)
        {
            return coords.Any(c => c.X == x && c.Y == y);
        }

    }

    public class Coords
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}