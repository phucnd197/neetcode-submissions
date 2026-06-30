public class TimeMap {
    record struct Item(string Value, int Timestamp);

    private readonly Dictionary<string, List<Item>> _map;

    public TimeMap() {
        _map = [];
    }

    public void Set(string key, string value, int timestamp) {
        if (!_map.TryGetValue(key, out var list)) {
            list = [];
        }

        list.Add(new Item(value, timestamp));
        _map[key] = list;
    }

    public string Get(string key, int timestamp) {
        if (!_map.TryGetValue(key, out var list) || list[0].Timestamp > timestamp) {
            return string.Empty;
        }

        var min = int.MinValue;
        var l = 0;
        var r = list.Count - 1;
        while (l <= r) {
            var mid = (l + r) / 2;
            var middle = list[mid];

            if (middle.Timestamp > timestamp) {
                r = mid - 1;
            } else if (middle.Timestamp < timestamp) {
                l = mid + 1;

                if (middle.Timestamp > min) {
                    min = mid;
                }
            } else {
                min = mid;
                break;
            }
        }

        if (min == int.MinValue) {
            return string.Empty;
        }
        
        return list[min].Value;
    }
}
