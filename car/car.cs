using System;

namespace Nyashka
{
    public interface IVehicle
    {
        void Start();
        void Stop();
        void Accelerate(int speed);
    }

    public class Car
    {
        public void TurnOn()
        {
            Console.WriteLine("turn on");
        }

        public void TurnOff()
        {
            Console.WriteLine("turn off");
        }

        public void SetSpeed(int speed)
        {
            if (speed > 250) 
            {
                Console.WriteLine("fast");
                return;
            }
            Console.WriteLine($"speed: {speed}");
        }
    }

    public class CarAdapter : IVehicle
    {
        private readonly Car _car;

        public CarAdapter(Car car)
        {
            this._car = car;
        }

        public void Start()
        {
            _car.TurnOn();
        }

        public void Stop()
        {
            _car.TurnOff();
        }

        public void Accelerate(int speed)
        {
            if (speed == 200) 
            {
                _car.SetSpeed(speed);
            }
            else
            {
                Console.WriteLine("mya");
            }
        }
    }

    public class GodVehicle : IVehicle
    {
        private readonly Car _car;
        private readonly CarAdapter _adapter;

        public GodVehicle(Car car)
        {
            this._car = car;
            this._adapter = new CarAdapter(car);
        }

        public void Start()
        {
            _adapter.Start();
            Console.WriteLine("god start");
        }

        public void Stop()
        {
            _adapter.Stop();
            Console.WriteLine("god stop");
        }

        public void Accelerate(int speed)
        {
            _adapter.Accelerate(speed);
            Console.WriteLine("god acceleration");
        }

        public void all()
        {
            Start();
            Accelerate(200);
            Stop();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            IVehicle vehicle = new CarAdapter(car);

            Console.WriteLine("usage car with adapter");
            vehicle.Start();
            vehicle.Accelerate(200);
            vehicle.Stop();

            GodVehicle god = new GodVehicle(car);
            god.all();
        }
    }
}


// magic number 
// hard code 
// cryptic code
// god object
// spaghetti code
// feature envy
// copy-paste
// poor naming
// tight coupling
// golden hammer :)
