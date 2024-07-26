using EmploymentContracts.Entities.Enums;

namespace EmploymentContracts.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }  // Associação entre duas classes diferentes (Composição de objetos)
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); // Um trabalhador pode ter vários contratos de trabalhos

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary; // O trabalhador irá ganhar o trabalho base em todos os casos
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                    sum += contract.TotalValue();
            }
            return sum;
        }
    }
}
