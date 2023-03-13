namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Gets information from the user that is needed to solve 3D Maze
    /// </summary>
    public partial class _3DMazeForm : ModuleForm
    {
        private _3DMaze module;

        public _3DMaze Module
        {
            get { return module; }
        }

        //if the user is currently facing a wall
        private bool facingWall;

        private _3DMazeStage2Form secondStage;

        public _3DMazeForm(Bomb bomb, StreamWriter logFile, ModuleSelectionForm moduleSelectionForm)
            : base(bomb, logFile, moduleSelectionForm, "3D Maze", false)
        {
            InitializeComponent();
            UpdateForm(bomb, logFile, moduleSelectionForm);
        }

        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFile,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            mazeTextBox.Text = "";
            pathTextBox.Text = "";
            facingWallCheckBox.Checked = false;
            UpdateEdgeWork(bomb, logFile, moduleSelectionForm);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            PrintHeader();

            string mazeText = mazeTextBox.Text.ToUpper();

            //maze can only have 3 letters
            if (mazeText.Length != 3)
            {
                ShowErrorMessage("Maze can only have 3 letters");
                return;
            }

            //make sure maze given is valid
            if (
                !(mazeText.Contains('A') && mazeText.Contains('B') && mazeText.Contains('C'))
                && !(mazeText.Contains('A') && mazeText.Contains('B') && mazeText.Contains('D'))
                && !(mazeText.Contains('A') && mazeText.Contains('B') && mazeText.Contains('H'))
                && !(mazeText.Contains('A') && mazeText.Contains('C') && mazeText.Contains('D'))
                && !(mazeText.Contains('A') && mazeText.Contains('C') && mazeText.Contains('H'))
                && !(mazeText.Contains('A') && mazeText.Contains('D') && mazeText.Contains('H'))
                && !(mazeText.Contains('B') && mazeText.Contains('C') && mazeText.Contains('D'))
                && !(mazeText.Contains('B') && mazeText.Contains('C') && mazeText.Contains('H'))
                && !(mazeText.Contains('B') && mazeText.Contains('D') && mazeText.Contains('H'))
                && !(mazeText.Contains('C') && mazeText.Contains('D') && mazeText.Contains('H'))
            )
            {
                ShowErrorMessage("Unaable to find correct maze");
                return;
            }

            module = new _3DMaze(Bomb, LogFileWriter);

            module.SetMaze(mazeText);

            //make sure user puts in valid path input

            string pathText = pathTextBox.Text.ToUpper();

            //can only put in the maze letters, *, ?, N, E, S, or W


            char[] mazeLetters = module.mazeLetters;

            foreach (char c in pathText)
            {
                if (
                    c != '*'
                    && c != '?'
                    && c != 'N'
                    && c != 'E'
                    && c != 'S'
                    && c != 'W'
                    && c != mazeLetters[0]
                    && c != mazeLetters[1]
                    && c != mazeLetters[2]
                )
                {
                    ShowErrorMessage("Path has at least one invalid character: " + c);
                    return;
                }
            }

            facingWall = facingWallCheckBox.Checked;

            PrintDebug($"User path: {pathText} ");

            if (facingWall)
            {
                PrintDebugLine("while facing wall\n");
            }
            else
            {
                PrintDebugLine("while not facing wall\n");
            }

            List<int[]> possiblePaths = ValidPathText(pathText, module);

            //print all possilbe locations
            PrintDebugLine("Possible locations:");

            foreach (int[] possibleLocation in possiblePaths)
            {
                string direction = "";

                switch (possibleLocation[2])
                {
                    case 0:
                        direction = "North";
                        break;
                    case 1:
                        direction = "East";
                        break;
                    case 2:
                        direction = "South";
                        break;
                    case 3:
                        direction = "West";
                        break;
                }

                PrintDebugLine(
                    $"Location [{possibleLocation[0]},{possibleLocation[1]}] Direction: {direction}"
                );
            }

            PrintDebugLine("");

            if (possiblePaths.Count == 0)
            {
                ShowErrorMessage("Unable to find any paths");
                return;
            }
            else if (possiblePaths.Count != 1)
            {
                ShowErrorMessage("Found multiple paths");
                return;
            }

            int[] playerPosition = possiblePaths[0];

            //update the player position
            module.PlayerPosition = module.Maze[playerPosition[0], playerPosition[1]];

            //update the player facing direction
            module.PlayerDirection = module.ConvertPlayerDirection(playerPosition[2]);

            //find how to get to the closest cardinal
            module.FindCardinal(false);

            module.PrintPlayerPosition();

            this.Hide();

            secondStage = new _3DMazeStage2Form(Bomb, LogFileWriter, ModuleSelectionForm, this);

            secondStage.Show();
        }

        private void VerifyNodes()
        {
            int counter = 0;

            foreach (_3DMaze.Node start in module.Maze)
            {
                //verify that start's north has south set to start
                if (start.North != null && start.North.South != start)
                {
                    PrintDebugLine(
                        $"Inconsistencies at {start.Row},{start.Colunm} and {start.North.Row},{start.North.Colunm}\n"
                    );
                    counter++;
                }

                //verify that start's south has north set to start
                if (start.South != null && start.South.North != start)
                {
                    PrintDebugLine(
                        $"Inconsistencies at {start.Row},{start.Colunm} and {start.South.Row},{start.South.Colunm}\n"
                    );
                    counter++;
                }

                //verify that start's east has west set to start
                if (start.East != null && start.East.West != start)
                {
                    PrintDebugLine(
                        $"Inconsistencies at {start.Row},{start.Colunm} and {start.East.Row},{start.East.Colunm}\n"
                    );
                    counter++;
                }

                //verify that start's west has east set to start
                if (start.West != null && start.West.East != start)
                {
                    PrintDebugLine(
                        $"Inconsistencies at {start.Row},{start.Colunm} and {start.West.Row},{start.West.Colunm}\n"
                    );
                    counter++;
                }
            }

            if (counter == 0)
            {
                PrintDebugLine("No inconsistencies found\n");
            }
        }

        private void PrintDebugInfo()
        {
            foreach (_3DMaze.Node start in module.Maze)
            {
                PrintDebugLine("Start: " + GetNodeInformation(start));

                if (start.North != null)
                {
                    PrintDebugLine("North: " + GetNodeInformation(start.North));
                }

                if (start.East != null)
                {
                    PrintDebugLine("East: " + GetNodeInformation(start.East));
                }

                if (start.South != null)
                {
                    PrintDebugLine("South: " + GetNodeInformation(start.South));
                }

                if (start.West != null)
                {
                    PrintDebugLine("West: " + GetNodeInformation(start.West));
                }

                PrintDebugLine("");
            }
        }

        private string GetNodeInformation(_3DMaze.Node node)
        {
            if (node == null)
            {
                return "No information found\n";
            }

            return $"Row {node.Row}, Column {node.Colunm}, Char {node.Character}";
        }

        /// <summary>
        /// Verifies is path is on current maze
        /// </summary>
        /// <param name="path">the path the user gave</param>
        /// <param name="module">the module</param>
        /// <returns>All of the possible paths</returns>
        private List<int[]> ValidPathText(string path, _3DMaze module)
        {
            string newPath = "";

            //convert all N, E, S, W to *
            for (int i = 0; i < path.Length; i++)
            {
                char c = path[i];

                if (c == 'N' || c == 'E' || c == 'S' || c == 'W')
                {
                    newPath += "*";
                }
                //convert all ? to .
                else if (c == '?')
                {
                    newPath += ".";
                }
                else
                {
                    newPath += c;
                }
            }

            //find all possible places user ended up at

            //first digit: ending row (where the user is now)
            //second digit: ending column (where the user is now)
            //third digit: which direction the user is facing
            //0 - north
            //1 - east
            //2 - south
            //3 - west
            List<int[]> possiblePaths = new List<int[]>();

            //find where user can start
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (row == 2 && col == 4)
                    {
                        PrintDebug("");
                    }
                    if (CharacterMatch(module.Maze[row, col], newPath[0]))
                    {
                        //Pick a direction and continue to head in that direction for as many steps the user took
                        //and verify that all steps are corret

                        //North
                        if (NorthValid(newPath, row, col))
                        {
                            int newRow = (row - (newPath.Length - 1));

                            while (newRow < 0)
                            {
                                newRow += 8;
                            }

                            possiblePaths.Add(new int[3] { newRow, col, 0 });
                        }

                        //East
                        if (EastValid(newPath, row, col))
                        {
                            possiblePaths.Add(
                                new int[3] { row, (col + (newPath.Length - 1)) % 8, 1 }
                            );
                        }

                        //South
                        if (SouthValid(newPath, row, col))
                        {
                            possiblePaths.Add(
                                new int[3] { (row + (newPath.Length - 1)) % 8, col, 2 }
                            );
                        }

                        //West
                        if (WestValid(newPath, row, col))
                        {
                            int newCol = (col - (newPath.Length - 1));

                            while (newCol < 0)
                            {
                                newCol += 8;
                            }

                            possiblePaths.Add(new int[3] { row, newCol, 3 });
                        }
                    }
                }
            }

            //if one path can't be found, then path user gave was invalid
            return possiblePaths;
        }

        /// <summary>
        /// Tells if node has the targeted caracter
        /// </summary>
        /// <param name="node"></param>
        /// <param name="target"></param>
        /// <returns>true if there is a match</returns>
        private bool CharacterMatch(_3DMaze.Node node, char target)
        {
            //if target is cardinal, return true if node is blank or has a cardinal
            if (target == '*' && node.Character == '.')
            {
                return true;
            }

            return node.Character == target;
        }

        /// <summary>
        /// Tells if the user possibly went north
        /// </summary>
        /// <param name="path">the path the user went on</param>
        /// <param name="startingRow">the possible row the user started in</param>
        /// <param name="col">the possible column the user started in</param>
        /// <returns>true if this is a valid position of where the user is</returns>
        private bool NorthValid(string path, int startingRow, int col)
        {
            _3DMaze.Node neighbor = module.Maze[startingRow, col];

            for (int i = 1; i < path.Length; i++)
            {
                neighbor = neighbor.North;

                //check if ther is a wall between the spaces
                if (neighbor == null)
                {
                    return false;
                }

                //check to see if neighbor characters match
                if (!CharacterMatch(neighbor, path[i]))
                {
                    return false;
                }
            }

            bool facingWallNorth = neighbor.North == null;

            return facingWall == facingWallNorth;
        }

        private bool SouthValid(string path, int startingRow, int col)
        {
            _3DMaze.Node neighbor = module.Maze[startingRow, col];

            for (int i = 1; i < path.Length; i++)
            {
                neighbor = neighbor.South;

                //check if ther is a wall between the spaces
                if (neighbor == null)
                {
                    return false;
                }

                //check to see if next pair of characters match
                if (!CharacterMatch(neighbor, path[i]))
                {
                    return false;
                }
            }

            bool facingWallSouth = neighbor.South == null;

            return facingWall == facingWallSouth;
        }

        private bool EastValid(string path, int startingRow, int col)
        {
            _3DMaze.Node neighbor = module.Maze[startingRow, col];

            for (int i = 1; i < path.Length; i++)
            {
                neighbor = neighbor.East;

                //check if ther is a wall between the spaces
                if (neighbor == null)
                {
                    return false;
                }

                //check to see if next pair of characters match
                if (!CharacterMatch(neighbor, path[i]))
                {
                    return false;
                }
            }

            bool facingWallEast = neighbor.East == null;

            return facingWall == facingWallEast;
        }

        private bool WestValid(string path, int startingRow, int col)
        {
            _3DMaze.Node neighbor = module.Maze[startingRow, col];

            for (int i = 1; i < path.Length; i++)
            {
                neighbor = neighbor.West;

                //check if ther is a wall between the spaces
                if (neighbor == null)
                {
                    return false;
                }

                //check to see if next pair of characters match
                if (!CharacterMatch(neighbor, path[i]))
                {
                    return false;
                }
            }

            bool facingWallWest = neighbor.West == null;

            return facingWall == facingWallWest;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }
    }
}