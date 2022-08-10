using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<Models.Products.Components.IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<Models.Products.Components.IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            IComputer computer = computerType switch
            {
                nameof(DesktopComputer) => new DesktopComputer(id, manufacturer, model, price),
                nameof(Laptop) => new Laptop(id, manufacturer, model, price),
                _ => throw new ArgumentException("Computer type is invalid.")
            };

            this.computers.Add(computer);
            return $"Computer with id {id} added successfully.";
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException($"Component with this id already exists.");
            }

            Models.Products.Components.IComponent component = componentType switch
            {
                nameof(CentralProcessingUnit) => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                nameof(Motherboard) => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                nameof(PowerSupply) => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                nameof(RandomAccessMemory) => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                nameof(SolidStateDrive) => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                nameof(VideoCard) => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException("Component type is invalid.")
            };

            this.computers.FirstOrDefault(c => c.Id == computerId).AddComponent(component);
            this.components.Add(component);

            return $"Component {component.GetType().Name} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }

            var findComponentToRemove = this.computers.First(computer => computer.Id == computerId).RemoveComponent(componentType);

            var componentId = findComponentToRemove.Id;

            this.components.Remove(findComponentToRemove);

            return $"Successfully removed {componentType} with id {componentId}.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }

            if (this.peripherals.Any(c => c.Id == id))
            {
                throw new ArgumentException($"Peripheral with this {id} already exists.");
            }

            IPeripheral peripheral = peripheralType switch
            {
                nameof(Headset) => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Keyboard) => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Monitor) => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Mouse) => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                _ => throw new ArgumentException("Peripheral type is invalid.")
            };

            this.computers.FirstOrDefault(c => c.Id == computerId).AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }

            var findPeripheralToRemove = this.computers.First(computer => computer.Id == computerId).RemovePeripheral(peripheralType);

            var peripheralId = findPeripheralToRemove.Id;

            this.peripherals.Remove(findPeripheralToRemove);

            return $"Successfully removed {peripheralType} with id {peripheralId}.";
        }

        public string BuyComputer(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }

            Computer computerToRemove = (Computer)this.computers.FirstOrDefault(c => c.Id == id);

            var result = computerToRemove.ToString();

            this.computers.Remove(computerToRemove);

            return result;
        }

        public string BuyBest(decimal budget)
        {
            Computer computerWithHigestPerformance = (Computer)this.computers.OrderByDescending(c => c.OverallPerformance).FirstOrDefault();

            if (computerWithHigestPerformance == null || computerWithHigestPerformance.Price > budget)
            {
                throw new ArgumentException($" Can't buy a computer with a budget of ${budget}.");
            }

            this.computers.Remove(computerWithHigestPerformance);

            return computerWithHigestPerformance.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }

            return this.computers.FirstOrDefault(c => c.Id == id).ToString();
        }
    }
}
