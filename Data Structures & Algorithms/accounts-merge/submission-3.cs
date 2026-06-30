public class Solution {
    public List<List<string>> AccountsMerge(List<List<string>> accounts) {
        var emailIdx = new Dictionary<string, int>();
        var emails = new List<string>();
        var m = 0;
        for (var accId = 0; accId < accounts.Count; accId++) {
            var account = accounts[accId];
            for (var i = 1; i < account.Count; i++) {
                if (!emailIdx.ContainsKey(account[i])) {
                    emailIdx[account[i]] = m++;
                    emails.Add(account[i]);
                }
            }
        }

        var adj = new List<List<int>>();
        for (var i = 0; i < m; i++) {
            adj.Add([]);
        }

        foreach (var account in accounts) {
            for (var i = 2; i < account.Count; i++) {
                var u = emailIdx[account[i - 1]];
                var v = emailIdx[account[i]];
                adj[u].Add(v);
                adj[v].Add(u);
            }
        }

        var visited = new bool[m];
        var components = new Dictionary<int, List<string>>();
        var componentName = new Dictionary<int, string>();
        foreach (var account in accounts) {
            var name = account[0];
            for (var i = 1; i < account.Count; i++) {
                var email = account[i];
                var idx = emailIdx[email];
                if (!visited[idx]) {
                    components[idx] = new List<string>();
                    componentName[idx] = name;
                    Dfs(idx, idx);
                }
            }
        }

        var res = new List<List<string>>();
        foreach (var (key, value) in components) {
            var group = value;
            group.Sort(StringComparer.Ordinal);
            var merged = new List<string> { componentName[key] };
            merged.AddRange(group);
            res.Add(merged);
        }

        return res;

        void Dfs(int node, int root) {
            visited[node] = true;
            components[root].Add(emails[node]);
            foreach (var nei in adj[node]) {
                if (!visited[nei]) {
                    Dfs(nei, root);
                }
            }
        }
    }
}