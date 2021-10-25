using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF18M009_Rentajet
{
    class AircraftJet
    {
        public int quantity { get; set; }
        public string manufacturer { get; set; }
        public string type { get; set; }
        public int crewFlight { get; set; }
        public int cabin { get; set; }
        public double range { get; set; }
        public int maxPeople { get; set; }
        public double speed { get; set; }
        public int totalEngines { get; set; }
        public string engineType { get; set; }
        public double annualFixedCost { get; set; }
        public double hourlyRate { get; set; }
        public AircraftJet(int quantity, string manufacturer, 
            string type, int crewFlight, int cabin, double range, 
            int maxPeople, double speed, int totalEngines, string engineType, double annualFixedCost, double hourlyRate)
        {
            this.quantity = quantity;
            this.manufacturer = manufacturer;
            this.type = type;
            this.crewFlight = crewFlight;
            this.cabin = cabin;
            this.range = range;
            this.maxPeople = maxPeople;
            this.speed = speed;
            this.totalEngines = totalEngines;
            this.engineType = engineType;
            this.annualFixedCost = annualFixedCost;
            this.hourlyRate = hourlyRate;
        }
    }
}

