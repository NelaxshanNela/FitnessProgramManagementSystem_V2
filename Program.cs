namespace FitnessProgramManagementSystem_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FitnessProgramRepository repository = new FitnessProgramRepository();
            bool exit = true;

            while (exit)
            {
                Console.WriteLine("FitnessProgram Management System:");
                Console.WriteLine("1. Add a FitnessProgram");
                Console.WriteLine("2. View All FitnessPrograms");
                Console.WriteLine("3. Update a FitnessProgram");
                Console.WriteLine("4. Delete a FitnessProgram");
                Console.WriteLine("5. View a single FitnessProgram");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        repository.AddProgram();
                        break;
                    case "2":
                        Console.WriteLine(repository.GetAllProgram());
                        break;
                    case "3":
                        repository.UpdateProgram();
                        break;
                    case "4":
                        repository.DeleteProgram();
                        break;
                    case "5":
                        Console.WriteLine(repository.GetProgramById());
                        break;
                    case "6":
                        Console.WriteLine("Program existing Thank you");
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Enter the correct number");
                        break;
                }
            }
        }
    }
}
