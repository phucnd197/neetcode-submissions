class Solution {
    /**
     * @param {number[]} piles
     * @param {number} h
     * @return {number}
     */
    minEatingSpeed(piles, h) {
        let maxEatingSpeed = piles[0];
        let i = 1;
        for (; i < piles.length; i++) {
            if (maxEatingSpeed < piles[i]) {
                maxEatingSpeed = piles[i];
            }
        }
        let minEatingSpeed = 1;
        let eatingSpeed = 0;
        while (minEatingSpeed <= maxEatingSpeed) {
            const tempSpeed = Math.floor((maxEatingSpeed + minEatingSpeed) / 2);
            let tempTime = 0;
            i = 0;
            for (; i < piles.length; i++) {
                if (piles[i] < tempSpeed) {
                    tempTime++;
                } else {
                    tempTime += Math.ceil(piles[i] / tempSpeed);
                }
            }
            if (tempTime <= h) {
                eatingSpeed = tempSpeed;
                maxEatingSpeed = tempSpeed - 1;
            } else {
                minEatingSpeed = tempSpeed + 1;
            }
        }
        return eatingSpeed;
    }
}
