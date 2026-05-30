public class Solution {
    public string AddBinary(string a, string b) {
        var length = a.Length > b.Length ? a.Length : b.Length;
        var span = new StringBuilder(length);
        var remain = 0;
        var i = 0;
        var aIndex = a.Length - 1;
        var bIndex = b.Length - 1;
        while (i < length) {
            byte bitA = 0;
            if (aIndex > -1) {
                bitA = (byte)(a[aIndex] == '1' ? 1 : 0);
            }
            byte bitB = 0;
            if (bIndex > -1) {
                bitB = (byte)(b[bIndex] == '1' ? 1 : 0);
            }
            var c = bitA + bitB + remain;
            span.Insert(0, c % 2);
            remain = c / 2;

            i++;
            aIndex--;
            bIndex--;
        }
        if (remain > 0) {
            span.Insert(0, '1');
        }
        return span.ToString();
    }
}