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
        var eatingSpeed = 0;
        while (maxEating >= minEating)
        {
            var tempSpeed = (minEating + maxEating) / 2;
            uint timeToEat = 0;
            for (var i = 0; i < piles.Length; i++)
            {
                var hasLeftOver = piles[i] % tempSpeed != 0;
                timeToEat += (uint)(piles[i] / tempSpeed);
                if (hasLeftOver)
                {
                    timeToEat += 1;
                }
            }
            if (timeToEat <= h)
            {
                maxEating = tempSpeed - 1;
                if (eatingSpeed == 0 || tempSpeed < eatingSpeed)
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
