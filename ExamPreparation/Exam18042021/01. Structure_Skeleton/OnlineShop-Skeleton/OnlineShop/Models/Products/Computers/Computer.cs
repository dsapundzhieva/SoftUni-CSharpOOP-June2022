using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        private double overallPerformance;
        private decimal price;


        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
            this.overallPerformance = overallPerformance;
            this.price = price;
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public override double OverallPerformance 
        {
            get => this.components.Select(c => c.OverallPerformance).Average() + overallPerformance;
        }

        public override decimal Price => price + this.components.Select(c => c.Price).Sum() + this.peripherals.Select(p => p.Price).Sum();
        public void AddComponent(IComponent component)
        {
            if (this.components.GetType().Name == component.GetType().Name)
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var componentToRemove = this.components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (componentToRemove == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            this.components.Remove(componentToRemove);
            return componentToRemove;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.GetType().Name == peripheral.GetType().Name)
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            this.peripherals.Add(peripheral);
        }

        
        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheralToRemove = this.peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);

            if (peripheralToRemove == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            this.peripherals.Remove(peripheralToRemove);
            return peripheralToRemove;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($" Components ({this.components.Count}):");

            foreach (var component in this.components)
            {
                result.AppendLine($"  {component.ToString()}");
            }

            var avaragePerformance = this.peripherals.Count > 0 ? this.peripherals.Select(p => p.OverallPerformance).Average() : 0.00;

            result.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({avaragePerformance:F2}):");

            foreach (var peripheral in this.peripherals)
            {
                result.AppendLine($"  {peripheral.ToString()}");
            }

            return result.ToString().Trim();
        }
    }
}
