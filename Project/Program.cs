using System;

namespace PST1 {
    /// <summary>
    /// This program can be used to calculate simple interest and compound 
    /// interest.
    /// </summary>
    /// <author> Khanh Duy Nguyen </author>
    /// <studentID> n9784616 </studentID>

    class MainClass {

       

        public static void Main(string[] args) {

            // Welcome message
            Console.WriteLine("<<<WELCOME TO THE FINANCIAL CALCULATOR>>>");

            // Declare user choice variable 
            double userChoice;

            // Declare choice numbers
            const int simpleInterestCal = 1;
            const int compoundInterestCal = 2;
            const int exit = 3;


            do {
                // Display the main menu
                DisplayMainMenu();

                // Get the choice from user
                userChoice = GetUserNum("\nEnter your choice: ",
                                              1, 3, true);

                // User chooses Simple interest calculator
                if (userChoice == simpleInterestCal) {
                    CalculateSimpleInterest();

                    // User chooses Coumpoud interest calculator
                } else if (userChoice == compoundInterestCal) {
                    CalculateCoumpoundInterest();
                }

                // Repeat as long as the choice is not exit
            } while (userChoice != exit);

            // Thank you message
            Console.WriteLine("<<<THANK YOU FOR USING THE FINANCIAL CALCULATOR!>>>");

        }

        /// <summary>
        /// Display the main menu including 3 choices for user to choose
        /// </summary>
        static void DisplayMainMenu() {

            // Display main menu
            Console.WriteLine(
                "\n Main menu:" +
                "\n     1. Simple interest calculator" +
                "\n     2. Compound interest calculator" +
                "\n     3. Exit" +
                "\n");

        }

        /// <summary>
        /// Get a number from user
        /// </summary>
        /// <returns>The number user typed</returns>
        /// <param name="message">The description of the number</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <param name="wholeNumber">If set to <c>true</c>, the number must be
        ///  a whole number.</param>
        static double GetUserNum(string message = "Enter a number: ",
                         double min = double.MinValue,
                         double max = double.MaxValue,
                         bool wholeNumber = false) {

            // Declare variables
            double userNum;
            bool parseResult;

            do {
                // Write the message
                Console.WriteLine(message);

                // Declare user input variable
                string userInput = Console.ReadLine();

                // Attempt to convert the user input into a double
                parseResult = double.TryParse(userInput, out userNum);

                // Display an error message if necessary
                if (parseResult == false) {

                    // Parsing failed
                    Console.WriteLine("Input must be numeric.\n");
                } else if (userNum < min) {

                    // Parsing was successful but input was smaller than min
                    Console.WriteLine("Input must be at least {0}.\n", min);

                } else if (userNum > max) {

                    // Parsing was successful but input was bigger than max
                    Console.WriteLine("Input must be at most {0}.\n", max);

                } else if (wholeNumber == true && (int)userNum < userNum) {

                    // Parsing was successful, check if input is a whole number
                    Console.WriteLine("Input must be a whole number.\n");
                }

            } while (parseResult == false || userNum < min || userNum > max || 
                     ((int)userNum < userNum && wholeNumber == true));
            // Repeat until parsing is successful and input is correct

            // Return user input
            return userNum;

        }

        /// <summary>
        /// Calculate the simple interest 
        /// </summary>
        static void CalculateSimpleInterest () {

            // Display welcome message for simple interest calculator
            Console.WriteLine("\n<< Simple Interest Calculator >>");

            // Get the principle amount from user
            double principleAmount = GetUserNum("\nEnter the principle amount: ", 0);

            // Get the interest rate per time period from user
            double interestRate = GetUserNum("Enter the interest rate per time period (%): ", 0);

            // Get the number of time periods from user
            double timePeriodNum = GetUserNum("Enter the number of time periods: ", 0);

            // Calculate the final value
            double totalAmount = principleAmount * (1 + interestRate / 100 * timePeriodNum);

            // Calculate the interest
            double interest = totalAmount - principleAmount;

            // Display results
            Console.WriteLine("\nTotal amount: ${0:N2}" +
                              "\nInterest: ${1:N2}", totalAmount, interest);               
        }

        /// <summary>
        /// Calculates the coumpound interest 
        /// </summary>
        static void CalculateCoumpoundInterest () {

            // Display welcome message for compound interest calculator
            Console.WriteLine("\n<< Compound Interest Calculator >>");

            // Get the principle amount from user
            double principleAmount = GetUserNum("\nEnter the principle amount: ",
                                                0);

            // Get the interest rate per time period from user
            double interestRate = GetUserNum("Enter the interest rate per time" +
                                             " period (%): ", 0);

            // Get the number of time periods from user
            double timePeriodNum = GetUserNum("Enter the number of time periods: ",
                                              0);

            // Get the number of compounds per time period from user
            double compPerTPNum = GetUserNum("Enter the number of compounds per" +
                                             " time period: ", 0, wholeNumber: true);

            // Calculate the final value
            double totalAmount = principleAmount * Math.Pow((1 + interestRate
                                                             / 100 / compPerTPNum)
                                                            , (compPerTPNum * timePeriodNum));

            // Calculate the interest
            double interest = totalAmount - principleAmount;

            // Display results
            Console.WriteLine("\nTotal amount: ${0:N2}" +
                              "\nInterest: ${1:N2}", totalAmount, interest);
        }
    }
}
