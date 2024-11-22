public class MazeGeneratorCell
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;
}

public class MazeGenerator
{
    public int Width = 23;
    public int Height = 10;

    public MazeGeneratorCell[,] GenerateMaze()
    {
        MazeGeneratorCell[,] maze = InitializeMaze();
        GenerateMazeWithBinaryTree(maze);
        return maze;
    }

    private MazeGeneratorCell[,] InitializeMaze()
    {
        MazeGeneratorCell[,] maze = new MazeGeneratorCell[Width, Height];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeGeneratorCell
                {
                    X = x,
                    Y = y
                };
            }
        }

        return maze;
    }

    private void GenerateMazeWithBinaryTree(MazeGeneratorCell[,] maze)
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                MazeGeneratorCell current = maze[x, y];

                var directions = new System.Collections.Generic.List<string>();

                if (x < Width - 1) directions.Add("Right");
                if (y < Height - 1) directions.Add("Up");

                if (directions.Count > 0)
                {
                    string direction = directions[UnityEngine.Random.Range(0, directions.Count)];
                    RemoveWall(current, direction);
                }
            }
        }
    }

    private void RemoveWall(MazeGeneratorCell current, string direction)
    {
        if (direction == "Right")
        {
            current.WallLeft = false;
        }
        else if (direction == "Up")
        {
            current.WallBottom = false;
        }
    }
}