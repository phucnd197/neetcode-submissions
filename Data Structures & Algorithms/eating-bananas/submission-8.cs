public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        var maxEating = 1;
        for (var i = 0; i < piles.Length; i++)
        {
            if (maxEating < piles[i])
            {
                maxEating = piles[i];
            }
        }
        var minEating = 1;
        var eatingSpeed = maxEating;
        while (maxEating >= minEating)
        {
            var tempSpeed = (minEating + maxEating) / 2;
            long timeToEat = 0;
            for (var i = 0; i < piles.Length; i++)
            {
                timeToEat += (int)Math.Ceiling((double)piles[i] / tempSpeed);
            }
            if (timeToEat <= h)
            {
                maxEating = tempSpeed - 1;
                eatingSpeed = tempSpeed;
            }
            else
            {
                minEating = tempSpeed + 1;
            }
        }
        return eatingSpeed;
    }
}
