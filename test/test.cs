using System;
using System.IO;
using Xunit;
using Nyashka;

namespace Nyashka.Tests
{
    [Collection("NonParallelTests")]
    public class CarAdapterTests
    {
        [Fact]
        public void start_turnon()
        {
            var car = new Car();
            var adapter = new CarAdapter(car);
            var original = Console.Out;

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            
            adapter.Start();
            Console.Out.Flush();

            Assert.Equal("turn on\n", consoleOutput.ToString());

            Console.SetOut(original);
            consoleOutput.Dispose();
        }

        [Fact]
        public void stop_turnoff()
        {
            var car = new Car();
            var adapter = new CarAdapter(car);

            var original = Console.Out; 

            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput); 

                adapter.Stop();
                Console.Out.Flush(); 

                Assert.Equal("turn off\n", consoleOutput.ToString());
            }

            Console.SetOut(original); 
        }

        [Fact]
        public void accelerate_speed()
        {
            var car = new Car();
            var adapter = new CarAdapter(car);
            var original = Console.Out;

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            int speed = 120;
            adapter.Accelerate(speed);
            Console.Out.Flush();

            Assert.Equal("mya\n", consoleOutput.ToString());

            Console.SetOut(original);
            consoleOutput.Dispose();
        }
    }
    
    
    [Collection("NonParallelTests")]
    public class CarTests
    {
        [Fact]
        public void turnon()
        {
            var car = new Car();
            var original = Console.Out;

            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                car.TurnOn();
                Console.Out.Flush();

                Assert.Equal("turn on\n", consoleOutput.ToString());
            }

            Console.SetOut(original);
        }
        
        [Fact]
        public void turnoff()
        {
            var car = new Car();
            var original = Console.Out;

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
    
            car.TurnOff();
            Console.Out.Flush();
    
            Assert.Equal("turn off\n", consoleOutput.ToString());
    
            Console.SetOut(original);
            consoleOutput.Dispose();
        }

        [Fact]
        public void Speed()
        {
            var car = new Car();
            var original = Console.Out;

            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                int speed = 120;
                car.SetSpeed(speed);
                Console.Out.Flush();

                Assert.Equal($"speed: {speed}\n", consoleOutput.ToString());
            }

            Console.SetOut(original);
        }
    } 


    [Collection("NonParallelTests")]
    public class GodVehicleTests
    {
        [Fact]
        public void Start()
        {
            var car = new Car();
            var godVehicle = new GodVehicle(car);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            godVehicle.Start();

            var output = consoleOutput.ToString().Trim();
            Assert.Contains("turn on", output);
            Assert.Contains("god start", output);
        }

        [Fact]
        public void Stop()
        {
            var car = new Car();
            var godVehicle = new GodVehicle(car);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            godVehicle.Stop();

            var output = consoleOutput.ToString().Trim();
            Assert.Contains("turn off", output);
            Assert.Contains("god stop", output);
        }

        [Fact]
        public void Accelerate200()
        {
            var car = new Car();
            var godVehicle = new GodVehicle(car);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            godVehicle.Accelerate(200);

            var output = consoleOutput.ToString().Trim();
            Assert.Contains("speed: 200", output);
            Assert.Contains("god acceleration", output);
        }

        [Fact]
        public void Acceleratenot200()
        {
            var car = new Car();
            var godVehicle = new GodVehicle(car);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            godVehicle.Accelerate(100);

            var output = consoleOutput.ToString().Trim();
            Assert.Contains("mya", output);
            Assert.Contains("god acceleration", output);
        }

        [Fact]
        public void All()
        {
            var car = new Car();
            var godVehicle = new GodVehicle(car);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            godVehicle.all();

            var output = consoleOutput.ToString().Trim();
            Assert.Contains("turn on", output);
            Assert.Contains("god start", output);
            Assert.Contains("speed: 200", output);
            Assert.Contains("god acceleration", output);
            Assert.Contains("turn off", output);
            Assert.Contains("god stop", output);
        }
    }
}
