public class Solution {
    struct CarData(int position, int speed) {
        public int Position { get; } = position;
        public int Speed { get; } = speed;
    }

    public int CarFleet(int target, int[] position, int[] speed) {
        var cars = new List<CarData>();
        for (var i = 0; i < position.Length; i++) {
            cars.Add(new CarData(position[i], speed[i]));
        }
        cars.Sort((x, y) => y.Position - x.Position);

        var stack = new Stack<CarData>();
        foreach (var car in cars) {
            if (stack.Count == 0) {
                stack.Push(car);
                continue;
            }
            var time = (double)(target - car.Position) / car.Speed;

            var fleet = stack.Peek();
            var currentFleetTime = (double)(target - fleet.Position) / fleet.Speed;
            if (time > currentFleetTime) {
                stack.Push(car);
            }
        }

        return stack.Count;
    }
}
