public class Solution {
    readonly struct CarData(int position, int speed) {
        public int Position { get; } = position;
        public int Speed { get; } = speed;
    }

    public int CarFleet(int target, int[] position, int[] speed) {
        var cars = new CarData[position.Length];
        for (var i = 0; i < position.Length; i++) {
            cars[i] = new CarData(position[i], speed[i]);
        }
        Array.Sort(cars, (x, y) => y.Position - x.Position);

        var count = 0;
        var lastFleetTime = -1d;
        foreach (var car in cars) {
            var time = (double)(target - car.Position) / car.Speed;

            if (time > lastFleetTime) {
                count++;
                lastFleetTime = time;
            }
        }

        return count;
    }
}
