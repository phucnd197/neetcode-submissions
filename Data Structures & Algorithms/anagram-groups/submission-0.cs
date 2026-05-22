public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        List<List<string>> result = new List<List<string>>(strs.Length);
        var checkedWords = new HashSet<string>();
        var comparantDic = new Dictionary<char, uint>();
        var comparingDic = new Dictionary<char, uint>();

        for (var i = 0; i < strs.Length; i++)
        {
            var word = strs[i];
            if (checkedWords.Contains(word))
            {
                continue;
            }
            var anagramsGroup = new List<string>(strs.Length)
            {
                word
            };
            checkedWords.Add(word);
            // populate mask
            for (var wordIndex = 0; wordIndex < word.Length; wordIndex++)
            {
                if (comparantDic.TryGetValue(word[wordIndex], out _))
                {
                    comparantDic[word[wordIndex]]++;
                }
                else
                {
                    comparantDic.Add(word[wordIndex], 1);
                }
            }
            for (var j = i + 1; j < strs.Length; j++)
            {
                var comparingWord = strs[j];
                comparingDic.Clear();
                if (comparingWord.Length != word.Length)
                {
                    continue;
                }
                var isAnagram = true;
                for (var wordIndex = 0; wordIndex < comparingWord.Length; wordIndex++)
                {
                    if (!comparantDic.TryGetValue(comparingWord[wordIndex], out _))
                    {
                        isAnagram = false;
                        break;
                    }
                    else
                    {
                        if (comparingDic.TryGetValue(comparingWord[wordIndex], out _))
                        {
                            comparingDic[comparingWord[wordIndex]]++;
                        }
                        else
                        {
                            comparingDic.Add(comparingWord[wordIndex], 1);
                        }
                    }
                }
                if (!isAnagram)
                {
                    continue;
                }

                foreach (var (character, comparingCount) in comparingDic)
                {
                    if (!comparantDic.TryGetValue(character, out var comparantCount)
                        || comparingCount != comparantCount)
                    {
                        isAnagram = false;
                        break;
                    }
                }

                if (!isAnagram)
                {
                    continue;
                }
                checkedWords.Add(comparingWord);
                anagramsGroup.Add(comparingWord);
            }
            result.Add(anagramsGroup);
            comparantDic.Clear();
        }
        return result;
    }
}
