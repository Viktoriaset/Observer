using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    interface Subject
    {
        void registerObserver(Observer observer);
        void removeObserver(Observer observer);
        void notifyObservers();
    }

    class WeatherData : Subject
    {
        private List<Observer> observers = new List<Observer>();
        private float Tempture;
        private float Humidity;
        private float Pressure;

        public void registerObserver(Observer observer)
        {
            observers.Add(observer);
        }

        public void removeObserver(Observer observer)
        {
            observers.Remove(observer);
        }

        public void notifyObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update(getTemperature(), getHumidity(), getPressure());
            }
        }

        float getTemperature()
        {
            return Tempture;
        }

        float getHumidity()
        {
            return Humidity;
        }
        float getPressure()
        {
            return Pressure;
        }


        public void measurementsChanged(float t, float h, float p)
        {
            Tempture = t;
            Humidity = h;
            Pressure = p;
            notifyObservers();
        }


    }

    interface Observer
    {
        void update(float temperature, float humidity, float pressure);
    }

    class CurrentConditionsDisplay : Observer
    {
        private float temperature;
        private float humidity;
        private float pressure;

        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            display();
        }

        public void display()
        {
            Console.WriteLine("Temperature: " + temperature);
            Console.WriteLine("Humidity: " + humidity);
            Console.WriteLine("Pressure: " + pressure);
        }
    }

    class StatisticsDisplay : Observer
    {
        private float temperature;
        private float humidity;
        private float pressure;

        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            display();
        }

        public void display()
        {
            Console.WriteLine("Temperature: " + temperature);
            Console.WriteLine("Humidity: " + humidity);
            Console.WriteLine("Pressure: " + pressure);
        }
    }

    class ForecastDisplay : Observer
    {
        private float temperature;
        private float humidity;
        private float pressure;

        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            display();
        }

        public void display()
        {
            Console.WriteLine("Temperature: " + temperature);
            Console.WriteLine("Humidity: " + humidity);
            Console.WriteLine("Pressure: " + pressure);
        }
    }

    class Testing
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            ForecastDisplay forecastDisplay = new ForecastDisplay();
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay();
            CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay();
            weatherData.registerObserver(forecastDisplay);
            weatherData.registerObserver(statisticsDisplay);
            weatherData.registerObserver(currentConditionsDisplay);

            weatherData.measurementsChanged(12, 13, 14);

            forecastDisplay.display();
            statisticsDisplay.display();
            currentConditionsDisplay.display();

            Console.Read();
            

        }
    }
}
