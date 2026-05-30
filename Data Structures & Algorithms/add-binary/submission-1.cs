public class Solution {
    public string AddBinary(string a, string b) {
        var length = a.Length > b.Length ? a.Length : b.Length;
        var span = new StringBuilder();
        var remain = 0;
        var i = 0;
        var aIndex = a.Length - 1;
        var bIndex = b.Length - 1;
        while (i < length) {
            i++;
            byte bitA = 0;
            if (aIndex > -1) {
                bitA = (byte)(a[aIndex] == '1' ? 1 : 0);
                aIndex--;
            }
            byte bitB = 0;
            if (bIndex > -1) {
                bitB = (byte)(b[bIndex] == '1' ? 1 : 0);
                bIndex--;
            }
            var c = bitA + bitB;
            var addToRemain = false;
            if (c > 1) {
                c = 0;
                addToRemain = true;
            }
            if (remain > 0) {
                c += 1;
                remain--;
            }
            if (c > 1) {
                c = 0;
                remain++;
            }
            if (addToRemain) {
                remain++;
            }
            span.Insert(0, c);
        }
        if (remain > 0) {
            span.Insert(0, '1');
        }
        return span.ToString();
    }
}