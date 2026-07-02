public class Solution {
    public sealed class Info<T> {
        public T Root { get; set; }
        public int Rank { get; set; }
        public Info(T elem) {
            Root = elem;
            Rank = 1;
        }
    }

    public class DisjointSet<T>
        where T : notnull {
        private readonly Dictionary<T, Info<T>> _partitionMap = new();

        public Info<T> FindPartition(T elem) {
            // get node representation of the element
            if (!_partitionMap.TryGetValue(elem, out var parent)) {
                return null;
            }

            if (elem.Equals(parent.Root)) {
                return parent;
            }

            var root = FindPartition(parent.Root);
            if (root is null) {
                return null;
            }

            parent.Root = root.Root;
            return root;
        }

        public bool AreDisjoint(T elem1, T elem2) {
            var partition1 = FindPartition(elem1);
            var partition2 = FindPartition(elem2);

            return !ReferenceEquals(partition1, partition2);
        }

        public bool Merge(T elem1, T elem2) {
            if (elem1 is null || elem2 is null) {
                return false;
            }

            var partition1 = FindPartition(elem1);
            var partition2 = FindPartition(elem2);

            if (partition1 is null || partition2 is null ||
                ReferenceEquals(partition1, partition2)) {
                return false;
            }

            if (partition1.Rank >= partition2.Rank) {
                partition2.Root = partition1.Root;
                partition1.Rank += partition2.Rank;
            } else {
                partition1.Root = partition2.Root;
                partition2.Rank += partition1.Rank;
            }

            return true;
        }

        public bool Add(T elem) {
            return _partitionMap.TryAdd(elem, new Info<T>(elem));
        }
    }

    public List<List<string>> AccountsMerge(List<List<string>> accounts) {
        var emailAccs = new Dictionary<string, List<int>>();
        var dsu = new DisjointSet<int>();
        for (var accId = 0; accId < accounts.Count; accId++) {
            var account = accounts[accId];
            dsu.Add(accId);
            for (var i = 1; i < account.Count; i++) {
                var email = account[i];
                if (!emailAccs.TryGetValue(email, out var accIds)) {
                    emailAccs[email] = accIds = [];
                }
                accIds.Add(accId);
            }
        }

        foreach (var (_, accs) in emailAccs) {
            var accId1 = accs[0];
            for (var i = 1; i < accs.Count; i++) {
                var accId2 = accs[i];
                dsu.Merge(accId1, accId2);
            }
        }

        var dict = new Dictionary<int, List<string>>();
        for (var i = 0; i < accounts.Count; i++) {
            var info = dsu.FindPartition(i);
            if (!dict.TryGetValue(info.Root, out var accEmails)) {
                dict[info.Root] = accEmails = [];
            }
            var account = accounts[i];
            accEmails.AddRange(account.GetRange(1, account.Count - 1));
        }

        var result = new List<List<string>>();
        foreach (var (accId, accEmails) in dict) {
            var account = new List<string>() { accounts[accId][0] };
            accEmails.Sort(StringComparer.Ordinal);
            string? prev = null;
            var i = 0;
            while (i < accEmails.Count) {
                var current = accEmails[i++];
                if (prev is not null && prev == current) {
                    continue;
                }
                account.Add(current);
                prev = current;
            }
            result.Add(account);
        }
        return result;
    }
}