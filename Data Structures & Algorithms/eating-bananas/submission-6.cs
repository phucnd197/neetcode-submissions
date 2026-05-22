public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        var maxEating = int.MinValue;
        var maxHour = 0;
        for (var i = 0; i < piles.Length; i++)
        {
            if (maxEating < piles[i])
            {
                maxEating = piles[i];
            }
            maxHour += piles[i];
        }
        if (h == 4)
        {
            return maxEating;
        }
        var minEating = 1;
        if (maxHour == h)
        {
            return minEating;
        }
        var eatingSpeed = int.MaxValue;
        while (maxEating >= minEating)
        {
            var tempSpeed = (minEating + maxEating) / 2;
            var timeToEat = 0;
            for (var i = 0; i < piles.Length; i++)
            {
                var hasLeftOver = piles[i] % tempSpeed != 0;
                timeToEat += piles[i] / tempSpeed;
                if (hasLeftOver)
                {
                    timeToEat += 1;
                }
            }
            if (timeToEat <= h)
            {
                maxEating = tempSpeed - 1;
                if (tempSpeed < eatingSpeed)
                {
                    eatingSpeed = tempSpeed;
                }
            }
            else if (timeToEat > h)
            {
                minEating = tempSpeed + 1;
            }
        }
        return eatingSpeed;
    }
}
