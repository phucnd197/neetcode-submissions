public class Solution {
    public List<List<string>> AccountsMerge(List<List<string>> accounts) {
        for (var i = 0; i < accounts.Count; i++) {
            var account = accounts[i];
            var emails = account.GetRange(1, account.Count - 1);
            emails.Sort(StringComparer.Ordinal);
            var accountSorted = new List<string>(emails.Count) { account[0], emails[0] };
            var j = 1;
            var prev = emails[0];
            while (j < emails.Count) {
                if (emails[j] != prev) {
                    accountSorted.Add(emails[j]);
                }

                prev = emails[j++];
            }
            accounts[i] = accountSorted;
        }

        var results = Merge(accounts);
        return results;
    }

    private static List<List<string>> Merge(List<List<string>> accounts) {
        var result = new List<List<string>>();
        var visited = new bool[accounts.Count];
        for (var index = 0; index < accounts.Count; index++) {
            if (visited[index]) {
                continue;
            }

            var account = accounts[index];
            var mem = new HashSet<string>();
            for (var i = 1; i < account.Count; i++) {
                mem.Add(account[i]);
            }

            var current = account;
            visited[index] = true;
            while (true) {
                var hasMerge = false;
                for (var j = 0; j < accounts.Count; j++) {
                    if (visited[j]) {
                        continue;
                    }

                    var possibleMatch = accounts[j];
                    for (var k = 1; k < possibleMatch.Count; k++) {
                        if (!mem.Contains(possibleMatch[k])) {
                            continue;
                        }

                        current = MergeSortedArrays(account, current, possibleMatch, mem);
                        hasMerge = true;
                        visited[j] = true;
                        break;
                    }
                }

                if (!hasMerge) {
                    break;
                }
            }

            result.Add(current);
        }

        return result;
    }

    private static List<string> MergeSortedArrays(List<string> account, List<string> current,
                                                  List<string> possibleMatch, HashSet<string> mem) {
        var newEmails = new List<string>(account.Count) { current[0] };
        var first = 1;
        var second = 1;
        while (first < current.Count && second < possibleMatch.Count) {
            var compare =
                string.Compare(current[first], possibleMatch[second], StringComparison.Ordinal);
            switch (compare) {
                case > 0:
                    newEmails.Add(possibleMatch[second]);
                    mem.Add(possibleMatch[second]);
                    second++;
                    break;
                case < 0:
                    newEmails.Add(current[first]);
                    mem.Add(current[first]);
                    first++;
                    break;
                default:
                    newEmails.Add(current[first]);
                    mem.Add(current[first]);
                    first++;
                    second++;
                    break;
            }
        }

        if (first < current.Count) {
            for (var i = first; i < current.Count; i++) {
                newEmails.Add(current[i]);
                mem.Add(current[i]);
            }
        }

        if (second < possibleMatch.Count) {
            for (var i = second; i < possibleMatch.Count; i++) {
                newEmails.Add(possibleMatch[i]);
                mem.Add(possibleMatch[i]);
            }
        }

        return newEmails;
    }
}