using System.Text;

namespace AcademyScheduleAnalyzer
{
    internal class Program
    {
        public static void DisplaySessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            Console.WriteLine("=== All Sessions ===");
            for (int i = 0; i < sessionNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {sessionNames[i]}");
            }
            Console.WriteLine();
        }

        public static void DisplaySessionDetails(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            Console.WriteLine("Session Details:");
            Console.WriteLine("----------------");
            for (int i = 0; i < sessionNames.Length; i++)
            {
                Console.WriteLine($"Session Name: {sessionNames[i]}");
                Console.WriteLine($"Date: {DateOnly.FromDateTime(sessionDates[i]).ToLongDateString()}");
                Console.WriteLine($"Time: {sessionDates[i].ToString("hh:mm tt")}");
                Console.WriteLine($"End Time: {GetSessionEndTime(sessionDates[i], sessionDurations[i]).ToString("hh:mm tt")}");
                Console.WriteLine($"Duration: {sessionDurations[i]} minutes");
                Console.WriteLine();
            }
        }

        public static void SearchSession(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations, string searchTerm)
        {
            int foundIndex = Array.FindIndex(sessionNames, session => session.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));

            if (foundIndex != -1)
            {
                DisplaySessionDetails(new string[] { sessionNames[foundIndex] }, new DateTime[] { sessionDates[foundIndex] }, new int[] { sessionDurations[foundIndex] });
            }
            else
            {
                Console.WriteLine("Session not found.\n");
            }
        }

        public static int GetTotalDuration(int[] sessionDurations)
        {
            int total = 0;
            foreach (var duration in sessionDurations)
            {
                total += duration;
            }
            return total;
        }

        public static double GetAverageDuration(int[] sessionDurations)
        {
            if (sessionDurations.Length == 0)
                return 0;
            return (double)GetTotalDuration(sessionDurations) / sessionDurations.Length;
        }

        public static int GetShortestDuration(int[] sessionDurations)
        {
            if (sessionDurations.Length == 0)
                return 0;
            int shortest = int.MaxValue;
            foreach (var duration in sessionDurations)
            {
                if (duration < shortest)
                    shortest = duration;
            }
            return shortest;
        }

        public static int GetLongestDuration(int[] sessionDurations)
        {
            if (sessionDurations.Length == 0)
                return 0;
            int longest = int.MinValue;
            foreach (var duration in sessionDurations)
            {
                if (duration > longest)
                    longest = duration;
            }
            return longest;
        }

        public static DateTime GetSessionEndTime(DateTime startTime, int durationMinutes)
        {
            return startTime.AddMinutes(durationMinutes);
        }

        public static DateTime ReadSessionDate()
        {
            Console.Write("Enter session date (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                return date;
            }
            return DateTime.Now;
        }

        public static void ModifyIntegerByRef(ref int value)
        {
            Console.WriteLine($"Inside function - Original value: {value}");
            value = value * 2;
            Console.WriteLine($"Inside function - Modified value: {value}");
        }

        public static bool FindSessionInfo(string[] sessionNames, int[] sessionDurations, string searchName, out int sessionIndex, out int duration)
        {
            sessionIndex = Array.FindIndex(sessionNames, s => s.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (sessionIndex != -1)
            {
                duration = sessionDurations[sessionIndex];
                return true;
            }

            duration = 0;
            return false;
        }

        public static void ModifyArrayElement(string[] sessionNames, int index, string newValue)
        {
            if (index >= 0 && index < sessionNames.Length)
            {
                sessionNames[index] = newValue;
            }
        }

        public static void DisplaySessionWithDateTimeProperties(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            Console.Write("Enter session name to view details: ");
            string? searchTerm = Console.ReadLine();

            int foundIndex = Array.FindIndex(sessionNames, session => session.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));

            if (foundIndex != -1)
            {
                DateTime sessionDate = sessionDates[foundIndex];
                int duration = sessionDurations[foundIndex];
                DateTime endTime = GetSessionEndTime(sessionDate, duration);

                Console.WriteLine($"\nSession: {sessionNames[foundIndex]}");
                Console.WriteLine($"Date: {sessionDate.ToString("dd MMMM yyyy")}");
                Console.WriteLine($"Day: {sessionDate.DayOfWeek}");
                Console.WriteLine($"Year: {sessionDate.Year}");
                Console.WriteLine($"Month: {sessionDate.Month}");
                Console.WriteLine($"Day Number: {sessionDate.Day}");
                Console.WriteLine($"Start Time: {sessionDate.ToString("hh:mm tt")}");
                Console.WriteLine($"Duration: {duration} minutes");
                Console.WriteLine($"End Time: {endTime.ToString("hh:mm tt")}\n");
            }
            else
            {
                Console.WriteLine("Session not found.\n");
            }
        }

        public static DateTime FindSessionDate(string[] sessionNames, DateTime[] sessionDates, string? sessionName)
        {
            int index = Array.FindIndex(sessionNames, s => s.Equals(sessionName, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
                return sessionDates[index];
            return DateTime.MinValue;
        }

        public static void DisplayDateDifference(string[] sessionNames, DateTime[] sessionDates)
        {
            Console.Write("Enter first session name: ");
            string? firstSession = Console.ReadLine();

            Console.Write("Enter second session name: ");
            string? secondSession = Console.ReadLine();

            DateTime date1 = FindSessionDate(sessionNames, sessionDates, firstSession);
            DateTime date2 = FindSessionDate(sessionNames, sessionDates, secondSession);

            if (date1 != DateTime.MinValue && date2 != DateTime.MinValue)
            {
                TimeSpan difference = date2 - date1;

                Console.WriteLine($"\nFirst Session: {firstSession}");
                Console.WriteLine($"Second Session: {secondSession}");
                Console.WriteLine("Difference:");
                Console.WriteLine($"{Math.Abs(difference.Days)} days");
                Console.WriteLine($"{Math.Abs(difference.TotalHours):F0} hours\n");
            }
            else
            {
                Console.WriteLine("One or both sessions not found.\n");
            }
        }

        public static void DisplaySessionsStatus(string[] sessionNames, DateTime[] sessionDates)
        {
            Console.WriteLine("\n=== Session Status (Past/Upcoming) ===");
            for (int i = 0; i < sessionNames.Length; i++)
            {
                string status = sessionDates[i] < DateTime.Now ? "Past" : "Upcoming";
                Console.WriteLine($"{sessionNames[i]}: {status}");
            }
            Console.WriteLine();
        }

        public static string BuildReportUsingString(string[] sessionNames, int[] sessionDurations)
        {
            string report = "=== Session Duration Report ===\n";
            for (int i = 0; i < sessionNames.Length; i++)
            {
                report += sessionNames[i] + ": " + sessionDurations[i] + " minutes\n";
            }
            report += "\nTotal Duration: " + GetTotalDuration(sessionDurations) + " minutes\n";
            report += "Average Duration: " + GetAverageDuration(sessionDurations).ToString("F2") + " minutes\n";
            report += "Shortest: " + GetShortestDuration(sessionDurations) + " minutes\n";
            report += "Longest: " + GetLongestDuration(sessionDurations) + " minutes\n";
            return report;
        }

        public static string BuildReportUsingStringBuilder(string[] sessionNames, int[] sessionDurations)
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("=== Session Duration Report (StringBuilder) ===");

            for (int i = 0; i < sessionNames.Length; i++)
            {
                report.AppendLine($"{sessionNames[i]}: {sessionDurations[i]} minutes");
            }

            report.AppendLine($"\nTotal Duration: {GetTotalDuration(sessionDurations)} minutes");
            report.AppendLine($"Average Duration: {GetAverageDuration(sessionDurations):F2} minutes");
            report.AppendLine($"Shortest: {GetShortestDuration(sessionDurations)} minutes");
            report.AppendLine($"Longest: {GetLongestDuration(sessionDurations)} minutes");

            return report.ToString();
        }

        public static void CalculateTotalDuration(params int[] durations)
        {
            int result = 0;
            foreach (var duration in durations)
            {
                result += duration;
            }
            Console.WriteLine($"Total Duration (using params): {result} minutes");
        }

        // FIXED: the original loop compared neighbouring dates and could leave nextSession
        // as DateTime.MaxValue (crashing on the IndexOf lookup). This picks the earliest
        // session that is still in the future, and handles "no upcoming sessions".
        public static void FindNextSession(string[] sessionname, DateTime[] sessiondates)
        {
            DateTime currentDate = DateTime.Now;
            int nextIndex = -1;

            for (int i = 0; i < sessiondates.Length; i++)
            {
                if (sessiondates[i] > currentDate &&
                    (nextIndex == -1 || sessiondates[i] < sessiondates[nextIndex]))
                {
                    nextIndex = i;
                }
            }

            if (nextIndex == -1)
            {
                Console.WriteLine("No upcoming sessions.\n");
                return;
            }

            DateTime nextSession = sessiondates[nextIndex];
            TimeSpan remaining = nextSession - currentDate;

            Console.WriteLine("Next Session:");
            Console.WriteLine($"{sessionname[nextIndex]}");
            Console.WriteLine($"{nextSession:dd MMMM yyyy}");
            Console.WriteLine($"{nextSession:hh:mm tt}");
            Console.WriteLine("Time Remaining:");
            Console.WriteLine($"{remaining.Days} days");
            Console.WriteLine($"{remaining.Hours} hours\n");
        }

        public static void DisplaySessionFormatted(string sessionName, DateTime sessionDate)
        {
            Console.WriteLine($"Session: {sessionName}");
            Console.WriteLine($"Date: {sessionDate.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Date: {sessionDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Date: {sessionDate.ToString("dd MMMM yyyy")}");
            Console.WriteLine($"Date: {sessionDate.ToString("dddd, dd MMMM yyyy")}");
            Console.WriteLine($"Time: {sessionDate.ToString("hh:mm tt")}");
        }

        public static DateTime ReadAndValidateDate()
        {
            string format = "yyyy-MM-dd HH:mm";
            DateTime validDate;

            while (true)
            {
                Console.Write("Enter date (yyyy-MM-dd HH:mm): ");
                string? input = Console.ReadLine();

                if (DateTime.TryParseExact(input, format,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out validDate))
                {
                    return validDate;
                }

                Console.WriteLine("Invalid format. Please use: yyyy-MM-dd HH:mm\n");
            }
        }

        public static void ExceptionHandlingMenuInput()
        {
            while (true)
            {
                Console.Write("Enter a number between 1 and 5: ");
                string? input = Console.ReadLine();
                try
                {
                    int choice = int.Parse(input!);
                    if (choice < 1 || choice > 5)
                    {
                        throw new ArgumentOutOfRangeException("Choice must be between 1 and 5.");
                    }
                    Console.WriteLine($"You selected option {choice}.\n");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.\n");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                }
            }
        }

        public static void ExceptionHandlingInvalidArrayIndex(string[] sessionNames)
        {
            while (true)
            {
                Console.Write($"Enter an index to access the session name (0-{sessionNames.Length - 1}): ");
                string? input = Console.ReadLine();
                try
                {
                    int index = int.Parse(input!);
                    Console.WriteLine($"Session at index {index}: {sessionNames[index]}\n");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.\n");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"Index out of range. Please enter a number between 0 and {sessionNames.Length - 1}.\n");
                }
            }
        }

        // FIXED: removed the unused int parameter (the original call had none),
        // and gave the ArgumentException a message so it prints something useful.
        public static void ValidateSessionDuration()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter session duration in minutes: ");
                    int inputDuration = int.Parse(Console.ReadLine()!);
                    if (inputDuration > 0)
                    {
                        Console.WriteLine($"Session duration: {inputDuration} minutes");
                        break;
                    }
                    throw new ArgumentException("Duration must be greater than 0.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.\n");
                }
                finally
                {
                    Console.WriteLine("\nInput operation finished.\n");
                }
            }
        }

        public static string GenerateScheduleReportString(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            string result = "";

            for (int i = 0; i < sessionNames.Length; i++)
            {
                result += $"{sessionNames[i]} - {sessionDates[i].ToString("dd/MM/yyyy hh:mm tt")} - {sessionDurations[i]} minutes";

                if (i < sessionNames.Length - 1)
                {
                    result += "\n";
                }
            }

            return result;
        }

        public static string GenerateScheduleReportStringBuilder(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            StringBuilder report = new StringBuilder();

            for (int i = 0; i < sessionNames.Length; i++)
            {
                report.Append($"{sessionNames[i]} - {sessionDates[i].ToString("dd/MM/yyyy hh:mm tt")} - {sessionDurations[i]} minutes");

                if (i < sessionNames.Length - 1)
                {
                    report.AppendLine();
                }
            }

            return report.ToString();
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("     Academy Schedule Analyzer");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Display all sessions");
            Console.WriteLine("2. Search for a session");
            Console.WriteLine("3. Sort session names");
            Console.WriteLine("4. Reverse session names");
            Console.WriteLine("5. Find session index");
            Console.WriteLine("6. Check if session exists");
            Console.WriteLine("7. Show duration statistics");
            Console.WriteLine("8. Show session date details");
            Console.WriteLine("9. Show past and upcoming sessions");
            Console.WriteLine("10. Find next session");
            Console.WriteLine("11. Compare two session dates");
            Console.WriteLine("12. Read and validate a custom date");
            Console.WriteLine("13. Select session by index");
            Console.WriteLine("14. Validate session duration");
            Console.WriteLine("15. Generate report using string");
            Console.WriteLine("16. Generate report using StringBuilder");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
        }

        static void Main(string[] args)
        {
            string[] sessionNames =
            {
                "C# Basics",
                "Arrays",
                "Functions",
                "Date and Time",
                "Exception Handling"
            };

            DateTime[] sessionDates =
            {
                new DateTime(2026, 9, 10, 18, 0, 0),
                new DateTime(2026, 9, 13, 18, 0, 0),
                new DateTime(2026, 9, 17, 18, 0, 0),
                new DateTime(2026, 9, 20, 18, 0, 0),
                new DateTime(2026, 9, 24, 18, 0, 0)
            };

            int[] sessionDurations =
            {
                180,
                240,
                180,
                240,
                180
            };

            int choice;

            do
            {
                DisplayMenu();

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = -1; // non-numeric input -> falls into default
                }
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        DisplaySessions(sessionNames, sessionDates, sessionDurations);
                        break;

                    case 2:
                        Console.Write("Enter session name to search: ");
                        string? searchTerm = Console.ReadLine();
                        SearchSession(sessionNames, sessionDates, sessionDurations, searchTerm ?? "");
                        break;

                    case 3:
                        // Sort a copy so the original order is preserved
                        string[] sortedNames = (string[])sessionNames.Clone();
                        Array.Sort(sortedNames);
                        Console.WriteLine("=== Sorted Session Names ===");
                        foreach (string name in sortedNames)
                        {
                            Console.WriteLine($"- {name}");
                        }
                        Console.WriteLine();
                        break;

                    case 4:
                        string[] reversedNames = (string[])sessionNames.Clone();
                        Array.Reverse(reversedNames);
                        Console.WriteLine("=== Reversed Session Names ===");
                        foreach (string name in reversedNames)
                        {
                            Console.WriteLine($"- {name}");
                        }
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.Write("Enter session name to search: ");
                        string? indexSearch = Console.ReadLine();
                        if (FindSessionInfo(sessionNames, sessionDurations, indexSearch ?? "", out int foundIndex, out int foundDuration))
                        {
                            Console.WriteLine("Session Found!");
                            Console.WriteLine($"Index: {foundIndex}");
                            Console.WriteLine($"Duration: {foundDuration} minutes\n");
                        }
                        else
                        {
                            Console.WriteLine("Session not found.\n");
                        }
                        break;

                    case 6:
                        Console.Write("Enter session name to check: ");
                        string? existsSearch = Console.ReadLine();
                        bool exists = Array.Exists(sessionNames,
                            s => s.Equals(existsSearch, StringComparison.OrdinalIgnoreCase));
                        Console.WriteLine(exists ? "Session exists.\n" : "Session does not exist.\n");
                        break;

                    case 7:
                        Console.WriteLine("=== Duration Statistics ===");
                        Console.WriteLine($"Total Duration: {GetTotalDuration(sessionDurations)} minutes");
                        Console.WriteLine($"Average Duration: {GetAverageDuration(sessionDurations):F2} minutes");
                        Console.WriteLine($"Shortest Session: {GetShortestDuration(sessionDurations)} minutes");
                        Console.WriteLine($"Longest Session: {GetLongestDuration(sessionDurations)} minutes\n");
                        break;

                    case 8:
                        DisplaySessionWithDateTimeProperties(sessionNames, sessionDates, sessionDurations);
                        break;

                    case 9:
                        DisplaySessionsStatus(sessionNames, sessionDates);
                        break;

                    case 10:
                        FindNextSession(sessionNames, sessionDates);
                        break;

                    case 11:
                        DisplayDateDifference(sessionNames, sessionDates);
                        break;

                    case 12:
                        DateTime userDate = ReadAndValidateDate();
                        Console.WriteLine($"You entered: {userDate:dd MMMM yyyy HH:mm}\n");
                        break;

                    case 13:
                        ExceptionHandlingInvalidArrayIndex(sessionNames);
                        break;

                    case 14:
                        ValidateSessionDuration();
                        break;

                    case 15:
                        Console.WriteLine(BuildReportUsingString(sessionNames, sessionDurations));
                        break;

                    case 16:
                        Console.WriteLine(BuildReportUsingStringBuilder(sessionNames, sessionDurations));
                        break;

                    case 0:
                        Console.WriteLine("Exiting... Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            } while (choice != 0);
        }
    }
}