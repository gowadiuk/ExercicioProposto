using ExercicoProposto.Entities;
using System.Globalization;

namespace ExercicoProposto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo!!");

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter salary: ");
            double sal = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> employees = new List<Employee>();

           
            


            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string nome = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    employees.Add(new Employee(nome, email, salary));
                }
            }

            var emails = employees.Where(obj => obj.Salary > sal).OrderBy(obj => obj.Email).Select(obj => obj.Email);

            var sum = employees.Where(obj => obj.Name[0] == 'M').Sum(obj => obj.Salary);

            Console.WriteLine("Email of people whose salary is more than " + sal.ToString("f2",CultureInfo.InvariantCulture));
            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("f2",CultureInfo.InvariantCulture));
        
        }
    }
}
