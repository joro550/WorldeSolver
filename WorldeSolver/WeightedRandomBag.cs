namespace WorldeSolver;

public class WeightedRandomBag 
{
    private struct Entry {
        public double AccumulatedWeight;
        public string Item;
    }

    private List<Entry> entries = new();
    private double _accumulatedWeight;
    private readonly Random _rand = new();

    public void AddEntry(string item) {
        // e, t, a, i, o, n, s, h, and r
        var letterWeight = new Dictionary<string, int>
        {
            {"e", 10},
            {"t", 9},
            {"a", 8},
            {"i", 7},
            {"o", 6},
            {"n", 5},
            {"s", 4},
            {"h", 3},
            {"r", 2},
        };
        
        double weight = 0;
        foreach (var (key, value) in letterWeight)
        {
            weight += item.Count(x => x.ToString() == key) * value;
        }
        
        _accumulatedWeight += weight;
        entries.Add(new Entry { Item = item, AccumulatedWeight = _accumulatedWeight });
    }

    public string GetRandom() {
        var r = _rand.NextDouble() * _accumulatedWeight;
        return entries.FirstOrDefault(entry => entry.AccumulatedWeight >= r).Item;
    }
}