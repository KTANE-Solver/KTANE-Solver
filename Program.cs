namespace New_KTANE_Solver
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);

            //check to make sure no files are missing

            //edgework

            //logfile

            //keypad folder

            //maze arrow folder and all its images

            if (
                !FileExists("Edgework.txt")
                || !FileExists("LogFile.txt")
                || !DirectoryExists("Keypad Pictures")
                || !DirectoryExists("Maze Arrows")
                || !DirectoryExists("Astrology Pictures")
                || !FileExists("Preferences.txt")
            )
            {
                return;
            }

            //all keypad pictures
            if (
                !KeypadFileExist("3")
                || !KeypadFileExist("6")
                || !KeypadFileExist("A")
                || !KeypadFileExist("AE")
                || !KeypadFileExist("B")
                || !KeypadFileExist("Backwards C")
                || !KeypadFileExist("Black Star")
                || !KeypadFileExist("Butt")
                || !KeypadFileExist("C")
                || !KeypadFileExist("Copyright")
                || !KeypadFileExist("E")
                || !KeypadFileExist("H")
                || !KeypadFileExist("Hashtag")
                || !KeypadFileExist("Lambda")
                || !KeypadFileExist("Lightning")
                || !KeypadFileExist("N")
                || !KeypadFileExist("O")
                || !KeypadFileExist("Omega")
                || !KeypadFileExist("Paragraph")
                || !KeypadFileExist("Question Mark")
                || !KeypadFileExist("Smily Face")
                || !KeypadFileExist("Squid")
                || !KeypadFileExist("Swirl")
                || !KeypadFileExist("Swirl")
                || !KeypadFileExist("Unfinished R")
                || !KeypadFileExist("White Star")
                || !KeypadFileExist("X")
            )
            {
                return;
            }

            //all astrology pictures
            if (
                !AstrologyFileExist("Air")
                || !AstrologyFileExist("Aquarius")
                || !AstrologyFileExist("Aries")
                || !AstrologyFileExist("Cancer")
                || !AstrologyFileExist("Capricorn")
                || !AstrologyFileExist("Earth")
                || !AstrologyFileExist("Fire")
                || !AstrologyFileExist("Gemini")
                || !AstrologyFileExist("Jupiter")
                || !AstrologyFileExist("Leo")
                || !AstrologyFileExist("Libra")
                || !AstrologyFileExist("Mars")
                || !AstrologyFileExist("Mercury")
                || !AstrologyFileExist("Moon")
                || !AstrologyFileExist("Neptune")
                || !AstrologyFileExist("Pisces")
                || !AstrologyFileExist("Pluto")
                || !AstrologyFileExist("Sagittarius")
                || !AstrologyFileExist("Saturn")
                || !AstrologyFileExist("Scorpio")
                || !AstrologyFileExist("Sun")
                || !AstrologyFileExist("Taurus")
                || !AstrologyFileExist("Uranus")
                || !AstrologyFileExist("Venus")
                || !AstrologyFileExist("Virgo")
                || !AstrologyFileExist("Water")
            )
            {
                return;
            }

            //all maze arrows
            if (
                !MazeFileExists("up arrow")
                || !MazeFileExists("left arrow")
                || !MazeFileExists("right arrow")
                || !MazeFileExists("down arrow")
            )
            {
                return;
            }

            Application.Run(new EdgeworkSelectionForm());
        }

        static bool FileExists(String name)
        {
            if (!File.Exists(name))
            {
                MessageBox.Show(
                    $"Unable to find {name}. Redownload bot and try again",
                    "File Missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            return true;
        }

        static bool DirectoryExists(String name)
        {
            if (!Directory.Exists(name))
            {
                MessageBox.Show(
                    $"Unable to find {name}. Redownload bot and try again",
                    "Directory Missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            return true;
        }

        static bool KeypadFileExist(String name)
        {
            if (!File.Exists($"Keypad Pictures/{name}.png"))
            {
                MessageBox.Show(
                    $"Unable to find {name}.png. Redownload bot and try again",
                    "File Missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            return true;
        }

        static bool AstrologyFileExist(String name)
        {
            if (!File.Exists($"Astrology Pictures/{name}.png"))
            {
                MessageBox.Show(
                    $"Unable to find {name}.png. Redownload bot and try again",
                    "File Missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            return true;
        }

        static bool MazeFileExists(string name)
        {
            if (!File.Exists($"Maze Arrows/{name}.png"))
            {
                MessageBox.Show(
                    $"Unable to find {name}.png. Redownload bot and try again",
                    "File Missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            return true;
        }
    }
}